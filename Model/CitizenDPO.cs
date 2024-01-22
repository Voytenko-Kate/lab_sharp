using PodsystemaFizLicz.ViewModel;
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

        public CitizenDPO CopyFromCitizen(Citizen citizen)
        {
            CitizenDPO citizenDPO = new CitizenDPO();
            PersonViewModel person = new PersonViewModel();
            string personInn = string.Empty;
            foreach (var p in person.Persons)
            {
                if (p.Id == citizen.PersonID)
                {
                    personInn = p.Inn;
                    break;
                }
            }

            DocumentViewModel document = new DocumentViewModel();
            string doc = string.Empty;
            foreach (var d in document.Documents)
            {
                if (d.Id == citizen.DocumentID)
                {
                    doc = d.Name;
                    break;
                }
            }

            if (personInn != string.Empty && doc != string.Empty)
            {
                citizenDPO.Id = citizen.Id;
                citizenDPO.Person = personInn;
                citizenDPO.Document = doc;
                citizenDPO.FirstName = citizen.FirstName;
                citizenDPO.LastName = citizen.LastName;
                citizenDPO.SecondName = citizen.SecondName;
                citizenDPO.Number = citizen.Number;
            }
            return citizenDPO;
        }

        public CitizenDPO ShallowCopy()
        {
            return (CitizenDPO)this.MemberwiseClone();
        }
    }
}
