using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BLL.Data
{
    public class AuthOptions
    {
        public const string ISSUER = "Dendy";

        public const string AUDIENCE = "User";

        const string KEY = "GDJi2JHD>hj`@13ghjf☺2gh4j45○kh♠1";

        public const int LIFETIME = 10000;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
