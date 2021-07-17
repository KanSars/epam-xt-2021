using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.BLL.Interfaces;
using Marketplace.DAO.Interfaces;
using Marketplace.Entities;

namespace Marketplace.BLL
{
    public class BuyersProductsLogic : IBuyersProductsLogic
    {
        private IBuyersProductsDAO _buyersProductsDAO;
        public BuyersProductsLogic(IBuyersProductsDAO listDAO)
        {
            _buyersProductsDAO = listDAO;
        }

        public List<Product> GetProductsOfBuyer(int idBuyer)
        {
            return _buyersProductsDAO.GetProductsOfBuyer(idBuyer);
        }

        public List<Product> GetProductsOfBuyer(string login)
        {
            return _buyersProductsDAO.GetProductsOfBuyer(login);
        }

        public List<ProductInCart> GetProductsInCart(string login)
        {
            return _buyersProductsDAO.GetProductsInCart(login);
        }

        public void AddProductToCart(string login, int idProduct)
        {
            _buyersProductsDAO.AddProductToCart(login, idProduct);
        }

        public void RemoveProductFromCart(string login, int idProduct)
        {
            _buyersProductsDAO.RemoveProductFromCart(login, idProduct);
        }

        public void MakingAPurchase(string login)
        {
            //проверить - а есть ли у него что-то в корзине?

            //теоретически тут должна быть проверка средств или переход к платежной системе и пр. далее удаление списка покупок из корзины:

            List<Product> productList = GetProductsOfBuyer(login);

            foreach (var item in productList)
            {
                RemoveProductFromCart(login, item.Id);
            }

        }

        public void DeleteProductFromCart(int idBuyer)
        {
            _buyersProductsDAO.DeleteProductFromCart(idBuyer);
        }

        public void DeleteProductFromCartByIdProduct(int idProduct)
        {
            _buyersProductsDAO.DeleteProductFromCartByIdProduct(idProduct);
        }

    }
}
