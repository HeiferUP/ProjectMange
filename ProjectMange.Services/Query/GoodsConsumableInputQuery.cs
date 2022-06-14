using System;
using System.Collections.Generic;
using LDFCore.Platform.Query;

namespace ProjectMange.Services.Query
{
    /// <summary>
    /// Common分页请求模型
    ///</summary>
    public class GoodsConsumableInputQuery : QueryModel
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
        public string AddUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double? Num { get; set; }

    }
}


