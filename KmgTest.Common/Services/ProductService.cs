using TestKmg.Common.ViewModels.Group;
using TestKmg.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using TestKmg.Common.ViewModels.Product;

namespace TestKmg.Common.Services
{
    public class ProductService : BaseService
    {
        private readonly ProductRepository _productRepository;
        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public List<GroupViewModel> GetGroupList()
        {
            return _productRepository.GetGroupList();
        }
        public GroupViewModel GetGroup(int groupId)
        {
            return _productRepository.GetGroup(groupId);
        }
        public void AddGroup(AddGroupViewModel model)
        {
            _productRepository.AddGroup(model);
        }
        public void AddProduct(AddProductViewModel model)
        {
            _productRepository.AddProduct(model);
        }
        public List<FieldViewModel> GetFieldList(int groupId)
        {
            return _productRepository.GetFieldList(groupId);
        }
        public List<ProductViewModel> GetProductList(int? groupId, Dictionary<int, string> fields)
        {
            return _productRepository.GetProductList(groupId, fields);
        }
    }
}
