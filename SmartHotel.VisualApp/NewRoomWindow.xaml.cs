using Grpc.Core;
using SmartHotel.GrpcProtos;
using System;
using System.Windows;

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
                var roomClient = new Room.RoomClient(MainWindow.Channel);


                var price = new PriceDetails(priceValue, selectedItem);
                CreatedRoom = new RoomDetails(number, IsRentableCheckBox.IsChecked == true, price);
                CreatedRoom.Number = number;
                CreatedRoom.RentalPrice.Value = priceValue;
                CreatedRoom.RentalPrice.TypeofMoney = selectedItem;
                CreatedRoom.IsRentable = IsRentableCheckBox.IsChecked == true;
                DialogResult = true;
                var dto = new RoomDTO
                {
                    Number = CreatedRoom.Number,
                    IsRentable = CreatedRoom.IsRentable,
                    RentalPrice = new Price
                    {
                        Value = CreatedRoom.RentalPrice.Value,
                        MoneyType = (MoneyTipe)CreatedRoom.RentalPrice.TypeofMoney,
                    },

                    // Completa los demás campos si existen (como IsOcupated, RoomType, etc.)
                };
                var roomDtoResponse = roomClient.CreateRoom(new CreateRoomRequest
                {
                    Number = CreatedRoom.Number,
                    IsRentable = true,
                    IsOcupated = false,
                    RentalPrice = new Price
                    {
                        Value = CreatedRoom.RentalPrice.Value,
                        MoneyType = (MoneyTipe)CreatedRoom.RentalPrice.TypeofMoney,
                    },
                    RoomType = new RoomType
                    {
                        Category = (Category)Category.Vip,
                        Capacity = (Capacity)Capacity.Double,
                    },
                    Light = new LightDTO
                    {
                        Id = Guid.NewGuid().ToString(),
                        Value = 3,
                        Reference = 4,
                        Unit = LightUnit.Lux,
                    },
                    Temperature = new TemperatureDTO
                    {
                        Id = Guid.NewGuid().ToString(),
                        Value = 3,
                        Reference = 4,
                        Unit = TempUnit.Farenheit,
                    },
                    Smoke = new SmokeDTO
                    {
                        Id = Guid.NewGuid().ToString(),
                        Value = 3,
                        Reference = 4,
                        Unit = SmokeUnit.Ppt,
                    },
                    Id = Guid.NewGuid().ToString(),
                });

                try
                {
                    //roomClient.UpdateRoomAsync(dto);
                    //DialogResult = true;
                    Close();
                }
                catch (RpcException ex)
                {
                    MessageBox.Show($"Error al guardar en el servidor: {ex.Status.Detail}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Close();
            }
            else
            {
                MessageBox.Show("Verifica que el número y el precio sean válidos.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Close();
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }
    }
}



