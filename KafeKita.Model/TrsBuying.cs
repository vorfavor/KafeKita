using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KafeKita.Model
{
    public class TrsBuying
    {
        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string InvoiceCode { get; set; }
        public DateTime Date { get; set; }
        public int TotalItem { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Approved { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string OfficerCode { get; set; }
    }
}
