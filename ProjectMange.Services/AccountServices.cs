using FreeSql;
using FreeSql.Internal;
using LDFCore.Platform.Result;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectMange.Domains.Entity;
using ProjectMange.Services.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectMange.Services
{
    public class AccountServices : IAccountServices
    {
        public IConfiguration _configuration;
        private readonly IBaseRepository<UserInfo, int> _userInfoRepo;
        public AccountServices(IConfiguration configuration, IBaseRepository<UserInfo, int> userInfoRepo)
        {
            _configuration = configuration;
            _userInfoRepo = userInfoRepo;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IResultModel<LoginUserOutput>> Login(string username, string password)
        {
            var result =await GetToken(username,password);
            return result;
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        private async Task<IResultModel<LoginUserOutput>> GetToken(string userName, string passWord)
        {
            passWord=LDFCore.Platform.Utils.Encrypt.Md5By32(passWord);
            var user = await _userInfoRepo.Where(x => x.UserId == userName && x.PassWord == passWord).FirstAsync();
            //做一个简单的获取Token
            if (user!=null)
            {
                Claim[] claims = new[]
                {
                    new Claim("UserName",userName),
                };
                SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["HS256SecurityKey"]));
                SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                /**
                    iss (issuer)：签发人
                    exp (expiration time)：过期时间
                    sub (subject)：主题
                    aud (audience)：受众
                    nbf (Not Before)：生效时间
                    iat (Issued At)：签发时间
                    jti (JWT ID)：编号
                 * */
                var getToken = new JwtSecurityToken(
                    issuer: _configuration["issuer"],//配置签发人
                    audience: _configuration["audience"],//配置受众
                    claims: claims,//配置用户信息
                    expires: DateTime.Now.AddMinutes(20),//配置20分钟有效期
                    signingCredentials: creds);//配置秘钥信息
                var token = new JwtSecurityTokenHandler().WriteToken(getToken);
                var resut = new LoginUserOutput
                {
                    AddTime = user.AddTime,
                    DelFlag = user.DelFlag,
                    Sex = user.Sex,
                    Token = token,
                    UserName = userName,
                };

                return ResultModel.Success(resut) ;
            }
            else
            {
                return ResultModel.Success(new LoginUserOutput());
            }
        }
    }
}
