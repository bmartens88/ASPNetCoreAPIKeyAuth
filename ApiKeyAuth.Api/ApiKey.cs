using System;

namespace ApiKeyAuth.Api
{
    public class ApiKey
    {
        public ApiKey(int id, string owner, string key, DateTime created, string roles)
        {
            Id = id;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Key = key ?? throw new ArgumentNullException(nameof(key));
            Created = created;
            Roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        public int Id { get; set; }
        public string Owner { get; set; }
        public string Key { get; set; }
        public DateTime Created { get; set; }
        public string Roles { get; set; }
    }
}