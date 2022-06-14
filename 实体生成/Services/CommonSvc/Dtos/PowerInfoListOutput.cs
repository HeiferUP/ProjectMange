using System;
using System.Collections.Generic;

namespace ProjectMange.Services.CommonSvc.Dtos
{
    /// <summary>
    /// Common分页列表输出模型
    ///</summary>
    public class PowerInfoListOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ActionUrl { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string HttpMethod { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string MenuIconUrl { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ParentId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string PowerId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public double? Sort { get; set; }
        
    }
}

