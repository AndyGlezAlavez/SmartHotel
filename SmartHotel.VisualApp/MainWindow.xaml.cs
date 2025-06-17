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
                new AgreementDetails(new DateTime(2025, 11, 06), new DateTime(2025, 11, 09), "Andy"),
                new AgreementDetails(new DateTime(2025, 11, 07), new DateTime(2025, 11, 15), "Dayron"),
                new AgreementDetails(new DateTime(2025, 11, 10), new DateTime(2025, 11, 13), "Jose"),
            };

            //DataContext = this;


            InitializeComponent();
            AgreementsGrid.ItemsSource = Agreements;
        }
    }
}
