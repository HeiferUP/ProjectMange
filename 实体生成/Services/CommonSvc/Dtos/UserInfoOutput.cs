using System;
using System.Collections.Generic;

namespace ProjectMange.Services.CommonSvc.Dtos
{
    /// <summary>
    /// Common输出模型
    ///</summary>
    public class UserInfoOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public byte DelFlag { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DelTime { get; set; }
        
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

