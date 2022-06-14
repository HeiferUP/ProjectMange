using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Domains.Common 
{

    [Table(Name = "WorkFlow_Model", DisableSyncStructure = true)]
    public partial class WorkFlowModel : Entity<int>
    {

        public DateTime AddTime { get; set; }
        
        public byte DelFlag { get; set; }
        
        [Column(StringLength = 64)]
        public string Description { get; set; }
        
        [Column(StringLength = 32)]
        public string Title { get; set; }
        
	}

}

