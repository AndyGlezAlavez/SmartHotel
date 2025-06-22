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
        public AgreementDetails Agreement { get; set; }
        public ObservableCollection<AgreementDetails> Agreements { get; set; }

        public MainWindow()
        {
            Agreement = new AgreementDetails(new DateTime(2001, 11, 06), new DateTime(01, 11, 09), "Ariel");
            Agreements = new ObservableCollection<AgreementDetails>()
            {
                new(new DateTime(2025, 11, 06), new DateTime(2025, 11, 09), "Andy"),
                new(new DateTime(2025, 11, 07), new DateTime(2025, 11, 15), "Dayron"),
                new(new DateTime(2025, 11, 10), new DateTime(2025, 11, 13), "Jose"),
            };

            //DataContext = this;


            InitializeComponent();
            AgreementsGrid.ItemsSource = Agreements;
        }

        private void BtnNuevaReserva_Click(object sender, RoutedEventArgs e)
        {
            var window = new NewAgreement();
            if (window.ShowDialog() == true && window.AddAgreement != null)
                Agreements.Add(window.AddAgreement);
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
                var editWindow = new EditAgreementWindow(selected);
                if (editWindow.ShowDialog() == true)
                {
                    //Actualicar la reservación seleccionada
                    selected.StartDate = editWindow.AgreementEdited.StartDate;
                    selected.FinalDate = editWindow.AgreementEdited.FinalDate;
                    selected.ClientName = editWindow.AgreementEdited.ClientName;

                    AgreementsGrid.Items.Refresh();
                }
            }
        }
    }
}
