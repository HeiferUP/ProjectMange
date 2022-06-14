using System;
using System.Collections.Generic;

namespace ProjectMange.Services.Dtos
{
    /// <summary>
    /// Common输入模型
    ///</summary>
    public class RoleInfoInput
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
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RoleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RoleName { get; set; }

    }
}

