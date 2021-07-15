using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marketplace.Entities;
using Marketplace.DAO.Interfaces;
using System.IO;
using Newtonsoft.Json;

//TODO проверки (Exceptions) (наличие файлов а так же данных в них, входные параметры функций и пр.)

namespace Marketplace.BuyersProductsJsonDAO
{
    public class BuyersDAO
    {
        public const string _pathOfBuyers = @"D:\Buyers.txt";
        Dictionary<int, Buyer> dictOfBuyrs = new Dictionary<int, Buyer>();


        public void AddBuyerToDict(Buyer newBuyer) // ошибка если файл чист
        {
            if (!File.Exists(_pathOfBuyers))
            {
                //newBuyer.Id = 1; //у покупателей будет только внешний Id, в качестве поля ни к чему
                dictOfBuyrs.Add(1, newBuyer);
                File.WriteAllText(_pathOfBuyers, JsonConvert.SerializeObject(dictOfBuyrs));
            }
            else
            {
                dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

                int newId = GeneratorIdBuyer();

                //newBuyer.Id = newId; //TODO

                dictOfBuyrs.Add(newId, newBuyer); // нехорошо это - лучше конструктор использовать у сущности

                File.WriteAllText(_pathOfBuyers, JsonConvert.SerializeObject(dictOfBuyrs));
            }
        }

        public Dictionary<int, Buyer> GetDictOfBuyers(string path)
        {
            var str = File.ReadAllText(path);

            return JsonConvert.DeserializeObject<Dictionary<int, Buyer>>(str);
        }

        //public void RemoveUserFromDict(string nameUser)
        //{
        //    int id = GetIdForRemove(nameUser);
        //    if (!File.Exists(_pathofAwards))
        //    {
        //        //TODO Exception
        //        return;
        //    }

        //    dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

        //    dictOfBuyrs.Remove(id);

        //    File.WriteAllText(_pathOfBuyers, JsonConvert.SerializeObject(dictOfBuyrs));

        //    usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);

        //    for (int i = usersAwardsList.Count - 1; i > -1; i--)
        //    {
        //        if (usersAwardsList[i][0] == id)
        //        {
        //            var elemToRemove = usersAwardsList[i];
        //            usersAwardsList.Remove(elemToRemove);
        //        }

        //    }

        //    File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
        //}

        //public List<int[]> GetUsersAwardsList(string path)
        //{
        //    var str2 = File.ReadAllText(path);

        //    return JsonConvert.DeserializeObject<List<int[]>>(str2);
        //}

        //public void RemoveUserFromDict(int idUser)
        //{
        //    int id = idUser;
        //    if (!File.Exists(_pathofAwards))
        //    {
        //        //TODO Exception
        //        return;
        //    }

        //    dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

        //    dictOfBuyrs.Remove(id);

        //    File.WriteAllText(_pathOfBuyers, JsonConvert.SerializeObject(dictOfBuyrs));

        //    usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);


        //    for (int i = usersAwardsList.Count - 1; i > -1; i--)
        //    {
        //        if (usersAwardsList[i][0] == id)
        //        {
        //            var elemToRemove = usersAwardsList[i];
        //            usersAwardsList.Remove(elemToRemove);
        //        }

        //    }

        //    File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
        //}

        //public int GetIdForRemove(string nameUser)
        //{
        //    int id = 0;

        //    dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

        //    foreach (var item in dictOfBuyrs)
        //    {
        //        if (item.Value.Name == nameUser)
        //        {
        //            id = item.Key;
        //        }
        //    }
        //    return id;
        //}

        //public List<Buyer> GetAllUsers()
        //{
        //    List<Buyer> ListOfUsers = new List<Buyer>();
        //    // проверку на файл 
        //    // проверку на юзеров

        //    dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);


        //    File.WriteAllText(_pathOfBuyers, JsonConvert.SerializeObject(dictOfBuyrs));

        //    ListOfUsers = dictOfBuyrs.Values.ToList();

        //    return ListOfUsers;
        //}

        //public void AddAwardToDict(Award newAward)
        //{
        //    if (!File.Exists(_pathofAwards))
        //    {
        //        dictOfAwards.Add(1, newAward);
        //        File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));
        //    }
        //    else
        //    {
        //        var str = File.ReadAllText(_pathofAwards);

        //        dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

        //        if (IsAwardPreset(dictOfAwards, newAward.Title))
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            int newId = GeneratorIdAward(); //TODO использовать ID удаленных наград

        //            dictOfAwards.Add(newId, newAward);
        //            File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));
        //        }
        //    }
        //}

        int GeneratorIdBuyer()
        {
            dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

            int newId = dictOfBuyrs.Keys.Max() + 1;

            return newId;
        }

        //bool IsAwardPreset(Dictionary<int, Award> dictOfAwards, string title)
        //{
        //    bool awardClone = false;

        //    foreach (var item in dictOfAwards)
        //    {
        //        if (item.Value.Title == title)
        //            awardClone = true;
        //    }
        //    return awardClone;
        //}

        //int GeneratorIdAward() //после удаления награды из списка старые Id (удалненной награды) в дальнейшем не используются
        //{
        //    var str = File.ReadAllText(_pathofAwards);

        //    dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

        //    int newId = dictOfAwards.Keys.Max() + 1;

        //    return newId;
        //}

