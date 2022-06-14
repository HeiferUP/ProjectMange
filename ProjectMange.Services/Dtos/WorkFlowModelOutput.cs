using System;
using System.Collections.Generic;

namespace ProjectMange.Services.Dtos
{
    /// <summary>
    /// Common输出模型
    ///</summary>
    public class WorkFlowModelOutput
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

