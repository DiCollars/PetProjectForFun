using BLL.Services.TokenService;
using Mapper.PALDTO;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetToken([FromBody] PUserShort userShort)
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
