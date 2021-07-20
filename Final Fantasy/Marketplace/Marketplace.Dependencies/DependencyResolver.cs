using Marketplace.BLL.Interfaces;
using Marketplace.BLL;
using Marketplace.DAO.Interfaces;
using BuyersProductsSqlDAO;


namespace Marketplace.Dependencies
{
    public class DependencyResolver
    {
        public static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                if (_instance is null)
                {
                    _instance = new DependencyResolver();

                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }

        private IBuyersDAO BuyersDAO => new BuyersSqlDAO();
        public IBuyersLogic BuyresLogic => new BuyersLogic(BuyersDAO);

        private IProductsDAO ProductsDAO => new ProductsSqlDAO();
        public IProductsLogic ProductsLogic => new ProductsLogic(ProductsDAO);

        private IBuyersProductsDAO BuyersProductsDAO => new Buyers_ProductsSqlDAO();
        public IBuyersProductsLogic BuyersProductsLogic => new BuyersProductsLogic(BuyersProductsDAO);

        private IBuyersRolesDAO BuyersRolesDAO => new Buyers_RolesSqlDAO();
        public IBuyersRolesLogic BuyersRolesLogic => new BuyersRolesLogic(BuyersRolesDAO);
    }
}
