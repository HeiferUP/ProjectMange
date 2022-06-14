using System;
using System.Collections.Generic;

namespace ProjectMange.Services.CommonSvc.Dtos
{
    /// <summary>
    /// Common输入模型
    ///</summary>
    public class GoodsConsumableInfoInput
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
        public int CategoryId { get; set; }
        
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
        public double Num { get; set; }
        
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

