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
        public async Task<IResultModel> Login(string name,string password)
        {
           return await _accountServices.Login(name,password);
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IResultModel> RegisterUser(UserInfoInput input)
        {
            return await _accountServices.RegisterUser(input);
        }
    }
}
