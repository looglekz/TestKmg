using System;
using System.Collections.Generic;
using System.Text;
using TestKmg.Common.ViewModels.Group;

namespace TestKmg.Common.ViewModels.Product
{
    public class AddProductViewModel
    {
        public string NameRus { get; set; }
        public string NameKaz { get; set; }
        public string DescriptionRus { get; set; }
        public string DescriptionKaz { get; set; }
        public int Price { get; set; }
        public int GroupId { get; set; }
        public Dictionary<int, string> Fields { get; set; }
        public List<Group.GroupViewModel> Groups { get; set; }
        public List<FieldViewModel> GroupFields { get; set; }
    }
}
