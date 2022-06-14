using System;
using System.Collections.Generic;

namespace ProjectMange.Services.CommonSvc.Dtos
{
    /// <summary>
    /// Common输入模型
    ///</summary>
    public class LogInput
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Decription { get; set; }
        
    }
}

