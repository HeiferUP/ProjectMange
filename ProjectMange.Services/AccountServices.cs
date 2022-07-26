using AutoMapper;
using FreeSql;
using FreeSql.Internal;
using LDFCore.Platform.Result;
using Microsoft.Extensions.Caching.Memory;
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
        private readonly IMemoryCache _memoryCache;
        private readonly IMapper _mapper;
        public AccountServices(IConfiguration configuration, IBaseRepository<UserInfo, int> userInfoRepo, IMemoryCache memoryCache, IMapper mapper)
        {
            _configuration = configuration;
            _userInfoRepo = userInfoRepo;
            _memoryCache = memoryCache;
            _mapper = mapper;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IResultModel> Login(string username, string password)
        {
            return await GetToken(username,password);
            
        }

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="passWord"></param>
        /// <returns></returns>
        private async Task<IResultModel> GetToken(string userName, string passWord)
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

                //缓存一些用户信息
                _memoryCache.Set("UserName", user.UserName);
                _memoryCache.Set("UserId", user.UserId);
                _memoryCache.Set("DepartmentId", user.DepartmentId);
                return ResultModel.Success(resut) ;
            }
            else if (user.DelFlag.Equals(1))
            {
                return ResultModel.Failed("账号已被禁用，请重试");

            }
            else
            {
                return ResultModel.Failed("账号或密码错误，请重试");
            }
        }

        /// <summary>
        /// 注册
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<IResultModel> RegisterUser(UserInfoInput input)
        {
            var verify =await VerifyAddUsaer(input);
            if (!verify.Successful) return verify;
            var data = _mapper.Map<UserInfo>(input);
            data.PassWord = LDFCore.Platform.Utils.Encrypt.Md5By32(data.PassWord);
            await _userInfoRepo.InsertAsync(data);
            return ResultModel.Success();
        }

        private async Task<IResultModel> VerifyAddUsaer(UserInfoInput input,bool IsAdd=true)
        {
            if (IsAdd)
            {
                if (await _userInfoRepo.Where(x => x.UserId == input.UserId).AnyAsync())
                {
                    return ResultModel.Failed("用户已存在");
                }
                if (await _userInfoRepo.Where(x => x.UserName == input.UserName).AnyAsync())
                {
                    return ResultModel.Failed("用户名已存在");
                }
                if (await _userInfoRepo.Where(x => x.Email == input.Email).AnyAsync())
                {
                    return ResultModel.Failed("邮箱已存在");
                }
            }
            else
            {
                if(await _userInfoRepo.Where(x => x.UserId == input.UserId).AnyAsync())
                {
                    return ResultModel.Failed("用户已存在");
                }
            }
            return ResultModel.Success();
        }
    }
}
