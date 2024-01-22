using PodsystemaFizLicz.View;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PodsystemaFizLicz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int IdPerson { get; set; }
        public static int IdDocument { get; set; }
        public static int IdCitizen { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Citizen_OnClick(object sender, RoutedEventArgs e)
        {
            WindowCitizen window = new WindowCitizen();
            window.Show();
        }

        private void Documents_OnClick(object sender, RoutedEventArgs e)
        {
            WindowDocuments window = new WindowDocuments();
            window.Show();
        }

        private void Persons_OnClick(object sender, RoutedEventArgs e)
        {
            WindowPersons window = new WindowPersons();
            window.Show();
        }
    }
}