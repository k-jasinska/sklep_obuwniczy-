using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IProductRepository
    {
        //IQueryable uzywamy gdy korzystamy z bazy danych i chcemy pobrac tylko niektóej obiekty nie pobierajac wszystkich.
        IQueryable<Product> Products { get; }   
    }
}
