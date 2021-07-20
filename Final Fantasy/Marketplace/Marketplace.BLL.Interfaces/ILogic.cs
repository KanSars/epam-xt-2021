using Marketplace.Entities;

namespace Marketplace.BLL.Interfaces
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
        void AddBuyerToDict(Buyer buyer);

        //void RemoveUserFromDict(string nameUser);
        //void RemoveUserFromDict(int idUser);

        //List<User> GetAllUsers();

        //void AddAwardToDict(Award award);

        //void RemoveAwardFromDict(string title);

        //List<Award> GetAllAwards();

        //void AddUserAwardToList(int idOfUser, string title);

        //List<Award> GetAllAwardsOfUser(int idOfUser);

        //Dictionary<string, List<string>> GetAllAwardedUsers();

        //User GetUserById(int idUser);

        //void EditUser(int id, User user);

        //Dictionary<int, User> GetDictOfAllUsers();

    }
}
