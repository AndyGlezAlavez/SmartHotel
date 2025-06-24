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
        private double _value;

        [ObservableProperty]
        private MoneyType _typeofMoney;

        public PriceDetails(double value, MoneyType typeofMoney)
        {
            Value = value;
            TypeofMoney = typeofMoney;
        }
    }
}
