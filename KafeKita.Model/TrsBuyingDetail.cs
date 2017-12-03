using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KafeKita.Model
{
    public class TrsBuyingDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceDetailId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string InvoiceCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string ItemCode { get; set; }
        public int Qty { get; set; }
        public decimal BuyingPrice { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string SupplierCode { get; set; }
    }
}
