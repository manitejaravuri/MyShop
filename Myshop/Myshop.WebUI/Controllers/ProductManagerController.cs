using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Myshop.core.contracts;
using Myshop.Core.Models;
using Myshop.Core.ViewModels;
using Myshop.DataAccess.inMemory;

namespace Myshop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IRepositary<productCategory> context;
        IRepositary<productCategory> productcategories;
        
       


        public ProductManagerController(IRepositary<productCategory> productcontext, IRepositary<productCategory> productCategorycontext)
        {
            context = productcontext;
            //context = new inMemoryRepositary<product>();
            productcategories = productCategorycontext;
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<productCategory> products = context.collection().ToList();
            return View(products);
        }
        public ActionResult create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.product = new productCategory();
            viewModel.productCategories = productcategories.collection();
           

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult create(productCategory product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.Insert(product);

                context.commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string id)
        {
            productCategory product = context.Find(id);

            if(product==null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.product = product;
                viewModel.productCategories = productcategories.collection();
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(productCategory product,string id)
        {
            productCategory productToEdit = context.Find(id);

            if(productToEdit==null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(product);
                }
                productToEdit.Category = product.Category;
                //productToEdit.Description = product.Description;
                //productToEdit.image = product.image;
                //productToEdit.Name = product.Name;
                //productToEdit.price = product.price;

                context.commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string id)
        {
            productCategory productToDelete = context.Find(id);

            if(productToDelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string id)
        {
            productCategory productToDelete = context.Find(id);

            if(productToDelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(id);
                context.commit();
                return RedirectToAction("Index");
            }

        }
    }
}