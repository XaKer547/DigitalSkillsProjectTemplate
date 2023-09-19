using Some.Domain.Models.DTOs;
using System.Threading.Tasks;

namespace Some.Domain.Services
{
    public interface IAuthorizationService
    {
        Task<AuthorizationResultDTO> AuthorizeAsync(LoginDTO dto);
    }
}
