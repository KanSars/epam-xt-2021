using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Entities
{
    public class BuyersProducts
    {
        public int  IdBuyer { get; private set; }

        public int IdProduct { get; private set; }

        public BuyersProducts(int idBuyer, int idProduct)
        {
            IdBuyer = idBuyer;
            IdProduct = idProduct;
        }

        public override string ToString() => JsonConvert.SerializeObject(this);
    }
}
