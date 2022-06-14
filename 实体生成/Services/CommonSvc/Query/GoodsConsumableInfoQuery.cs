using System;
using System.Collections.Generic;
using LDFCore.Platform.Query;

namespace ProjectMange.Services.CommonSvc.Query
{
    /// <summary>
    /// Common分页请求模型
    ///</summary>
    public class GoodsConsumableInfoQuery : QueryModel
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
        public int? CategoryId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public byte DelFlag { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string GoodsId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public decimal? Money { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public double? Num { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Specification { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Unit { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public double? WarningNum { get; set; }
        
    }
}


