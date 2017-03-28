using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer
{
   public class Inventory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InventoryID { get; set; }

        public string ProductName { get; set; }

        public float ProductBuyPrice { get; set; }

        public float ProductSellPrice { get; set; }

        public int ProductQuantity { get; set; }
    }
}
