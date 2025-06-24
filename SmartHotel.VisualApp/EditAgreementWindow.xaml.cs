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
    /// Interaction logic for EditAgreementWindow.xaml
    /// </summary>
    public partial class EditAgreementWindow : Window
    {
        private readonly ObservableCollection<RoomDetails> originalRooms;
        private readonly ObservableCollection<AgreementDetails> existingReservations;
        private readonly AgreementDetails editingAgreement;

        public AgreementDetails UpdatedAgreement { get; private set; }

        public EditAgreementWindow(AgreementDetails agreement, ObservableCollection<RoomDetails> rooms, ObservableCollection<AgreementDetails> reservations)
        {
            InitializeComponent();

            editingAgreement = agreement;
            originalRooms = rooms;
            existingReservations = reservations;

            StartDatePicker.SelectedDate = agreement.StartDate;
            FinalDatePicker.SelectedDate = agreement.FinalDate;
            ClientNameTextBox.Text = agreement.ClientName;

            RoomComboBox.ItemsSource = originalRooms;
            RoomComboBox.SelectedItem = originalRooms.FirstOrDefault(r => r.Number == agreement.Room.Number);

            //StartDatePicker.SelectedDateChanged += DatePicker_SelectedDateChanged;a
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
                    r != editingAgreement &&
                    r.Room.Number == room.Number &&
                    !(r.FinalDate < start || r.StartDate > end)
                )).ToList();

            RoomComboBox.ItemsSource = availableRooms;

            // Reasignar selección si aún es válida
            if (availableRooms.Any(r => r.Number == editingAgreement.Room.Number))
                RoomComboBox.SelectedItem = availableRooms.First(r => r.Number == editingAgreement.Room.Number);
            else
                RoomComboBox.SelectedItem = null;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || FinalDatePicker.SelectedDate == null ||
                string.IsNullOrWhiteSpace(ClientNameTextBox.Text) || RoomComboBox.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            UpdatedAgreement = new AgreementDetails(
                StartDatePicker.SelectedDate.Value,
                FinalDatePicker.SelectedDate.Value,
                ClientNameTextBox.Text,
                (RoomDetails)RoomComboBox.SelectedItem
            );

            DialogResult = true;
            Close();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}


//        public AgreementDetails AgreementEdited { get; private set; }
//        public EditAgreementWindow(AgreementDetails agreement)
//        {
//            InitializeComponent();

//            //Cargando datos en controles
//            StartDatePicker.SelectedDate = agreement.StartDate;
//            FinalDatePicker.SelectedDate = agreement.FinalDate;
//            ClientTextBox.Text = agreement.ClientName;

//            //Clonando para no modificar directamente
//            AgreementEdited = new AgreementDetails(agreement.StartDate, agreement.FinalDate, agreement.ClientName);
//        }

//        private void btnSave_Click(object sender, RoutedEventArgs e)
//        {
//            if (StartDatePicker.SelectedDate == null || FinalDatePicker.SelectedDate == null || string.IsNullOrWhiteSpace(ClientTextBox.Text))
//            {
//                MessageBox.Show("Completa todos los campos.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
//                return;
//            }

//            AgreementEdited.StartDate = StartDatePicker.SelectedDate.Value;
//            AgreementEdited.FinalDate = FinalDatePicker.SelectedDate.Value;
//            AgreementEdited.ClientName = ClientTextBox.Text.Trim();

//            DialogResult = true;
//            Close();
//        }

//        private void btnCancel_Click(object sender, RoutedEventArgs e)
//        {

//        }
//    }
//}