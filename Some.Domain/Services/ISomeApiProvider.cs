using Some.Domain.Models.DTOs;
using System.Threading.Tasks;

namespace Some.Domain.Services
{
    public interface ISomeApiProvider
    {
        Task<T> Get<T>(string url);
        Task<T> Post<T>(string url, object dto);
        Task<T> Put<T>(string url, object dto);
        Task<T> Patch<T>(string url, object dto);
        Task<AuthorizationResultDTO> Authorize(LoginDTO dto);
    }
}
