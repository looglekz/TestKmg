using System;
using System.Collections.Generic;
using System.Text;

namespace TestKmg.Common.ViewModels.Product
{
    public class ProductFilterViewModel
    {
        public int? GroupId { get; set; }
        public Dictionary<int, string> Fields { get; set; }
    }
}
