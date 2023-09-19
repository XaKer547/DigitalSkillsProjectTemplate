using Microsoft.EntityFrameworkCore;
using Some.DataAccess.Data;
using Some.Domain.Models.DTOs;
using Some.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace Some.Application.Services.Api
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IJwtService _jwtService;
        private SomeDbContext _context;
        public AuthorizationService(IJwtService jwtService, SomeDbContext context)
        {
            _jwtService = jwtService;
            _context = context;
        }

        public async Task<AuthorizationResultDTO> AuthorizeAsync(LoginDTO dto)
        {
            var user = await _context.User.Select(u => new
            {
                u.Id,
                Role = u.Role.Name,
                u.Password,
                u.Login
            }).SingleOrDefaultAsync(u => u.Password == dto.Password && u.Login == dto.Login);


            if (user is null)
            {
                return new AuthorizationResultDTO()
                {
                    IsSuccess = false
                };
            }


            return new AuthorizationResultDTO()
            {
                IsSuccess = true,
                Token = _jwtService.CreateToken(user.Id, user.Role)
            };
        }
    }
}
