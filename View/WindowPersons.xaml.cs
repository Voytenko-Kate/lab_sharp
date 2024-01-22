using PodsystemaFizLicz.Model;
using PodsystemaFizLicz.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace PodsystemaFizLicz.View
{
    /// <summary>
    /// Логика взаимодействия для WindowPersons.xaml
    /// </summary>
    public partial class WindowPersons : Window
    {
        PersonViewModel viewModel;
        public WindowPersons()
        {
            InitializeComponent();
            viewModel = new PersonViewModel();
            lvPersons.ItemsSource = viewModel.Persons;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPersons wnNewModel = new WindowNewPersons
            {
                Title = "Новое физ. лицо",
                Owner = this
            };

            int maxId = viewModel.MaxId() + 1;
            Person model = new Person
            {
                Id = maxId
            };

            wnNewModel.DataContext = model;
            if (wnNewModel.ShowDialog() == true)
            {
                viewModel.Persons.Add(model);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewPersons wnModel = new WindowNewPersons
            {
                Title = "Редактирование физ. лица",
                Owner = this
            };

            Person model = lvPersons.SelectedItem as Person;
            if (model != null)
            {
                Person tempRole = model.ShallowCopy();
                wnModel.DataContext = tempRole;


                if (wnModel.ShowDialog() == true)
                {
                    model.Inn = tempRole.Inn;
                    model.Data = tempRole.Data;
                    model.Shifer = tempRole.Shifer;
                    model.Type = tempRole.Type;
                    lvPersons.ItemsSource = null;
                    lvPersons.ItemsSource = viewModel.Persons;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать клиента для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Person model = (Person)lvPersons.SelectedItem;
            if (model != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные клиента: " +
                model.Inn, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    viewModel.Persons.Remove(model);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать клиента для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
