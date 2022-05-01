using BLL.DTO;
using BLL.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoManager.DTO;

namespace PhotoManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("add-user")]
        public async Task AddUser([FromBody] RUserFull user)
        {
            await _userService.Create(new BUserFull 
            { 
                Id = user.Id, 
                Login = user.Login, 
                Role = user.Role, 
                Password = user.Password,
                ProfileName = user.ProfileName
            });
        }

        [Authorize(Roles = "Admin, User")]
        [HttpGet("get-all-users")]
        public async Task<List<RUserWithoutPassword>> GetUsers([FromQuery] int skip, [FromQuery] int take)
        {
            return (await _userService.GetAll(skip, take)).Select(u => new RUserWithoutPassword()
            {
                Id = u.Id,
                Login = u.Login,
                Role = u.Role
            }).ToList();
        }

        //[Authorize(Roles = "Admin")]
        //[HttpPut("update-user-by-admin")]
        //public async Task UpdateUserByAdmin([FromBody] User user)
        //{
        //    await _userService.UpdateUserByAdmin(user);
        //}

        //[Authorize(Roles = "User, Admin")]
        //[HttpPut("update-user-by-user")]
        //public async Task UpdateUserByUser([FromForm] string newLogin, [FromForm] int newIconId, [FromForm] string newPassword)
        //{
        //    await _userService.UpdateUserByUser(newLogin, newIconId, newPassword, HttpContext);
        //}

        //[Authorize(Roles = "Admin, User")]
        //[HttpGet("search-users/{skip}/{take}/{login}")]
        //public async Task<List<NoPasswordUser>> SearchUsers(int skip, int take, string login)
        //{
        //    return (await _userService.SearchUsers(skip, take, login)).Select(u => new NoPasswordUser()
        //    {
        //        Id = u.Id,
        //        Login = u.Login,
        //        Role = u.Role,
        //        Icon = u.Icon.IconString
        //    }).ToList();
        //}

        //[Authorize(Roles = "Admin")]
        //[HttpDelete("delete-user/{id}")]
        //public async Task DeleteUser(int id)
        //{
        //    await _userService.DeleteUser(id);
        //}
    }
}
