using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Myshop.Core.Models;
using Myshop.Core.ViewModels;
using Myshop.DataAccess.inMemory;

namespace Myshop.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {

        productRepositary context;
        productCategoryRepositary productcategories;


        public ProductManagerController()
        {
            context = new productRepositary();
            productcategories = new productCategoryRepositary();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<product> products = context.collection().ToList();
            return View(products);
        }
        public ActionResult create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.product = new product();
            viewModel.productCategories = productcategories.Collection();
           

            return View(viewModel);
        }
        [HttpPost]
        public ActionResult create(product product)
        {
            if(!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                context.insert(product);

                context.commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit(string id)
        {
            product product = context.find(id);

            if(product==null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.product = product;
                viewModel.productCategories = productcategories.Collection();
                return View(viewModel);
            }
        }
        [HttpPost]
        public ActionResult Edit(product product,string id)
        {
            product productToEdit = context.find(id);

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
                productToEdit.categeory = product.categeory;
                productToEdit.Description = product.Description;
                productToEdit.image = product.image;
                productToEdit.Name = product.Name;
                productToEdit.price = product.price;

                context.commit();

                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(string id)
        {
            product productToDelete = context.find(id);

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
            product productToDelete = context.find(id);

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