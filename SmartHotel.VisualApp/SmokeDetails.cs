using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.VisualApp
{
    public partial class SmokeDetails : ObservableObject
    {
        [ObservableProperty]
        public int _value;

        [ObservableProperty]
        public SmokeUnitDetails _smokeUnit;

        [ObservableProperty]
        public int _reference;

        public SmokeDetails(int reference, int value, SmokeUnitDetails smokeUnit)
        {
            _reference = reference;
            _value = value;
            _smokeUnit = smokeUnit;
        }
    }
}
