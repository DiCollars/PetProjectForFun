using BLL.Services.TokenService;
using Microsoft.AspNetCore.Mvc;
using PhotoManager.DTO;

namespace PhotoManager.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("get-token")]
        public async Task<IActionResult> GetToken([FromBody] RUserShort userShort)
        {
            try
            {
                var access_token = await _tokenService.GenerateToken(userShort.Login, userShort.Password);

                if (access_token == null)
                {
                    throw new Exception("Token is null.");
                }

                return Ok(access_token);
            }
            catch (Exception)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
        }
    }
}
