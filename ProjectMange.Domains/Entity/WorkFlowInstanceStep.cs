using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Entity
{

    [Table(Name = "WorkFlow_InstanceStep", DisableSyncStructure = true)]
    public partial class WorkFlowInstanceStep : Entity<int>
    {

        [Column(StringLength = 64)]
        public string InstanceId { get; set; }

        [Column(StringLength = 16)]
        public string NextReviewerId { get; set; }

        [Column(StringLength = 16)]
        public string ReviewerId { get; set; }

        [Column(StringLength = 64)]
        public string ReviewReason { get; set; }

        public byte ReviewStatus { get; set; }

        public DateTime? ReviewTime { get; set; }

    }

}

