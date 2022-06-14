using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Domains.Common 
{

    [Table(DisableSyncStructure = true)]
    public partial class RoleInfo : Entity<int>
    {

        public DateTime AddTime { get; set; }
        
        public byte DelFlag { get; set; }
        
        public DateTime? DelTime { get; set; }
        
        [Column(StringLength = 32)]
        public string Description { get; set; }
        
        [Column(StringLength = 16)]
        public string RoleId { get; set; }
        
        [Column(StringLength = 16)]
        public string RoleName { get; set; }
        
	}

}

