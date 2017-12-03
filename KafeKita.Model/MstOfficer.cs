using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KafeKita.Model
{
    public class MstOfficer
    {
        [Key]
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string OfficerCode { get; set; }
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
        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public string Gender { get; set; }
        public int RoleId { get; set; }
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
