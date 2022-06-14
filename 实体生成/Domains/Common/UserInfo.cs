using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Domains.Common 
{

    [Table(DisableSyncStructure = true)]
    public partial class UserInfo : Entity<int>
    {

        public DateTime AddTime { get; set; }
        
        public byte DelFlag { get; set; }
        
        public DateTime? DelTime { get; set; }
        
        [Column(StringLength = 16)]
        public string DepartmentId { get; set; }
        
        [Column(StringLength = 32)]
        public string Email { get; set; }
        
        [Column(DbType = "char(32)")]
        public string PassWord { get; set; }
        
        [Column(StringLength = 16)]
        public string PhoneNum { get; set; }
        
        public byte Sex { get; set; }
        
        [Column(StringLength = 16)]
        public string UserId { get; set; }
        
        [Column(StringLength = 16)]
        public string UserName { get; set; }
        
	}

}

