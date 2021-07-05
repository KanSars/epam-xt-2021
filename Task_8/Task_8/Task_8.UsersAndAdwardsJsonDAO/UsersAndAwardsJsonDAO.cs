using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8.Entities;
using Task_8.DAO.Interfaces;
using System.IO;
using Newtonsoft.Json;

namespace Task_8.DAL.UsersAndAdwardsJsonDAO
{
    public class UsersAndAwardsJsonDAO : IUsersAndAwardsDAO
    {
        //public const string JsonFilesPath = @"C:\Users\Cat Elio\source\repos\NotesManager\Files\"; // TODO изменить
        public const string _pathOfUsers = @"D:\Users.txt";
        Dictionary<int, User> dictOfUsers = new Dictionary<int, User>();

        
        
        public const string _pathofAwards = @"D:\Adwards.txt";
        Dictionary<int, Award> dictOfAwards = new Dictionary<int, Award>();

        public const string _pathOfUsersAwards = @"D:\UsersAdwards.txt";
        // int[] pairOfUsersAwards = new int[2];
        List<int[]> usersAwardsList = new List<int[]>();



        public void AddUserToDict(User newUser)
        {
            Console.WriteLine("Ny vo pervih zapustili");
            //todo throw Exception
            /*
            1. Открыть файл //TODO (с проверкой наличия)
                1.1 если такого нет - создать и положить в него пустой лист
            2. извлечь Лист из файла
            3. добавить нового пользователя //TODO (если такого нет)
            4. пересохранить (перезаписать) файл*/

            if (!File.Exists(_pathOfUsers))
            {
                Console.WriteLine("vo vtorih zapustili");
                dictOfUsers.Add(1, newUser);
                File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));
            }
            else
            {
                var str = File.ReadAllText(_pathOfUsers);

                dictOfUsers = JsonConvert.DeserializeObject<Dictionary<int, User>>(str);

                dictOfUsers.Add(GeneratorIdUser(), newUser);

                File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));
            }
        }

        public void RemoveUserFromDict(int id)
        {
            if (!File.Exists(_pathofAwards))
            {
                //TODO Exception
                return;
            }

            var str = File.ReadAllText(_pathOfUsers);

            dictOfUsers = JsonConvert.DeserializeObject<Dictionary<int, User>>(str);

            dictOfUsers.Remove(id);

            File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));
        }

        public List<User> GetAllUsers()
        {
            List<User> ListOfUsers = new List<User>();
            // проверку на файл 
            // проверку на юзеров



            var str = File.ReadAllText(_pathOfUsers);

            dictOfUsers = JsonConvert.DeserializeObject<Dictionary<int, User>>(str);


            File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));

            //return dictOfUsers;

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
                    dictOfAwards.Add(GeneratorIdAward(), newAward);
                    File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));
                }
                
                dictOfAwards.Add(GeneratorIdAward(), newAward);

                File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));
            }
        }

        int GeneratorIdUser()
        {
            var str = File.ReadAllText(_pathOfUsers);

            dictOfUsers = JsonConvert.DeserializeObject<Dictionary<int, User>>(str);

            return (dictOfUsers.Keys.Max() + 1);
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

        int GeneratorIdAward()
        {
            var str = File.ReadAllText(_pathofAwards);

            dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

            return (dictOfAwards.Keys.Max() + 1);
        }

        public void RemoveAwardFromDict(string title)
        {
            if (!File.Exists(_pathofAwards))
            {
                //TODO Exception
                return;
            }

            //if (IsAwardPreset(dictOfAwards, title)) //можно удалить, т.к. GetIdAwardtoRemove содержит в себе IsAwardPreset через id
            //    return;

            if (GetIdAwardtoRemove(title) != 0)
            {
                var str = File.ReadAllText(_pathofAwards);

                dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

                dictOfAwards.Remove(GetIdAwardtoRemove(title));

                File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));
            }

        }

        int GetIdAwardtoRemove(string title)
        {
            int id = 0;

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



            //var str = File.ReadAllText(_pathOfUsers);

            //dictOfUsers = JsonConvert.DeserializeObject<Dictionary<int, User>>(str);


            //File.WriteAllText(_pathOfUsers, JsonConvert.SerializeObject(dictOfUsers));

            //return dictOfUsers;

            ListOfAwards = dictOfAwards.Values.ToList();

            return ListOfAwards;
        }


        public void AddUserAwardToList(int idOfUser, int idOfAward)
        {
            int[] pairOfUsersAwards = { idOfUser, idOfAward };

            if (!File.Exists(_pathOfUsersAwards))
            {
                usersAwardsList.Add(pairOfUsersAwards);

                File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
            }
            else
            {
                var str = File.ReadAllText(_pathOfUsersAwards);

                usersAwardsList = JsonConvert.DeserializeObject<List<int[]>>(str);

                usersAwardsList.Add(pairOfUsersAwards);

                File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
            }
        }

        public List<Award> GetAllAwards(int idOfUser)
        {
            var str = File.ReadAllText(_pathOfUsersAwards);
            usersAwardsList = JsonConvert.DeserializeObject<List<int[]>>(str);

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
    }
}
