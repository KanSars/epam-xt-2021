using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.ASP.BLL.Interfaces;
using Task_8.ASP.BLL;
using Task_8.ASP.DAO.Interfaces;
//using Task_8.ASP.DAL.UsersAndAdwardsJsonDAO;
using Task_8.ASP.DAL.UsersAndAdwardsJsonDAO;

namespace Task_8.ASP.Dependencies
{
    public class DependencyResolver
    {
        public static DependencyResolver _instance;

        public static DependencyResolver Instance
        {
            get
            {
                return _instance = new DependencyResolver(); //добавит проверку ??=
            }
        }

        public IUsersAndAwardsDAO UsersAndAdwardsDAO => new UsersAndAwardsJsonDAO();
        public IListLogic ListLogic => new ListLogic(UsersAndAdwardsDAO); /*ссылка на интерфейс DAO*/
    }
}
