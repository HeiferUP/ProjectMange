using System;
using System.Collections.Generic;
using LDFCore.Platform.Query;

namespace ProjectMange.Services.Query
{
    /// <summary>
    /// Common分页请求模型
    ///</summary>
    public class WorkFlowInstanceQuery : QueryModel
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
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string InstanceId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? ModelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string NextReviewer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OutGoodsId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? OutNum { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public byte Status { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string UserId { get; set; }

    }
}


