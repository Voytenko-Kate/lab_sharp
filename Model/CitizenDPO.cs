using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.Model
{
    internal class CitizenDPO
    {
        public int Id { get; set; }
        public string Document { get; set; }
        public string Person { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }

        public CitizenDPO() { }

        public CitizenDPO(int id, string document, string inn, string firstName, string secondName, string lastName, string number)
        {
            Id = id;
            Document = document;
            Person = inn;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            Number = number;
        }
    }
}
