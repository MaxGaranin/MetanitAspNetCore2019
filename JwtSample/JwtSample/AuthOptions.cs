using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace JwtSample
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer";
        public const string AUDIENCE = "https://localhost:44355/";
        public const int LIFETIME = 1;

        private const string KEY = "mysupersecret_secretkey!123";

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}