using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Entity
{

    [Table(Name = "R_UserInfo_RoleInfo", DisableSyncStructure = true)]
    public partial class RUserInfoRoleInfo : Entity<int>
    {

        [Column(StringLength = 16)]
        public string RoleId { get; set; }

        [Column(StringLength = 16)]
        public string UserId { get; set; }

    }

}

