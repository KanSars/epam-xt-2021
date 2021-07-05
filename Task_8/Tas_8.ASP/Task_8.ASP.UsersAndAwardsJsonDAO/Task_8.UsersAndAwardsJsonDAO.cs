using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.ASP.Entities;
using Task_8.ASP.DAO.Interfaces;
using System.IO;
using Newtonsoft.Json;

//TODO проверки (Exceptions) (наличие файлов а так же данных в них, входные параметры функций и пр.)

namespace Task_8.ASP.DAL.UsersAndAdwardsJsonDAO
{
    public class UsersAndAwardsJsonDAO : IUsersAndAwardsDAO
    {
        public const string _pathOfUsers = @"D:\Users.txt";
        Dictionary<int, User> dictOfUsers = new Dictionary<int, User>();

        public const string _pathofAwards = @"D:\Awards.txt";
        Dictionary<int, Award> dictOfAwards = new Dictionary<int, Award>();

        public const string _pathOfUsersAwards = @"D:\UsersAwards.txt";
        List<int[]> usersAwardsList = new List<int[]>();



        public void AddUserToDict(User newUser)
        {
            if (!File.Exists(_pathOfUsers))
            {
                newUser.Id = 1;
                dictOfUsers.Add(1, newUser);
                File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));
            }
            else
            {
                dictOfUsers = GetDictOfUsers(_pathOfUsers);

                int newId = GeneratorIdUser();

                newUser.Id = newId; //TODO

                dictOfUsers.Add(newId, newUser);

                File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));
            }
        }

        public Dictionary<int, User> GetDictOfUsers(string path)
        {
            var str = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<Dictionary<int, User>>(str);
        }

        public void RemoveUserFromDict(string nameUser)
        {
            int id = GetIdForRemove(nameUser);
            if (!File.Exists(_pathofAwards))
            {
                //TODO Exception
                return;
            }

            dictOfUsers = GetDictOfUsers(_pathOfUsers);

            dictOfUsers.Remove(id);

            File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));

            usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);

            for (int i = usersAwardsList.Count - 1; i > -1; i--)
            {
                if (usersAwardsList[i][0] == id)
                {
                    var elemToRemove = usersAwardsList[i];
                    usersAwardsList.Remove(elemToRemove);
                }

            }

            File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
        }

        public List<int[]> GetUsersAwardsList(string path)
        {
            var str2 = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<List<int[]>>(str2);
        }

        public void RemoveUserFromDict(int idUser)
        {
            int id = idUser;
            if (!File.Exists(_pathofAwards))
            {
                //TODO Exception
                return;
            }

            dictOfUsers = GetDictOfUsers(_pathOfUsers);

            dictOfUsers.Remove(id);

            File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));

            usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);


            for (int i = usersAwardsList.Count - 1; i > -1; i--)
            {
                if (usersAwardsList[i][0] == id)
                {
                    var elemToRemove = usersAwardsList[i];
                    usersAwardsList.Remove(elemToRemove);
                }

            }

            File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
        }

        public int GetIdForRemove(string nameUser)
        {
            int id = 0;

            dictOfUsers = GetDictOfUsers(_pathOfUsers);

            foreach (var item in dictOfUsers)
            {
                if (item.Value.Name == nameUser)
                {
                    id = item.Key;
                }
            }
            return id;
        }

        public List<User> GetAllUsers()
        {
            List<User> ListOfUsers = new List<User>();
            // проверку на файл 
            // проверку на юзеров

            dictOfUsers = GetDictOfUsers(_pathOfUsers);


            File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));

            ListOfUsers = dictOfUsers.Values.ToList();

            return ListOfUsers;
        }

        public void AddAwardToDict(Award newAward)
        {
            if (!File.Exists(_pathofAwards))
            {
                dictOfAwards.Add(1, newAward);
                File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));
            }
            else
            {
                var str = File.ReadAllText(_pathofAwards);

                dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

                if (IsAwardPreset(dictOfAwards, newAward.Title))
                {
                    return;
                }
                else
                {
                    int newId = GeneratorIdAward(); //TODO использовать ID удаленных наград

                    dictOfAwards.Add(newId, newAward);
                    File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));
                }
            }
        }

        int GeneratorIdUser()
        {
            dictOfUsers = GetDictOfUsers(_pathOfUsers);

            int newId = dictOfUsers.Keys.Max() + 1;

                return newId;
        }

        bool IsAwardPreset(Dictionary<int, Award> dictOfAwards, string title)
        {
            bool awardClone = false;

            foreach (var item in dictOfAwards)
            {
                if (item.Value.Title == title)
                    awardClone = true;
            }
            return awardClone;
        }

        int GeneratorIdAward() //после удаления награды из списка старые Id (удалненной награды) в дальнейшем не используются
        {
            var str = File.ReadAllText(_pathofAwards);

            dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

            int newId = dictOfAwards.Keys.Max() + 1;

            return newId;
        }

        public void RemoveAwardFromDict(string title)
        {
            if (!File.Exists(_pathofAwards))
            {
                //TODO Exception
                return;
            }

            int idAward = GetIdAwardByTitle(title);

            if (idAward != 0)
            {
                var str = File.ReadAllText(_pathofAwards);

                dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

                int keyForRemoving = GetIdAwardByTitle(title); // без данной переменной Remove не срабатывает

                dictOfAwards.Remove(keyForRemoving);

                File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));

                usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);


                for (int i = usersAwardsList.Count - 1; i > -1; i--)
                {
                    if (usersAwardsList[i][1] == idAward)
                    {
                        var elemToRemove = usersAwardsList[i];
                        usersAwardsList.Remove(elemToRemove);
                    }

                }
                File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
            }
        }

        public int GetIdAwardByTitle(string title)
        {
            int id = 0;

            var str = File.ReadAllText(_pathofAwards);

            dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

            foreach (var item in dictOfAwards)
            {
                if (item.Value.Title == title)
                {
                    id = item.Key;
                }
            }
            return id;
        }

        public List<Award> GetAllAwards()
        {
            List<Award> ListOfAwards = new List<Award>();
            // проверку на файл 
            // проверку на юзеров


            var str = File.ReadAllText(_pathofAwards);

            dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);


            File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));

            ListOfAwards = dictOfAwards.Values.ToList();

            return ListOfAwards;
        }


        public void AddUserAwardToList(int idOfUser, string title)
        {
            var str = File.ReadAllText(_pathofAwards);

            dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

            if (!IsAwardPreset(dictOfAwards, title))
            {
                Award newAward = new Award(title);

                AddAwardToDict(newAward);
            }

            int idOfAward = GetIdAwardByTitle(title);

            int[] pairOfUsersAwards = { idOfUser, idOfAward };

            if (!File.Exists(_pathOfUsersAwards))
            {
                usersAwardsList.Add(pairOfUsersAwards);

                File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
            }
            else
            {
                usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);

                usersAwardsList.Add(pairOfUsersAwards);

                File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
            }
        }


        public List<Award> GetAllAwardsOfUser(int idOfUser)
        {
            usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);

            var str2 = File.ReadAllText(_pathofAwards);
            dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str2);

            List<Award> userHasAwardsList = new List<Award>();

            foreach (var item in usersAwardsList)
            {
                if (item[0] == idOfUser)
                {
                    userHasAwardsList.Add(dictOfAwards[item[1]]);
                }
            }
            return userHasAwardsList;
        }

        public Dictionary<string, List<string>> GetAllAwardedUsers()
        {
            Dictionary<string, List<string>> awardedUsersDict = new Dictionary<string, List<string>>();

            dictOfUsers = GetDictOfUsers(_pathOfUsers);

            foreach (var item in dictOfUsers)
            {
                string itemValueName = item.Value.Name;
                awardedUsersDict.Add(item.Key.ToString(), GetAwardsOfUserList(item.Key));
            }

            return awardedUsersDict;
        }

        public List<string> GetAwardsOfUserList(int idUser)
        {
            List<string> awardsOfUserList = new List<string>();

            usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);

            foreach (var item in usersAwardsList)
            {
                if (item[0] == idUser)
                {
                    awardsOfUserList.Add(GetTitleByIdAward(item[1]));
                }
            }
            return awardsOfUserList;
        }

        public string GetTitleByIdAward(int idAward)
        {
            var str2 = File.ReadAllText(_pathofAwards);
            dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str2);

            string title = dictOfAwards[idAward].Title;

            return title;
        }

        public User GetUserById(int idUser)
        {
            User user = null;

            if (!File.Exists(_pathofAwards))
            {
                //TODO Exception
            }

            dictOfUsers = GetDictOfUsers(_pathOfUsers);

            foreach (var item in dictOfUsers)
            {
                if (item.Key == idUser)
                {
                    user = item.Value;
                }
            }
            return user;
        }

        public void EditUser(int id, User user)
        {
            dictOfUsers = GetDictOfUsers(_pathOfUsers);

            dictOfUsers[id] = user;

            string output = Newtonsoft.Json.JsonConvert.SerializeObject(dictOfUsers, Newtonsoft.Json.Formatting.None);
           
            File.WriteAllText(_pathOfUsers, output);
        }

        public Dictionary<int, User> GetDictOfAllUsers()
        {
            dictOfUsers = GetDictOfUsers(_pathOfUsers);

            return dictOfUsers;
        }
    }
}
