namespace WebApp.Services
{
    public enum AuthResult
    {
        Success,
        InvalidCredentials
    }
        
    public interface IAuthService
    {

        AuthResult CheckCredentials(string email, string password);
    }
}