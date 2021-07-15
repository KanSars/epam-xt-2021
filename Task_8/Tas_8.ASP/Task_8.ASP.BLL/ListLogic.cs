using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.ASP.BLL.Interfaces;
using Task_8.ASP.Entities;
using Task_8.ASP.DAO.Interfaces;

namespace Task_8.ASP.BLL
{
    public class ListLogic : IListLogic
    {
        private IUsersAndAwardsDAO _listDAO;

        //private IUsersAndAdwardsDAO _listDAO;

        public ListLogic(IUsersAndAwardsDAO listDao)
        {
            _listDAO = listDao;
        }
        public void AddUserToDict(User user)
        {
            _listDAO.AddUserToDict(user);
        }

        public void RemoveUserFromDict(string nameUser)
        {
            _listDAO.RemoveUserFromDict(nameUser);
        }

        public void RemoveUserFromDict(int idUser)
        {
            _listDAO.RemoveUserFromDict(idUser);
        }

        public void AddAwardToDict(Award award)
        {
            _listDAO.AddAwardToDict(award);
        }

        public void RemoveAwardFromDict(string title)
        {
            _listDAO.RemoveAwardFromDict(title);
        }

        public List<User> GetAllUsers()
        {
            return _listDAO.GetAllUsers();
        }

        public void AddUserAwardToList(int idOfUser, string title)
        {
            _listDAO.AddUserAwardToList(idOfUser, title);
        }

        public List<Award> GetAllAwards() // перечень всех наград
        {
            return _listDAO.GetAllAwards();
        }

        public List<Award> GetAllAwardsOfUser(int idOfUser) // перечень наград для определенного пользователя
        {
            return _listDAO.GetAllAwardsOfUser(idOfUser);
        }

        public Dictionary<string, List<string>> GetAllAwardedUsers()
        {
            return _listDAO.GetAllAwardedUsers();
        }

        public User GetUserById(int idUser)
        {
            return _listDAO.GetUserById(idUser);
        }

        public void EditUser(int id, User user)
        {
            _listDAO.EditUser(id, user);
        }

        public Dictionary<int, User> GetDictOfAllUsers()
        {
            return _listDAO.GetDictOfAllUsers();
        }

    }
}
