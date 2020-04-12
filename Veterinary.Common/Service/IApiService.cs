using System.Threading.Tasks;
using Veterinary.Common.Models;
using Veterinary.Models;

namespace Veterinary.Common.Service
{
    public interface IApiService
    {
        Task<Response<OwnerResponse>> GetOwnerByEmailAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response<TokenResponse>> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

        Task<bool> CheckConnection(string url);

    }
}
