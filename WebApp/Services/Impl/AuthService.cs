using WebApp.Data;

namespace WebApp.Services.Impl
{
    public class AuthService : IAuthService
    {
        private readonly DatabaseContext _db;
        public AuthService(DatabaseContext context)
        {
            _db = context;
        }

        public AuthResult CheckCredentials(string email, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}