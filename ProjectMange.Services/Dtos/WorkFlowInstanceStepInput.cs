using System;
using System.Collections.Generic;

namespace ProjectMange.Services.Dtos
{
    /// <summary>
    /// Common输入模型
    ///</summary>
    public class WorkFlowInstanceStepInput
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

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

