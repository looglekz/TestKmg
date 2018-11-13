using System;
using System.Collections.Generic;
using System.Text;
using TestKmg.Common.ViewModels.Group;

namespace TestKmg.Common.ViewModels.Product
{
    public class ProductListViewModel
    {
        public List<ProductViewModel> Products { get; set; }
        public List<GroupViewModel> Groups { get; set; }
        public List<FieldViewModel> Fields { get; set; }
        public int? GroupId { get; set; }
    }
}
