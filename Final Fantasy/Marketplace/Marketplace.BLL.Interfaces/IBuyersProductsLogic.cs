using Marketplace.Entities;
using System.Collections.Generic;

namespace Marketplace.BLL.Interfaces
{
    public interface IBuyersProductsLogic
    {
        List<Product> GetProductsOfBuyer(int idBuyer);

        List<Product> GetProductsOfBuyer(string login);

        List<ProductInCart> GetProductsInCart(string login);

        void AddProductToCart(string login, int idProduct);

        void RemoveProductFromCart(string login, int idProduct);

        void MakingAPurchase(string login);

        void DeleteProductFromCart(int idBuyer);

        void DeleteProductFromCartByIdProduct(int idProduct);
    }
}
