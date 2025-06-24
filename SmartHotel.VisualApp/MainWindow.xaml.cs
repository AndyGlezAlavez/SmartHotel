using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
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
using Grpc.Core;
using Grpc.Net.Client;

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

            var httpHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
            };
            _ = GrpcChannel.ForAddress("https://localhost:5047",
                new GrpcChannelOptions { HttpHandler = httpHandler });

        }

        private void Agreements_Click(object sender, RoutedEventArgs e)
        {
            var reservationsWindow = new AgreementsWindow();
            reservationsWindow.Show();
            this.Close(); 
        }

        private void Rooms_Click(object sender, RoutedEventArgs e)
        {
            var roomsWindow = new RoomsWindow(); 
            roomsWindow.Show();
            this.Close();
        }
    }
}
