using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]     //uniemozliwia podanie w zadaniu http wartosci
        public int OrderID { get; set; }
        [BindNever]
        public ICollection<CartLine> Lines { get; set; }
        [BindNever]
        public bool Shipped { get; set; }

        [Required(ErrorMessage="Prosze podać imie i nazwisko!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Prosze podać adres!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Prosze podać miasto!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Prosze podać województwo!")]
        public string State { get; set; }
        [Required(ErrorMessage = "Prosze podać kod pocztowy!")]
        public string Zip { get; set; }
        [Required(ErrorMessage = "Prosze podać kraj!")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }

    }
}
