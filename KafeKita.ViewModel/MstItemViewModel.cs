using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KafeKita.ViewModel
{
    public class MstItemViewModel
    {
        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string ItemCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Name { get; set; }
        public int Qty { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(4)]
        public string Pieces { get; set; }
        public decimal Price { get; set; }
        public bool Actived { get; set; }
        public DateTime CreatedOn { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string ModifiedBy { get; set; }
    }
}
