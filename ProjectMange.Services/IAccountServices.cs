using LDFCore.Platform.Result;
using ProjectMange.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMange.Services
{
    public interface IAccountServices
    {
        /// <summary>
        /// 简易登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<IResultModel> Login(string username, string password);
        
        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<IResultModel> RegisterUser(UserInfoInput input);
    }
}
