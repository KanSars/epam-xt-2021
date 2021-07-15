using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.BLL.Interfaces;
using Marketplace.Entities;
using Marketplace.DAO.Interfaces;

namespace Marketplace.BLL
{
    public class ProductsLogic : IProductsLogic
    {
        private IProductsDAO _productsDAO;
        public ProductsLogic(IProductsDAO listDao)
        {
            _productsDAO = listDao;
        }

        public void AddProduct(string title)
        {
            _productsDAO.AddProduct(title);
        }

        public void AddProduct(string title, int price)
        {
            _productsDAO.AddProduct(title, price);
        }

        public List<Product> GetAllProducts()
        {
            return _productsDAO.GetAllProducts();
        }

        public List<Product> GetProductsByTitle(string title)
        {
            return _productsDAO.GetProductsByTitle(title);
        }

        public Product GetProductById(int id)
        {
            return _productsDAO.GetProductById(id);
        }

        public void EditProductData(int id, string title, int price)
        {
            _productsDAO.EditProductData(id, title, price);
        }
    }
}
