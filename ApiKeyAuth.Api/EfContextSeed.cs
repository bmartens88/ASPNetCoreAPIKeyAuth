using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiKeyAuth.Api
{
    public static class EfContextSeed
    {
        public static async Task SeedAsync(EfContext context)
        {
            await context.Database.MigrateAsync();
            if (!context.ApiKeys.Any())
            {
                var existingApiKeys = new ApiKey[]
                {
                    new(1, "Finance", "51F030F5-7C35-4B11-ADF7-8EC545E23AE6", new DateTime(2019, 01, 01),
                        $"{Roles.Employee}"),
                    new(2, "Reception", "0B855ED3-EC65-4E92-BDDF-563A85EFA662", new DateTime(2019, 01, 01),
                        $"{Roles.Employee}"),
                    new(3, "Management", "9F52D431-395D-4163-885C-ECA1FAC11148", new DateTime(2019, 01, 01),
                        $"{Roles.Employee},{Roles.Manager}"),
                    new(4, "Some Third Party", "F73F546D-71A9-43EA-A536-9273A2A31A30", new DateTime(2019, 01, 01),
                        $"{Roles.ThirdParty}")
                };
                await context.ApiKeys.AddRangeAsync(existingApiKeys);
                await context.SaveChangesAsync();
            }
        }
    }
}