using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.VisualApp
{
    public partial class LightDetails : ObservableObject
    {
        [ObservableProperty]
        public int _value;

        [ObservableProperty]
        public LightUnitDetails _lightUnit;

        [ObservableProperty]
        public int _reference;

        public LightDetails(int reference, int value, LightUnitDetails lightUnit)
        {
            _reference = reference;
            _value = value;
            _lightUnit = lightUnit;
        }
    }
}
