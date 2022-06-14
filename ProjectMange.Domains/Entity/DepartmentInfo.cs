using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Entity
{

    [Table(DisableSyncStructure = true)]
    public partial class DepartmentInfo
    {

        [Column(IsPrimary = true, IsIdentity = true)]
        public int ID { get; set; }

        public DateTime? AddTime { get; set; }

        [Column(StringLength = 16)]
        public string DepartmentId { get; set; }

        [Column(StringLength = 16)]
        public string DepartmentName { get; set; }

        [Column(StringLength = 16)]
        public string LeaderId { get; set; }

        [Column(StringLength = 16)]
        public string ParentId { get; set; }

    }

}

