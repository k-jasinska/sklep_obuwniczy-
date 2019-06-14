using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Components
{
    public class CartSummaryViewComponent: ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartServices)
        {
            cart = cartServices;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
