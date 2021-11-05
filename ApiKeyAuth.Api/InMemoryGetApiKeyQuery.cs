using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiKeyAuth.Api
{
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly Dictionary<string, ApiKey> _apiKeys;

        public InMemoryGetApiKeyQuery()
        {
            // var existingApiKeys = new ApiKey[]
            // {
            //     new(1, "Finance", "51F030F5-7C35-4B11-ADF7-8EC545E23AE6", new DateTime(2019, 01, 01),
            //         new string[] {Roles.Employee}),
            //     new(2, "Reception", "0B855ED3-EC65-4E92-BDDF-563A85EFA662", new DateTime(2019, 01, 01),
            //         new string[]
            //         {
            //             Roles.Employee
            //         }),
            //     new(3, "Management", "9F52D431-395D-4163-885C-ECA1FAC11148", new DateTime(2019, 01, 01),
            //         new string[] {Roles.Employee, Roles.Manager}),
            //     new(4, "Some Third Party", "F73F546D-71A9-43EA-A536-9273A2A31A30", new DateTime(2019, 01, 01),
            //         new string[] {Roles.ThirdParty})
            // };
            //
            // _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }
}