using System.Threading.Tasks;
using Veterinary.Common.Models;

namespace Veterinary.Common.Service
{
    public interface IApiService
    {
        Task<Response> GetOwnerByEmail(
            string urlBase,
            string servicePrefix,
            string controller,
            string tokenType,
            string accessToken,
            string email);

        Task<Response> GetTokenAsync(
            string urlBase,
            string servicePrefix,
            string controller,
            TokenRequest request);

    }
}
