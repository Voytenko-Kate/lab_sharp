using PodsystemaFizLicz.ViewModel;
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

        public Citizen CopyFromCitizenDPO(CitizenDPO p)
        {
            PersonViewModel person = new PersonViewModel();
            int personId = 0;
            foreach (var r in person.Persons)
            {
                if (r.Inn == p.Person)
                {
                    personId = r.Id;
                    break;
                }
            }

            DocumentViewModel document = new DocumentViewModel();
            int documentId = 0;
            foreach (var r in document.Documents)
            {
                if (r.Name == p.Document)
                {
                    documentId = r.Id;
                    break;
                }
            }

            if (personId != 0 && documentId != 0)
            {
                this.Id = p.Id;
                this.PersonID = personId;
                this.DocumentID = documentId;
                this.FirstName = p.FirstName;
                this.LastName = p.LastName;
                this.Number = p.Number;
            }
            return this;
        }
    }
}
