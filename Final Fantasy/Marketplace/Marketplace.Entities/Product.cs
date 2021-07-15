using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public Product()
        {

        }
        public Product(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public Product(int id, string title, int price)
        {
            Id = id;
            Title = title;
            Price = price;
        }
    }
}
