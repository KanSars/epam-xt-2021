using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.BLL.Interfaces;
using Task_8.Entities;
using Task_8.DAO.Interfaces;

namespace Task_8.BLL
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

        public void RemoveUserFromDict(int id)
        {
            _listDAO.RemoveUserFromDict(id);
        }

        public void AddAwardToDict(int id, Award award)
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

        public void AddUserAwardToList(int idOfUser, int idOfAward)
        {
            _listDAO.AddUserAwardToList(idOfUser, idOfAward);
        }

        public List<Award> GetAllAwards() // перечень всех наград
        {
            return _listDAO.GetAllAwards();
        }

        public List<Award> GetAllAwards(int idOfUser) // перечень наград для определенного пользователя
        {
            return _listDAO.GetAllAwards();
        }

    }
}
