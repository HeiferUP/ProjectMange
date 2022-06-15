using LDFCore.Platform.Result;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectMange.Services;
using ProjectMange.Services.Dtos;

namespace ProjectMange.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountControllers : ControllerBase
    {
        private readonly IAccountServices _accountServices;
        public AccountControllers(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        /// <summary>
        /// 测试Swagger注释
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel<LoginUserOutput>> Login(string name,string password)
        {
            var result=await _accountServices.Login(name,password);
            return result;
        }
    }
}
