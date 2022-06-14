using System;
using System.Collections.Generic;

namespace ProjectMange.Services.Dtos
{
    /// <summary>
    /// Common输入模型
    ///</summary>
    public class GoodsEquipmentInputInput
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
        public string AddUserId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Num { get; set; }

    }
}

