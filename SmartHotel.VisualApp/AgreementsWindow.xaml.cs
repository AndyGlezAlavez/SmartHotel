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

namespace SmartHotel.VisualApp
{
    /// <summary>
    /// Interaction logic for AgreementsWindow.xaml
    /// </summary>
    public partial class AgreementsWindow : Window
    {

        public AgreementDetails Agreement { get; set; }
        public RoomDetails Room1 { get; set; }
        public RoomDetails Room2 { get; set; }
        public PriceDetails Price { get; set; }
        public ObservableCollection<RoomDetails> Rooms { get; set; }
        public ObservableCollection<AgreementDetails> Agreements { get; set; }

        public AgreementsWindow()
        {
            Price = new PriceDetails(500, MoneyType.USD);
            Room1 = new RoomDetails(15, false, Price);
            Room2 = new RoomDetails(20, false, new PriceDetails(300, MoneyType.MLC));
            Rooms = new ObservableCollection<RoomDetails>()
            {
                Room1,
                Room2
            };

            Agreement = new AgreementDetails(new DateTime(2001, 11, 06), new DateTime(01, 11, 09), "Ariel", Room2);
            Agreements = new ObservableCollection<AgreementDetails>()
            {
                Agreement
            };

            InitializeComponent();
            AgreementsGrid.ItemsSource = Agreements;
        }


        private void BtnNuevaReserva_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewAgreement(Rooms, Agreements);
            if (window.ShowDialog() == true)
            {
                Agreements.Add(window.AddAgreement);
            }

        }

        private void BtnDeleteAgreement_Click(object sender, RoutedEventArgs e)
        {
            var selected = (AgreementDetails)AgreementsGrid.SelectedItem;
            if (selected != null)
            {
                Agreements.Remove(selected);
            }
            else
            {
                MessageBox.Show("No hay seleccionada ninguna reserva para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AgreementsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = (AgreementDetails)AgreementsGrid.SelectedItem;
            if (selected != null)
            {
                var editWindow = new EditAgreementWindow(selected, Rooms, Agreements);
                if (editWindow.ShowDialog() == true)
                {
                    //Actualicar la reservación seleccionada
                    selected.StartDate = editWindow.UpdatedAgreement.StartDate;
                    selected.FinalDate = editWindow.UpdatedAgreement.FinalDate;
                    selected.ClientName = editWindow.UpdatedAgreement.ClientName;



                }
            }
        }

        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow menu = new MainWindow();
            menu.Show();
            this.Close();
        }
    }
}

    
