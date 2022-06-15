using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMange.Services.Dtos
{
    public class LoginUserOutput
    {
        /// <summary>
        /// 令牌
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public int Sex { get; set; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public int DelFlag { get; set; }

        public string SexType { get { return Sex == 1 ? "男" : "女"; } }

        public string DelFlagType { get { return DelFlag == 0 ? "禁用" : "启用"; } }


    }
}
