using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Domains.Common 
{

    [Table(Name = "WorkFlow_Instance", DisableSyncStructure = true)]
    public partial class WorkFlowInstance : Entity<int>
    {

        public DateTime AddTime { get; set; }
        
        [Column(StringLength = 64)]
        public string Description { get; set; }
        
        [Column(StringLength = 64)]
        public string InstanceId { get; set; }
        
        public int ModelId { get; set; }
        
        [Column(StringLength = 16)]
        public string NextReviewer { get; set; }
        
        [Column(StringLength = 16)]
        public string OutGoodsId { get; set; }
        
        public double OutNum { get; set; }
        
        [Column(StringLength = 64)]
        public string Reason { get; set; }
        
        public byte Status { get; set; }
        
        [Column(StringLength = 16)]
        public string UserId { get; set; }
        
	}

}

