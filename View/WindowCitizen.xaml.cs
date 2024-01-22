using PodsystemaFizLicz.Helper;
using PodsystemaFizLicz.Model;
using PodsystemaFizLicz.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace PodsystemaFizLicz.View
{
    /// <summary>
    /// Логика взаимодействия для WindowCitizen.xaml
    /// </summary>
    public partial class WindowCitizen : Window
    {
        public WindowCitizen()
        {
            InitializeComponent();

            CitizenViewModel viewModel = new CitizenViewModel();
            DocumentViewModel documentViewModel = new DocumentViewModel();
            PersonViewModel personViewModel = new PersonViewModel();

            List<Document> documents = documentViewModel.Documents.ToList();
            List<Person> persons = personViewModel.Persons.ToList();

            ObservableCollection<CitizenDPO> citizens = new ObservableCollection<CitizenDPO>();
            FindDocument findDocument;
            FindPerson findPerson;

            foreach(var c in viewModel.Citizens)
            {
                findDocument = new FindDocument(c.DocumentID);
                Document? doc = documents.Find(findDocument.DocumentPredicate);

                findPerson = new FindPerson(c.PersonID);
                Person? person = persons.Find(findPerson.PersonPredicate);

                citizens.Add(
                    new CitizenDPO()
                    {
                        Id = c.Id,
                        Document = doc.Name,
                        Person = person.Inn,
                        FirstName = c.FirstName,
                        SecondName = c.SecondName,
                        LastName = c.LastName,
                        Number = c.Number,
                    });

            }
            lvCitizen.ItemsSource = citizens;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
