using System;
using System.Collections.Generic;

namespace ProjectMange.Services.Dtos
{
    /// <summary>
    /// Common输入模型
    ///</summary>
    public class UserInfoInput
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string DepartmentId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Sex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }

    }
}

