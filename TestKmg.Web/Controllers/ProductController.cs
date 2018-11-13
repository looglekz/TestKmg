using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestKmg.Common.Services;
using TestKmg.Common.ViewModels.Group;
using Microsoft.AspNetCore.Mvc;
using TestKmg.Common.ViewModels.Product;

namespace TestKmg.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GroupList()
        {
            return View(_productService.GetGroupList());
        }

        [HttpGet]
        public IActionResult AddGroup(int id)
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult AddGroup(AddGroupViewModel model)
        {
            _productService.AddGroup(model);
            return RedirectToAction("GroupList");
        }

        public IActionResult GetGroup(int groupId)
        {
            return View(_productService.GetGroup(groupId));
        }

        [HttpPost]
        public IActionResult AddProduct(AddProductViewModel model)
        {
            _productService.AddProduct(model);
            return RedirectToAction("ProductList");
        }

        [HttpGet]
        public IActionResult AddProduct(int? groupId)
        {
            var model = new AddProductViewModel
            {   
                Groups = _productService.GetGroupList(),
                GroupFields = groupId.HasValue ? _productService.GetFieldList(groupId.Value) : null
            };
            if (groupId.HasValue)
                model.GroupId = groupId.Value;
            return View(model);
        }

        [HttpGet]
        public IActionResult ProductList(ProductFilterViewModel filter)
        {
            var model = new ProductListViewModel
            {
                GroupId = filter.GroupId,
                Groups = _productService.GetGroupList(),
                Fields = filter.GroupId.HasValue ? _productService.GetFieldList(filter.GroupId.Value) : null,
                Products = _productService.GetProductList(filter.GroupId, filter.Fields) 
            };
            return View(model);

        }

    }
}