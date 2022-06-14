using System;
using System.Collections.Generic;
using FreeSql.DataAnnotations;
using LDFCore.Platform.Entities;

namespace ProjectMange.Domains.Domains.Common 
{

    [Table(Name = "Goods_EquipmentInfo", DisableSyncStructure = true)]
    public partial class GoodsEquipmentInfo : Entity<int>
    {

        public DateTime AddTime { get; set; }
        
        public int CategoryId { get; set; }
        
        public byte DelFlag { get; set; }
        
        [Column(StringLength = 16)]
        public string Description { get; set; }
        
        [Column(StringLength = 16)]
        public string GoodsId { get; set; }
        
        [Column(DbType = "money")]
        public decimal? Money { get; set; }
        
        [Column(StringLength = 16)]
        public string Name { get; set; }
        
        public double Num { get; set; }
        
        [Column(StringLength = 32)]
        public string Specification { get; set; }
        
        [Column(StringLength = 8)]
        public string Unit { get; set; }
        
	}

}

