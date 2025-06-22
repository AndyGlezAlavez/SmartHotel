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
    /// Interaction logic for NewAgreement.xaml
    /// </summary>
    public partial class NewAgreement : Window
    {
        public AgreementDetails AddAgreement { get; private set; }
        public NewAgreement()
        {
            InitializeComponent();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(StartDatePicker.SelectedDate == null || FinalDatePicker.SelectedDate == null)
            {
                MessageBox.Show("Selecciona ambas fechas.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if(string.IsNullOrWhiteSpace(ClientNameTextBox.Text))
            {
                MessageBox.Show("Ingresa el nombre del cliente.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AddAgreement = new AgreementDetails(StartDatePicker.SelectedDate.Value, FinalDatePicker.SelectedDate.Value, ClientNameTextBox.Text);
          

            this.DialogResult = true;
            this.Close();
        }
    }
}
