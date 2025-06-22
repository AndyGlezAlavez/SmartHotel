using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.VisualApp
{
    public partial class AgreementDetails : ObservableObject
    {
        [ObservableProperty]
        private DateTime _startDate;

        [ObservableProperty]
        private DateTime _finalDate;

        [ObservableProperty]
        private string _clientName;

        public AgreementDetails(DateTime startDate, DateTime finalDate, string clientName)
        {
            StartDate = startDate;
            FinalDate = finalDate;
            ClientName = clientName;
        }
    }
}
