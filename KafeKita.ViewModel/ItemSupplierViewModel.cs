using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KafeKita.ViewModel
{
    public class ItemSupplierViewModel
    {
        public List<MstItemViewModel> Item { get; set; }
        public List<MstSupplierViewModel> Supplier { get; set; }
    }
}
