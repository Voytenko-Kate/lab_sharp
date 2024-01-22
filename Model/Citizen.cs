using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.Model
{
    internal class Citizen
    {
        public int Id { get; set; }
        public int DocumentID { get; set; }
        public int PersonID { get; set; }
        public string FirstName { get; set; }
        // фамилия
        public string SecondName { get; set; }
        // отчество 
        public string LastName { get; set; }
        public string Number { get; set; }

        public Citizen() { }

        public Citizen(int id, int documentID, int personID, string firstName, string secondName, string lastName, string number)
        {
            Id = id;
            DocumentID = documentID;
            PersonID = personID;
            FirstName = firstName;
            SecondName = secondName;
            LastName = lastName;
            Number = number;
        }
    }
}
