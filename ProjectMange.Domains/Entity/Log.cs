using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Entity
{

    [Table(DisableSyncStructure = true)]
    public partial class Log : Entity<int>
    {

        public DateTime? AddTime { get; set; }

        [Column(StringLength = 128)]
        public string Decription { get; set; }

    }

}

