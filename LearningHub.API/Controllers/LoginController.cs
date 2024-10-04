using LearningHub.Core.Data;
using LearningHub.Core.DTO;
using LearningHub.Core.Services;
using LearningHub.Infra.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningHub.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService loginService;
        public LoginController(ILoginService loginService)
        {
            this.loginService = loginService;
        }
        [HttpGet]
        [Route("GetAllUsernamesAndRoles")]
        public List<UserData> GetAllUsernamesAndRoles()
        {
            return loginService.GetAllUsernamesAndRoles();
        }
        [HttpPost]
        [Route("Login")]
        public IActionResult Auth(Login login)
        {
            var token = loginService.Auth(login);
            if (token == null)
            {
                return Unauthorized();
            }
            else
            {
                return Ok(token);
            }


        }
    }
}
