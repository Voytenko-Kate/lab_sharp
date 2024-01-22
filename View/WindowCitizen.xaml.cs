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
        CitizenViewModel viewModel;
        DocumentViewModel documentViewModel;
        ObservableCollection<CitizenDPO> citizens;
        PersonViewModel personViewModel;
        List<Document> documents;
        List<Person> persons;
        public WindowCitizen()
        {
            InitializeComponent();

            viewModel = new CitizenViewModel();
            documentViewModel = new DocumentViewModel();
            personViewModel = new PersonViewModel();

            documents = documentViewModel.Documents.ToList();
            persons = personViewModel.Persons.ToList();

            citizens = new ObservableCollection<CitizenDPO>();

            foreach(var c in viewModel.Citizens)
            {
                CitizenDPO citizenDPO = new CitizenDPO();
                citizenDPO = citizenDPO.CopyFromCitizen(c);
                citizens.Add(citizenDPO);
            }
            lvCitizen.ItemsSource = citizens;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCitizen wnModel = new WindowNewCitizen
            {
                Title = "Новое физ. лицо",
                Owner = this
            };

            int maxId = viewModel.MaxId() + 1;
            CitizenDPO model = new CitizenDPO
            {
                Id = maxId
            };

            wnModel.DataContext = model;
            wnModel.CbDocumentID.ItemsSource = documents;
            wnModel.CbPersonID.ItemsSource = persons;
            if (wnModel.ShowDialog() == true)
            {
                Person p =  (Person)wnModel.CbPersonID.SelectedValue;
                model.Person = p.Inn;
                citizens.Add(model);

                Citizen citizen = new Citizen();
                citizen = citizen.CopyFromCitizenDPO(model);
                viewModel.Citizens.Add(citizen);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewCitizen wnModel = new WindowNewCitizen
            {
                Title = "Редактирование данных",
                Owner = this
            };

            CitizenDPO model = (CitizenDPO)lvCitizen.SelectedValue;
            CitizenDPO citizenTemp;
            if (model != null)
            {
                citizenTemp = model.ShallowCopy();
                wnModel.DataContext = citizenTemp;
                wnModel.CbDocumentID.ItemsSource = documents;
                wnModel.CbPersonID.ItemsSource = persons;
                wnModel.CbPersonID.Text = citizenTemp.Person;
                wnModel.CbDocumentID.Text = citizenTemp.Document;

                if (wnModel.ShowDialog() == true)
                {
                    // перенос данных из временного класса в класс отображения данных
                    Document document = wnModel.CbDocumentID.SelectedValue as Document;
                    Person person = wnModel.CbPersonID.SelectedValue as Person;
                    model.Person = person.Inn;
                    model.Document = document.Name;
                    model.FirstName = citizenTemp.FirstName;
                    model.SecondName = citizenTemp.SecondName;
                    model.LastName = citizenTemp.LastName;
                    model.Number = citizenTemp.Number;

                    lvCitizen.ItemsSource = null;
                    lvCitizen.ItemsSource = citizens;

                    // перенос данных из класса отображения данных в класс Citizen
                    FindCitizen finder = new FindCitizen(model.Id);
                    List<Citizen> listPerson = viewModel.Citizens.ToList();
                    Citizen p = listPerson.Find(new Predicate<Citizen>(finder.CitizenPredicate));
                    p = p.CopyFromCitizenDPO(model);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать физ. лицо для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            CitizenDPO model = (CitizenDPO)lvCitizen.SelectedItem;
            if (model != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные о физ. лице: " +
                model.FirstName + " " + model.LastName, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    //удаление данных в списке отображения данных
                    citizens.Remove(model);

                    // удаление данных в списке классов ListCitizen<Citizen>
                    Citizen citizen = new Citizen();
                    citizen = citizen.CopyFromCitizenDPO(model);
                    viewModel.Citizens.Remove(citizen);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать  физ. лицо для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
