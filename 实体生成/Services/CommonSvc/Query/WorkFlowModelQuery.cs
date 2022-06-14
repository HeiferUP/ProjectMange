using System;
using System.Collections.Generic;
using LDFCore.Platform.Query;

namespace ProjectMange.Services.CommonSvc.Query
{
    /// <summary>
    /// Common分页请求模型
    ///</summary>
    public class WorkFlowModelQuery : QueryModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? AddTime { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public byte DelFlag { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        
    }
}


