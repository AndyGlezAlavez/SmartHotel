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
    /// Interaction logic for RoomsWindow.xaml
    /// </summary>
    public partial class RoomsWindow : Window
    {
        private ObservableCollection<RoomDetails> rooms = new();

        public RoomsWindow()
        {
            InitializeComponent();
            RoomsGrid.ItemsSource = rooms;
        }

        private void RoomsGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selected = (RoomDetails)RoomsGrid.SelectedItem;
            if (selected != null)
            {
                var editWindow = new EditRoomWindow(selected);
                if (editWindow.ShowDialog() == true)
                {
                    //Actualicar la habitación seleccionada
                    selected.RentalPrice = editWindow.EditedRoom.RentalPrice;
                    selected.Number = editWindow.EditedRoom.Number;
                    selected.IsRentable = editWindow.EditedRoom.IsRentable;


                }
            }
        }

        private void NewRoom_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewRoomWindow();
            if (window.ShowDialog() == true && window.CreatedRoom != null)
            {
                rooms.Add(window.CreatedRoom);
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            var selected = (RoomDetails)RoomsGrid.SelectedItem;
            if (selected != null)
            {
                rooms.Remove(selected);
            }
            else
            {
                MessageBox.Show("No hay seleccionada ninguna reserva para eliminar.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Information);
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







//        private void Nueva_Click(object sender, RoutedEventArgs e)
//        {
//            var window = new RoomDetailsWindow();
//            if (window.ShowDialog() == true && window.Room != null)
//            {
//                rooms.Add(window.Room);
//            }
//        }

//        private void Editar_Click(object sender, RoutedEventArgs e)
//        {
//            if (RoomsGrid.SelectedItem is Room selectedRoom)
//            {
//                var window = new RoomDetailsWindow(selectedRoom);
//                if (window.ShowDialog() == true && window.Room != null)
//                {
//                    int index = rooms.IndexOf(selectedRoom);
//                    if (index >= 0)
//                        rooms[index] = window.Room;
//                }
//            }
//        }

//        private void Eliminar_Click(object sender, RoutedEventArgs e)
//        {
//            if (RoomsGrid.SelectedItem is Room selectedRoom)
//            {
//                if (MessageBox.Show($"¿Eliminar la habitación #{selectedRoom.Number}?", "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
//                {
//                    rooms.Remove(selectedRoom);
//                }
//            }
//        }
//    }
//}

