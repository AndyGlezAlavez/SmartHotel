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

using SmartHotel.GrpcProtos;

namespace SmartHotel.VisualApp
{
    /// <summary>
    /// Interaction logic for EditRoomWindow.xaml
    /// </summary>
    public partial class EditRoomWindow : Window
    {
        public RoomDetails EditedRoom { get; private set; }

        public EditRoomWindow(RoomDetails roomToEdit)
        {
            InitializeComponent();
            //Cargando datos en controles
            RoomNumberTextBox.Text = roomToEdit.Number.ToString();
            PriceTextBox.Text = roomToEdit.RentalPrice.Value.ToString("0.00");

            CurrencyComboBox.ItemsSource = Enum.GetValues(typeof(MoneyType));
            CurrencyComboBox.SelectedItem = roomToEdit.RentalPrice.TypeofMoney;

            IsRentableCheckBox.IsChecked = roomToEdit.IsRentable;

            //Actualizando habitación
            EditedRoom = new RoomDetails(roomToEdit.Number, roomToEdit.IsRentable, new PriceDetails(roomToEdit.RentalPrice.Value, roomToEdit.RentalPrice.TypeofMoney));
            var roomClient = new Room.RoomClient(MainWindow.Channel);
            var dto = new RoomDTO
            {
                
                Number = EditedRoom.Number,
                IsRentable = EditedRoom.IsRentable,
                RentalPrice = new Price
                {
                    Value = EditedRoom.RentalPrice.Value,
                },

                // Completa los demás campos si existen (como IsOcupated, RoomType, etc.)
            };

        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RoomNumberTextBox.Text, out int number) &&
                double.TryParse(PriceTextBox.Text, out double priceValue) && CurrencyComboBox.SelectedItem is MoneyType selectedItem)

            {
                EditedRoom.Number = number;
                EditedRoom.RentalPrice.Value = priceValue;
                EditedRoom.RentalPrice.TypeofMoney = selectedItem;
                EditedRoom.IsRentable = IsRentableCheckBox.IsChecked == true;

                DialogResult = true;
                
                Close();
            }
            else
            {
                MessageBox.Show("Verifica que el número y el precio sean válidos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}




