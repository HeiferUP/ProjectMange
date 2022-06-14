using System;
using System.Collections.Generic;
using LDFCore.Platform.Query;

namespace ProjectMange.Services.Query
{
    /// <summary>
    /// Common分页请求模型
    ///</summary>
    public class GoodsCategoryQuery : QueryModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CategoryName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

    }
}


