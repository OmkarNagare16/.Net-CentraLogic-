using Microsoft.AspNetCore.Mvc;

namespace VisitorSecurityClearanceSystemAPI_Week_05.Controllers
{
    public class LoginSystemAuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var isAuthenticated = await _authenticationService.Authenticate(model.Username, model.Password);
            if (!isAuthenticated)
                return Unauthorized("Invalid username or password.");

            return Ok("Login successful.");
        }
    }
}
