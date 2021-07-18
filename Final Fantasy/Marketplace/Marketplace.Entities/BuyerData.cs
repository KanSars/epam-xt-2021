using System;

namespace Marketplace.Entities
{
    public class BuyerData
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public DateTime DoB { get; private set; }
        public string Email { get; private set; }

        public BuyerData()
        {
        }

        public BuyerData(int id, string name, string surname, DateTime doB, string email)
        {
            Id = id;
            Name = name;
            Surname = surname;
            DoB = doB;
            Email = email;
        }
        public BuyerData(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