        //public void RemoveAwardFromDict(string title)
        //{
        //    if (!File.Exists(_pathofAwards))
        //    {
        //        //TODO Exception
        //        return;
        //    }

        //    int idAward = GetIdAwardByTitle(title);

        //    if (idAward != 0)
        //    {
        //        var str = File.ReadAllText(_pathofAwards);

        //        dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

        //        int keyForRemoving = GetIdAwardByTitle(title); // без данной переменной Remove не срабатывает

        //        dictOfAwards.Remove(keyForRemoving);

        //        File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));

        //        usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);


        //        for (int i = usersAwardsList.Count - 1; i > -1; i--)
        //        {
        //            if (usersAwardsList[i][1] == idAward)
        //            {
        //                var elemToRemove = usersAwardsList[i];
        //                usersAwardsList.Remove(elemToRemove);
        //            }

        //        }
        //        File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
        //    }
        //}

        //public int GetIdAwardByTitle(string title)
        //{
        //    int id = 0;

        //    var str = File.ReadAllText(_pathofAwards);

        //    dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

        //    foreach (var item in dictOfAwards)
        //    {
        //        if (item.Value.Title == title)
        //        {
        //            id = item.Key;
        //        }
        //    }
        //    return id;
        //}

        //public List<Award> GetAllAwards()
        //{
        //    List<Award> ListOfAwards = new List<Award>();
        //    // проверку на файл 
        //    // проверку на юзеров


        //    var str = File.ReadAllText(_pathofAwards);

        //    dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);


        //    File.WriteAllText(_pathofAwards, JsonConvert.SerializeObject(dictOfAwards));

        //    ListOfAwards = dictOfAwards.Values.ToList();

        //    return ListOfAwards;
        //}


        //public void AddUserAwardToList(int idOfUser, string title)
        //{
        //    var str = File.ReadAllText(_pathofAwards);

        //    dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str);

        //    if (!IsAwardPreset(dictOfAwards, title))
        //    {
        //        Award newAward = new Award(title);

        //        AddAwardToDict(newAward);
        //    }

        //    int idOfAward = GetIdAwardByTitle(title);

        //    int[] pairOfUsersAwards = { idOfUser, idOfAward };

        //    if (!File.Exists(_pathOfUsersAwards))
        //    {
        //        usersAwardsList.Add(pairOfUsersAwards);

        //        File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
        //    }
        //    else
        //    {
        //        usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);

        //        usersAwardsList.Add(pairOfUsersAwards);

        //        File.WriteAllText(_pathOfUsersAwards, JsonConvert.SerializeObject(usersAwardsList));
        //    }
        //}


        //public List<Award> GetAllAwardsOfUser(int idOfUser)
        //{
        //    usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);

        //    var str2 = File.ReadAllText(_pathofAwards);
        //    dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str2);

        //    List<Award> userHasAwardsList = new List<Award>();

        //    foreach (var item in usersAwardsList)
        //    {
        //        if (item[0] == idOfUser)
        //        {
        //            userHasAwardsList.Add(dictOfAwards[item[1]]);
        //        }
        //    }
        //    return userHasAwardsList;
        //}

        //public Dictionary<string, List<string>> GetAllAwardedUsers()
        //{
        //    Dictionary<string, List<string>> awardedUsersDict = new Dictionary<string, List<string>>();

        //    dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

        //    foreach (var item in dictOfBuyrs)
        //    {
        //        string itemValueName = item.Value.Name;
        //        awardedUsersDict.Add(item.Key.ToString(), GetAwardsOfUserList(item.Key));
        //    }

        //    return awardedUsersDict;
        //}

        //public List<string> GetAwardsOfUserList(int idUser)
        //{
        //    List<string> awardsOfUserList = new List<string>();

        //    usersAwardsList = GetUsersAwardsList(_pathOfUsersAwards);

        //    foreach (var item in usersAwardsList)
        //    {
        //        if (item[0] == idUser)
        //        {
        //            awardsOfUserList.Add(GetTitleByIdAward(item[1]));
        //        }
        //    }
        //    return awardsOfUserList;
        //}

        //public string GetTitleByIdAward(int idAward)
        //{
        //    var str2 = File.ReadAllText(_pathofAwards);
        //    dictOfAwards = JsonConvert.DeserializeObject<Dictionary<int, Award>>(str2);

        //    string title = dictOfAwards[idAward].Title;

        //    return title;
        //}

        //public Buyer GetUserById(int idUser)
        //{
        //    Buyer Buyer = null;

        //    if (!File.Exists(_pathofAwards))
        //    {
        //        //TODO Exception
        //    }

        //    dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

        //    foreach (var item in dictOfBuyrs)
        //    {
        //        if (item.Key == idUser)
        //        {
        //            Buyer = item.Value;
        //        }
        //    }
        //    return Buyer;
        //}

        //public void EditUser(int id, Buyer Buyer)
        //{
        //    dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

        //    dictOfBuyrs[id] = Buyer;

        //    string output = Newtonsoft.Json.JsonConvert.SerializeObject(dictOfBuyrs, Newtonsoft.Json.Formatting.None);

        //    File.WriteAllText(_pathOfBuyers, output);
        //}

        //public Dictionary<int, Buyer> GetDictOfAllUsers()
        //{
        //    dictOfBuyrs = GetDictOfBuyers(_pathOfBuyers);

        //    return dictOfBuyrs;
        //}
    }
}
