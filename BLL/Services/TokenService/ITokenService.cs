namespace BLL.Services.TokenService
{
    public interface ITokenService
    {
        Task<string> GenerateToken(string username, string password);
    }
}
