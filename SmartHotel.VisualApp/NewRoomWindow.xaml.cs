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

namespace SmartHotel.VisualApp
{
    /// <summary>
    /// Interaction logic for NewRoomWindow.xaml
    /// </summary>
    public partial class NewRoomWindow : Window
    {
        public RoomDetails CreatedRoom { get; private set; }

        public NewRoomWindow()
        {
            InitializeComponent();
            CurrencyComboBox.ItemsSource = Enum.GetValues(typeof(MoneyType));
            CurrencyComboBox.SelectedIndex = 0;

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RoomNumberTextBox.Text, out int number) &&
                double.TryParse(PriceTextBox.Text, out double priceValue) && CurrencyComboBox.SelectedItem is MoneyType selectedItem)
            {
                //var currency = Enum.TryParse<MoneyType>(selectedItem.Content.ToString(), out var moneyType)
                //    ? moneyType : MoneyType.USD;



                
                var price = new PriceDetails(priceValue, selectedItem);
                CreatedRoom = new RoomDetails(number, IsRentableCheckBox.IsChecked == true, price);
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



