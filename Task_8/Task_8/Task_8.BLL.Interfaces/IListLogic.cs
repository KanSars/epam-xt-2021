using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;

namespace Task_8.BLL.Interfaces
{
    public interface IListLogic
    {
        /*... позволяющую работать со списком пользователей (User: Id, Name, DateOfBirth, Age): 
        1. создавать пользователей 
        2. удалять пользователей
        3. запрашивать их перечень
        
        Добавьте сущность «Награда» (Award: Id, Title) и реализуйте соответствующие механизмы для
        1. добавления наград 
        2. запроса перечня наград*/
        public void AddUserToDict(User user);

        public void RemoveUserFromDict(int id);

        public List<User> GetAllUsers();

        public void AddAwardToDict(int id, Award award);

        public void RemoveAwardFromDict(string title);

        public List<Award> GetAllAwards();

        public void AddUserAwardToList(int idOfUser, int idOfAward);

        public List<Award> GetAllAwards(int idOfUser);

    }
}
