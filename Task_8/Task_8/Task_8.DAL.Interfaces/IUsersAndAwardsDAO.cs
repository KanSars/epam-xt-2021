using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.DAO.Interfaces
{
    public interface IUsersAndAwardsDAO
    {
        public void AddUserToDict(User user);

        public void RemoveUserFromDict(int id);

        public List<User> GetAllUsers();

        public void AddAwardToDict(Award award);

        public List<Award> GetAllAwards();

        public void RemoveAwardFromDict(string title);

        public void AddUserAwardToList(int idOfUser, int idOfAward);

        public List<Award> GetAllAwards(int idOfUser);
    }
}
