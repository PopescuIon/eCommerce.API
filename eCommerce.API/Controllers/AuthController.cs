
using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Mvc; 

namespace eCommerce.Core.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;

        private readonly IUsersService _usersService;

        public AuthController(ILogger<AuthController> logger,
        IUsersService usersService)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]RegisterRequest registerRequest)
        {
            if(registerRequest == null)
            {
                return BadRequest("Invalid register data");
            }
            var authenticationResponse = await _usersService.Register(registerRequest);
            if(authenticationResponse == null || !authenticationResponse.Success)
            {
                return Unauthorized(authenticationResponse);
            }
            return Ok(authenticationResponse);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest loginRequest)
        {
            if(loginRequest == null)
            {
                return BadRequest("Invalid login data");
            }
            var loginesponse = await _usersService.Login(loginRequest);
            if(loginesponse == null || !loginesponse.Success)
            {
                return Unauthorized(loginesponse);
            }
            return Ok(loginesponse);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}