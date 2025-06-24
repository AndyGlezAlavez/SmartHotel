using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.VisualApp
{
    public partial class PriceDetails : ObservableObject
    {
        [ObservableProperty]
        public int _value;

        [ObservableProperty]
        public MoneyTypeDetails _moneyTypeDetails;

        public PriceDetails(int value, MoneyTypeDetails moneyTypeDetails)
        {

            _value = value;
            _moneyTypeDetails  = moneyTypeDetails;
        }
    }
}
