using Some.Domain.Models.DTOs;
using Some.Domain.Services;
using System.Threading.Tasks;

namespace Some.Application.Services.Client
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly ISomeApiProvider _provider;
        public AuthorizationService(ISomeApiProvider provider)
        {
            _provider = provider;
        }

        public async Task<AuthorizationResultDTO> AuthorizeAsync(LoginDTO dto)
        {
            return await _provider.Authorize(dto);
        }
    }
}
