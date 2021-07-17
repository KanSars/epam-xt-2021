﻿using Marketplace.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.DAO.Interfaces
{
    public interface IBuyersProductsDAO
    {
        List<Product> GetProductsOfBuyer(int idBuyer);

        List<Product> GetProductsOfBuyer(string login);

        List<ProductInCart> GetProductsInCart(string login);
        void AddProductToCart(string login, int idProduct);

        void RemoveProductFromCart(string login, int idProduct);

        void DeleteProductFromCart(int idBuyer);

        void DeleteProductFromCartByIdProduct(int idProduct);

        // void DeleteBuyerData(int idBuyer);

    }

}
