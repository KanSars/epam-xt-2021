using System;
using System.Collections.Generic;
using Marketplace.Entities;

namespace Marketplace.DAO.Interfaces
{
    public interface IProductsDAO
    {

        void AddProduct(string title);

        void AddProduct(string title, int price);

        List<Product> GetAllProducts();

        List<Product> GetProductsByTitle(string title);

        Product GetProductById(int id);

        void EditProductData(int id, string title, int price);

        void DeleteProduct(int idProduct);

        void DeleteProductByIdProduct(int idProduct);
    }
}
