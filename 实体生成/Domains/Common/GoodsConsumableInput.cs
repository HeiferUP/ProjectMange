using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Domains.Common 
{

    [Table(Name = "Goods_ConsumableInput", DisableSyncStructure = true)]
    public partial class GoodsConsumableInput : Entity<int>
    {

        public DateTime AddTime { get; set; }
        
        [Column(StringLength = 16)]
        public string AddUserId { get; set; }
        
        [Column(StringLength = 16)]
        public string GoodsId { get; set; }
        
        public double Num { get; set; }
        
	}

}

