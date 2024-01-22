using PodsystemaFizLicz.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PodsystemaFizLicz.ViewModel
{
    internal class DocumentViewModel
    {
        public ObservableCollection<Document> Documents { get; set; } = new ObservableCollection<Document>();

        public DocumentViewModel() 
        {
            Documents.Add(
                new Document()
                {
                    Id = 1,
                    Name = "Test",
                    Seriy = "1232 4564",
                    Organ = "ГУ МВД",
                    Data = new DateTime(2023, 5, 17)
                });
            Documents.Add(
                new Document()
                {
                    Id = 2,
                    Name = "Test1",
                    Seriy = "6445 4564",
                    Organ = "ГУ МВД",
                    Data = new DateTime(2022, 2, 10)
                });
            Documents.Add(
                new Document()
                {
                    Id = 3,
                    Name = "Test2",
                    Seriy = "8979 4564",
                    Organ = "ГУ МВД",
                    Data = new DateTime(2020, 6, 20)
                });
            Documents.Add(
                new Document()
                {
                    Id = 4,
                    Name = "Test3",
                    Seriy = "45 6546 65489",
                    Organ = "ГУ МВД",
                    Data = new DateTime(2021, 11, 22)
                });
        }
        public int MaxId()
        {
            int max = 0;
            foreach (var item in Documents)
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
