using System;
using System.Collections.Generic;
using LDFCore.Platform.Query;

namespace ProjectMange.Services.Query
{
    /// <summary>
    /// Common分页请求模型
    ///</summary>
    public class PowerInfoQuery : QueryModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }

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


