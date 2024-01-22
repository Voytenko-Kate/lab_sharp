using PodsystemaFizLicz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.ViewModel
{
    internal class CitizenViewModel
    {
        public ObservableCollection<Citizen> Citizens { get; set; } = new ObservableCollection<Citizen>();

        public CitizenViewModel()
        {
            Citizens.Add(
                new Citizen()
                {
                    Id = 1,
                    PersonID = 1,
                    DocumentID = 1,
                    FirstName  = "Иван",
                    SecondName = "Иванов",
                    LastName = "Иванович",
                    Number = "544798"
                });
            Citizens.Add(
                new Citizen()
                {
                    Id = 2,
                    PersonID = 2,
                    DocumentID = 2,
                    FirstName = "Петр",
                    SecondName = "Петров",
                    LastName = "Петрович",
                    Number = "544798"
                });
            Citizens.Add(
                new Citizen()
                {
                    Id = 3,
                    PersonID = 3,
                    DocumentID = 3,
                    FirstName = "Виктор",
                    SecondName = "Викторов",
                    LastName = "Викторович",
                    Number = "544798"
                });
            Citizens.Add(
                new Citizen()
                {
                    Id = 4,
                    PersonID = 4,
                    DocumentID = 4,
                    FirstName = "Сидор",
                    SecondName = "Сидоров",
                    LastName = "Сидорович",
                    Number = "544798"
                });
        }

        public int MaxId()
        {
            int max = 0;
            foreach (var item in Citizens)
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
