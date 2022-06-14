using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Entity
{

    [Table(Name = "Goods_Category", DisableSyncStructure = true)]
    public partial class GoodsCategory : Entity<int>
    {

        [Column(StringLength = 16)]
        public string CategoryName { get; set; }

        [Column(StringLength = 32)]
        public string Description { get; set; }

    }

}

