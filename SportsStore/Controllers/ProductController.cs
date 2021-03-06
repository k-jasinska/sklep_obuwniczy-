﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;    //chcemy widiziec 4 produkty
        public ProductController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(string category, int productPage = 1)
        {      
            var model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.Category == category)
                .OrderBy(p => p.ProductID)    //ukłądamy w koljnosci klucza
                .Skip((productPage - 1) * PageSize) //pomijamy produkty znajdujace sie przed strona
                .Take(PageSize),   //odczytujemy tyle produktow ile wskazuje zmienna

                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category==null?
                    repository.Products.Count():
                    repository.Products.Where(e=>e.Category==category).Count()
                },

                CurrentCategory = category
            };
            return View(model);
        }

        public ActionResult StronyStatyczne(string name)
        {
            return View(name);
        }
        public ActionResult Description(int id)
        {
            var produkt = repository.Products.Where(p => p.ProductID == id).FirstOrDefault();
            return View(produkt);
        }
    }
}
