using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestKmg.Common.ViewModels.Group;
using TestKmg.Common.Models;
using Microsoft.EntityFrameworkCore;
using TestKmg.Common.ViewModels.Product;

namespace TestKmg.Common.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        
        public List<GroupViewModel> GetGroupList()
        {
            return _dbContext.ProductGroups
                .Select(gr => new GroupViewModel()
                {
                    Id = gr.Id,
                    NameKaz = gr.NameKaz,
                    NameRus = gr.NameRus
                })
                .ToList();
        }
        public GroupViewModel GetGroup(int groupId)
        {
            return _dbContext.ProductGroups
                .Where(gr => gr.Id == groupId)
                .Select(gr => new GroupViewModel { Id = gr.Id, NameRus = gr.NameRus, NameKaz = gr.NameKaz })
                .FirstOrDefault(); 
        }
        public void AddGroup(AddGroupViewModel model)
        {
            var group = new ProductGroup { NameRus = model.NameRus, NameKaz = model.NameKaz };
            _dbContext.ProductGroups.Add(group);

            if (model.Fields!=null)
                model.Fields.ForEach(f =>
                {
                    if (!string.IsNullOrWhiteSpace(f))
                    {
                        var field = new Field() { GroupId = group.Id, Name = f };
                        _dbContext.Fields.Add(field);
                    }
                });
            _dbContext.SaveChanges();
        }
        public List<ProductViewModel> GetProductList(int? groupId, Dictionary<int, string> fields)
        {
            return _dbContext.Products.Include(pr=>pr.Fields).Where(pr => (pr.GroupId == groupId||groupId==null) &&
            (fields == null || fields.All(x=>x.Value == "") || pr.Fields.Any(f => fields.Any(ff => ff.Key == f.FieldId && ff.Value == f.Value || ff.Value == ""))))
            .Select(pr => new ProductViewModel
            {
                Id = pr.Id,
                NameRus = pr.NameRus,
                NameKaz = pr.NameKaz,
                DescriptionRus = pr.DescriptionRus,
                DescriptionKaz = pr.DescriptionKaz,
                Price = pr.Price
            })
            .ToList();
        }
        public void AddProduct(AddProductViewModel model)
        {
            var product = new Product
            {
                NameRus = model.NameRus,
                NameKaz = model.NameKaz,
                DescriptionRus = model.DescriptionRus,
                DescriptionKaz = model.DescriptionKaz,
                DateCreated = DateTime.Now,
                GroupId = model.GroupId,
                Price = model.Price
            };
            _dbContext.Products.Add(product);

           foreach(var field in model.Fields)
            {
                var productField = new ProductField
                {
                    DateCreated = DateTime.Now,
                    FieldId = field.Key,
                    ProductId = product.Id,
                    Value = field.Value
                };
                _dbContext.ProductFields.Add(productField);
            }

            _dbContext.SaveChanges();
        }
        public List<FieldViewModel> GetFieldList(int groupId)
        {
            return _dbContext.Fields.Where(f => f.GroupId == groupId)
                 .Select(f => new FieldViewModel() { Id = f.Id, Name = f.Name }).ToList(); 
        }
    }
}
