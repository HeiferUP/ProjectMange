using System;
using System.Collections.Generic;
using LDFCore.Platform.Query;

namespace ProjectMange.Services.CommonSvc.Query
{
    /// <summary>
    /// Common分页请求模型
    ///</summary>
    public class RRoleInfoPowerInfoQuery : QueryModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int? Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string PowerId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string RoleId { get; set; }
        
    }
}


