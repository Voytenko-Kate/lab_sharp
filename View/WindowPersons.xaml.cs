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
    /// Логика взаимодействия для WindowPersons.xaml
    /// </summary>
    public partial class WindowPersons : Window
    {
        public WindowPersons()
        {
            InitializeComponent();
            PersonViewModel viewModel = new PersonViewModel();
            lvPersons.ItemsSource = viewModel.Persons;
        }
    }
}
