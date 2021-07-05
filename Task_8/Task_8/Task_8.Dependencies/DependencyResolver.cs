using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.BLL.Interfaces;
using Task_8.BLL;
using Task_8.DAO.Interfaces;
using Task_8.DAL.UsersAndAdwardsJsonDAO;

namespace Task_8.Dependencies
{
    public class DependencyResolver
    {
        public static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                return _instance ??= new DependencyResolver();
            }
        }

        public IUsersAndAwardsDAO UsersAndAdwardsDAO => new UsersAndAwardsJsonDAO();
        public IListLogic ListLogic => new ListLogic(UsersAndAdwardsDAO); /*ссылка на интерфейс DAO*/
    }
}
