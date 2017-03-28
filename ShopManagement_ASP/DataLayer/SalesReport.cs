using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DataLayer
{
   public class SalesReport
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SalesReportID { get; set; }

        public int SalesManId { get; set; }

        [ScaffoldColumn(false)]
        public string SaleTime { get; set; }

       // [ScaffoldColumn(false)]
        public DateTime SaleDate { get; set; }

        public double ProductPrice { get; set; }

        public double BuyPrice { get; set; }

        public int Quantity { get; set; }

        public string ProductName { get; set; }

       [DisplayName("Product ID")]
        public int InventoryID { get; set; }

       public string SalesManName { get; set; }
    }
}
