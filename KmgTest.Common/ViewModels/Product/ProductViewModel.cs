using System;
using System.Collections.Generic;
using System.Text;

namespace TestKmg.Common.ViewModels.Product
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string NameKaz { get; set; }
        public string NameRus { get; set; }
        public string DescriptionRus { get; set; }
        public string DescriptionKaz { get; set; }
        public decimal Price { get; set; }
    }
}
