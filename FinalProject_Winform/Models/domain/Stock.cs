﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_Winform.Models.domain
{
    [Table("Stock")]
    public class Stock
    {
        public long Id { get; set; }    // PK

        public Item? Item { get; set; }

        public long Stock_amount { get; set; } // 입/출고 수량

       public long Stock_regAmount { get; set; }  // 입/출고 당시 수량

        public DateTime Stock_regDate { get; set; } // 재고 입/출고 날짜

        public string Stock_status { get; set; } // 입고인지 출고인지




    }
}
