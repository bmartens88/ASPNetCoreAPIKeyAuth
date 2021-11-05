using System.Threading.Tasks;

namespace ApiKeyAuth.Api
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }
}