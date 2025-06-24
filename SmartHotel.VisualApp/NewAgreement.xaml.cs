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
    /// Interaction logic for NewAgreement.xaml
    /// </summary>
    public partial class NewAgreement : Window
    {
        public AgreementDetails AddAgreement { get; private set; }
        public ObservableCollection<RoomDetails> originalRooms;
        public ObservableCollection<AgreementDetails> existingReservations;
        
        public NewAgreement(ObservableCollection<RoomDetails> availableRooms, ObservableCollection<AgreementDetails> reservations)
        {
            InitializeComponent();
            originalRooms = availableRooms;
            existingReservations = reservations;

            RoomComboBox.ItemsSource = originalRooms;
            //StartDatePicker.SelectedDateChanged += DatePicker_SelectedDateChanged;
            //FinalDatePicker.SelectedDateChanged += DatePicker_SelectedDateChanged;
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || FinalDatePicker.SelectedDate == null)
                return;

            var start = StartDatePicker.SelectedDate.Value;
            var end = FinalDatePicker.SelectedDate.Value;

            var availableRooms = originalRooms.Where(room =>
                !existingReservations.Any(r =>
                    r.Room.Number == room.Number &&
                    !(r.FinalDate < start || r.StartDate > end) // hay solapamiento
                )).ToList();

            RoomComboBox.ItemsSource = availableRooms;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || FinalDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Seleccione fechas válidas.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ClientNameTextBox.Text))
            {
                MessageBox.Show("Ingresa el nombre del cliente.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (RoomComboBox.SelectedItem is not RoomDetails selectedRoom)
            {
                MessageBox.Show("Seleccione una habitación.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AddAgreement = new AgreementDetails(
                StartDatePicker.SelectedDate.Value,
                FinalDatePicker.SelectedDate.Value,
                ClientNameTextBox.Text/*.Trim()*/,
                selectedRoom
            );

            DialogResult = true;
            Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}
 

        //private void Save_Click(object sender, RoutedEventArgs e)
        //{
        //    if(StartDatePicker.SelectedDate == null || FinalDatePicker.SelectedDate == null)
        //    {
        //        MessageBox.Show("Selecciona ambas fechas.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    if(string.IsNullOrWhiteSpace(ClientNameTextBox.Text))
        //    {
        //        MessageBox.Show("Ingresa el nombre del cliente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    AddAgreement = new AgreementDetails(StartDatePicker.SelectedDate.Value, FinalDatePicker.SelectedDate.Value, ClientNameTextBox.Text);
          

        //    this.DialogResult = true;
        //    this.Close();
    
