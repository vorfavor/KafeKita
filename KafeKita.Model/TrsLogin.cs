using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KafeKita.Model
{
    public class TrsLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LoginId { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(5)]
        public string OfficerCode { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string Username { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(8)]
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
    }
}
