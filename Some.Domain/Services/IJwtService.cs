namespace Some.Domain.Services
{
    public interface IJwtService
    {
        public string CreateToken(int userId, params string[] roles);
    }
}
