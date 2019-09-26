using Myshop.Core.Models;
using Myshop.DataAccess.inMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myshop.WebUI.Controllers
{
    public class productCategoryManagerController : Controller
    {
        productCategoryRepositary context;
        

        public productCategoryManagerController()
        {
            context = new productCategoryRepositary();
        }
        public ActionResult Index()
        {
            List<productCategory> productCategories = context.Collection().ToList();
            return View(productCategories);
        }
        public ActionResult create()
        {
            productCategory productCategory = new productCategory();
            return View(productCategory);
        }
        [HttpPost]
        public ActionResult Create(productCategory productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {
                context.Insert(productCategory);
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(string Id)
        {
            productCategory productCategory = context.Find(Id);
            if(productCategory==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }
        [HttpPost]
        public ActionResult Edit(productCategory product,string Id)
        {
            productCategory productCategoryToEdit = context.Find(Id);

            if(productCategoryToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if(!ModelState.IsValid)
                {
                    return View(product);
                }
                productCategoryToEdit.Category = product.Category;


            }
            context.commit();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(string Id)
        {
            productCategory productCategoryToDelete = context.Find(Id);

            if(productCategoryToDelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategoryToDelete);
            }
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            productCategory productCategoryToDelete = context.Find(Id);
            if(productCategoryToDelete==null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
            }
            return RedirectToAction("Index");
        }
    }
}