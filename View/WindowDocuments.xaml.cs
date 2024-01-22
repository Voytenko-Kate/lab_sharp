using PodsystemaFizLicz.Model;
using PodsystemaFizLicz.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для WindowDocuments.xaml
    /// </summary>
    public partial class WindowDocuments : Window
    {
        DocumentViewModel viewModel;
        public WindowDocuments()
        {
            InitializeComponent();
            viewModel = new DocumentViewModel();
            lvDocument.ItemsSource = viewModel.Documents;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowNewDocuments wnNewModel = new WindowNewDocuments
            {
                Title = "Новый документ",
                Owner = this
            };

            int maxId = viewModel.MaxId() + 1;
            Document model = new Document
            {
                Id = maxId
            };

            wnNewModel.DataContext = model;
            if (wnNewModel.ShowDialog() == true)
            {
                viewModel.Documents.Add(model);
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            WindowNewDocuments wnModel = new WindowNewDocuments
            {
                Title = "Редактирование документа",
                Owner = this
            };

            Document model = lvDocument.SelectedItem as Document;
            if (model != null)
            {
                Document tempRole = model.ShallowCopy();
                wnModel.DataContext = tempRole;


                if (wnModel.ShowDialog() == true)
                {
                    model.Organ = tempRole.Organ;
                    model.Data = tempRole.Data;
                    model.Name = tempRole.Name;
                    model.Seriy = tempRole.Seriy;
                    lvDocument.ItemsSource = null;
                    lvDocument.ItemsSource = viewModel.Documents;
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать документ для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Document model = (Document)lvDocument.SelectedItem;
            if (model != null)
            {
                MessageBoxResult result = MessageBox.Show("Удалить данные о документе: " +
                model.Name, "Предупреждение", MessageBoxButton.OKCancel,
                MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    viewModel.Documents.Remove(model);
                }
            }
            else
            {
                MessageBox.Show("Необходимо выбрать документ для редактирования",
                "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
