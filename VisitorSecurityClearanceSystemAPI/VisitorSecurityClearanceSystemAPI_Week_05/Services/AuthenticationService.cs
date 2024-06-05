using System.Threading.Tasks;
using VisitorSecurityClearanceSystemAPI.Interfaces;

namespace VisitorSecurityClearanceSystemAPI.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;

        public AuthenticationService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Authenticate(string username, string password)
        {
            var user = await _userService.GetUserByUsername(username);
            if (user == null || user.Password != password)
                return false;

            return true;
        }
    }
}
