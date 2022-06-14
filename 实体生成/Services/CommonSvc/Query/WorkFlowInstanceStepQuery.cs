using System;
using System.Collections.Generic;
using LDFCore.Platform.Query;

namespace ProjectMange.Services.CommonSvc.Query
{
    /// <summary>
    /// Common分页请求模型
    ///</summary>
    public class WorkFlowInstanceStepQuery : QueryModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string InstanceId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string NextReviewerId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ReviewerId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string ReviewReason { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public byte ReviewStatus { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReviewTime { get; set; }
        
    }
}


