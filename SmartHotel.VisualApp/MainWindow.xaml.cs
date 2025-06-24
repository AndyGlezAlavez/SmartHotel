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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SmartHotel.VisualApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Agreements_Click(object sender, RoutedEventArgs e)
        {
            var reservationsWindow = new AgreementsWindow();
            reservationsWindow.Show();
            this.Close(); // Cierra la ventana actual si deseas solo una activa
        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            var roomsWindow = new RoomsWindow(); // Asegúrate de que exista esta ventana
            roomsWindow.Show();
            this.Close();
        }
    }
}
