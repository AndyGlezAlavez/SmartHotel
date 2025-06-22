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
    /// Interaction logic for EditAgreementWindow.xaml
    /// </summary>
    public partial class EditAgreementWindow : Window
    {
        public AgreementDetails AgreementEdited { get; private set; }
        public EditAgreementWindow(AgreementDetails agreement)
        {
            InitializeComponent();

            //Cargando datos en controles
            StartDatePicker.SelectedDate = agreement.StartDate;
            FinalDatePicker.SelectedDate = agreement.FinalDate;
            ClientTextBox.Text = agreement.ClientName;

            //Clonando para no modificar directamente
            AgreementEdited = new AgreementDetails(agreement.StartDate, agreement.FinalDate, agreement.ClientName);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (StartDatePicker.SelectedDate == null || FinalDatePicker.SelectedDate == null || string.IsNullOrWhiteSpace(ClientTextBox.Text))
            {
                MessageBox.Show("Completa todos los campos.", "Aviso", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            AgreementEdited.StartDate = StartDatePicker.SelectedDate.Value;
            AgreementEdited.FinalDate = FinalDatePicker.SelectedDate.Value;
            AgreementEdited.ClientName = ClientTextBox.Text.Trim();

            DialogResult = true;
            Close();
        }

        private void ClientTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}