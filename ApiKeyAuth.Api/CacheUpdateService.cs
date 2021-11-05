using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ApiKeyAuth.Api
{
    public class CacheUpdateService : BackgroundService
    {
        private IMemoryCache _cache;
        private readonly IServiceProvider _services;
        private readonly ILogger<CacheUpdateService> _logger;

        public CacheUpdateService(IMemoryCache cache, IServiceProvider services, ILogger<CacheUpdateService> logger)
        {
            _cache = cache;
            _services = services;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using var scope = _services.CreateScope();
            await using var context = scope.ServiceProvider.GetRequiredService<EfContext>();
            while (!stoppingToken.IsCancellationRequested)
            {
                var keys = await context.ApiKeys.ToListAsync(stoppingToken);
                keys.ForEach(k => _logger.LogInformation(k.Key));
                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }
        }
    }
}