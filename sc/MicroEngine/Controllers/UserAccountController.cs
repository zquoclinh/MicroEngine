using MicroEngine.Common;
using MicroEngine.Framework.Commons;
using MicroEngine.Models.RequestModels;
using MicroEngine.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MicroEngine.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserAccountService _UserService;
        private readonly OptimalSetting _setting;

        public UserController(IUserAccountService UserService, OptimalSetting setting)
        {
            _UserService = UserService;
            _setting = setting;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddUser(UserAccountModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Unauthorized("You need to log in to access this resource.");
            }
            var response = await _UserService.Create(model);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await _UserService.GetAllUser();
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateUser(UserUpdateModel model)
        {
            var respone = await _UserService.Update(model);
            return Ok(respone);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _UserService.GetById(id);
            if (response != null)
                return Ok(response);
            else
                return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetByUserCode(string UserId)
        {
            var response = await _UserService.GetByUserCode(UserId);
            if (response != null)
                return Ok(response);
            else
                return NotFound();
        }

        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> DeleteById(int id)
        {
            var emp = await _UserService.GetById(id);
            if (emp != null)
            {
                await _UserService.Delete(id);
                return Ok();
            }
            else
                return NotFound();
        }

        [HttpGet]
        public IActionResult GetSetting()
        {
            return Ok(_setting.Config);
        }
    }
}
