using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    //zwraca stalej wielkosci kolekcje obiektow product. AsQueryable konwertuje kolekcje na postac typu IQueryable
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {Name="Sandały", Price=25},
            new Product {Name="Gumowce", Price=35},
            new Product {Name="Klapki", Price=15},
            new Product {Name="Pantofle", Price=50}
        }.AsQueryable<Product>();
    }
}
