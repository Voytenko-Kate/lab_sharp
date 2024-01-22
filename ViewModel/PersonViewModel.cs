using PodsystemaFizLicz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.ViewModel
{
    internal class PersonViewModel
    {
        public ObservableCollection<Person> Persons { get; set; } = new ObservableCollection<Person>();

        public PersonViewModel() 
        {
            Persons.Add(
                new Person()
                {
                    Id = 1,
                    Shifer = "safk5467-asf567-ds54",
                    Inn = "123456789012",
                    Type = PersonType.NaturalPerson,
                    Data = new DateTime(2010, 02, 28)
                });
            Persons.Add(
                new Person()
                {
                    Id = 2,
                    Shifer = "safk5467-das87-ds54",
                    Inn = "123456789031",
                    Type = PersonType.NaturalPerson,
                    Data = new DateTime(2011, 03, 20)
                });
            Persons.Add(
                new Person()
                {
                    Id = 3,
                    Shifer = "safk5467-asf567-878dsf",
                    Inn = "012345678912",
                    Type = PersonType.NaturalPerson,
                    Data = new DateTime(2015, 04, 15)
                });
            Persons.Add(
                new Person()
                {
                    Id = 4,
                    Shifer = "a7897gsd-asf567-ds54",
                    Inn = "012345678931",
                    Type = PersonType.NaturalPerson,
                    Data = new DateTime(2005, 05, 10)
                });
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var item in Persons)
            {
                if (max < item.Id)
                {
                    max = item.Id;
                };
            }
            return max;
        }
    }
}
