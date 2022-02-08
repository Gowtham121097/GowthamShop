﻿using MyShop.Core.Models;
using MyShop.DataAccess.InMemory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShop.WebUI.Controllers
{
    public class ProductCategoryManagerController : Controller
    {
        ProductCaterogyRepository context;
        public ProductCategoryManagerController()
        {
            context = new ProductCaterogyRepository();
        }
        // GET: ProductManager
        public ActionResult Index()
        {
            List<ProductCaterogy> productCatList = context.Collection().ToList();
            return View(productCatList);
        }

        public ActionResult Create()
        {
            ProductCaterogy productCategory = new ProductCaterogy();
            return View(productCategory);
        }

        [HttpPost]
        public ActionResult Create(ProductCaterogy productCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(productCategory);
            }
            else
            {

                context.Insert(productCategory);
                context.commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            ProductCaterogy productCategory = context.Find(Id);
            if (productCategory == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCategory);
            }
        }

        [HttpPost]
        public ActionResult Edit(ProductCaterogy productCategory, string Id)
        {
            ProductCaterogy productCatToEdit = context.Find(Id);

            if (productCatToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(productCategory);
                }

                productCatToEdit.Category = productCategory.Category;

                context.commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(string Id)
        {
            ProductCaterogy productCatToDelete = context.Find(Id);

            if (productCatToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(productCatToDelete);
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(string Id)
        {
            ProductCaterogy productCatToDelete = context.Find(Id);

            if (productCatToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(Id);
                context.commit();
                return RedirectToAction("Index");
            }
        }
    }
}