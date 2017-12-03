using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KafeKita.ViewModel
{
    public class MstSupplierViewModel
    {
        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string SupplierCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string ItemId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }
        [Column(TypeName = "Text")]
        public string Address { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Email { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(12)]
        public string Phone { get; set; }
        public decimal Price { get; set; }
        [Column(TypeName = "Bit")]
        public bool Actived { get; set; }
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ModifiedBy { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ItemName { get; set; }
    }
}
