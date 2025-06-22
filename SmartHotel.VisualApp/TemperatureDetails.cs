using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.VisualApp
{
    public partial class TemperatureDetails : ObservableObject
    {
        [ObservableProperty]
        public int _value;

        [ObservableProperty]
        public TemmperatureUnitDetails _temperatureUnit;

        [ObservableProperty]
        public int _reference;

        public TemperatureDetails(int reference, int value, TemmperatureUnitDetails temperatureUnit)
        {
            _reference = reference;
            _value = value;
            _temperatureUnit = temperatureUnit;
        }
    }
}
