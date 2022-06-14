using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Entity
{

    [Table(DisableSyncStructure = true)]
    public partial class PowerInfo : Entity<int>
    {

        [Column(StringLength = 128)]
        public string ActionUrl { get; set; }

        [Column(StringLength = 32)]
        public string Description { get; set; }

        [Column(StringLength = 4)]
        public string HttpMethod { get; set; }

        [Column(StringLength = 32)]
        public string MenuIconUrl { get; set; }

        [Column(StringLength = 16)]
        public string Name { get; set; }

        [Column(StringLength = 16)]
        public string ParentId { get; set; }

        [Column(StringLength = 16)]
        public string PowerId { get; set; }

        public double? Sort { get; set; }

    }

}

