using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Domains.Common 
{

    [Table(Name = "R_RoleInfo_PowerInfo", DisableSyncStructure = true)]
    public partial class RRoleInfoPowerInfo : Entity<int>
    {

        [Column(StringLength = 16)]
        public string PowerId { get; set; }
        
        [Column(StringLength = 16)]
        public string RoleId { get; set; }
        
	}

}

