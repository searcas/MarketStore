using System;
using System.Collections.Generic;
using System.Text;

namespace MarketStore
{
    class Client
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public Cards Card { get; set; }
        public Client(string Name, string Surname, string DateOfBirth, string PhoneNumber,Cards cards)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.DateOfBirth = DateOfBirth;
            this.PhoneNumber = PhoneNumber;
            Card = cards;
        }
    }
}
