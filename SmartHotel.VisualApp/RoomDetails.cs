using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.VisualApp
{
    public partial class RoomDetails : ObservableObject
    {
        [ObservableProperty]
        private int _number;

        [ObservableProperty]
        private bool _isRentable;

        [ObservableProperty]
        private PriceDetails _rentalPrice;


        public RoomDetails(int number, bool isRentable, PriceDetails rentalPrice)
        {
            Number = number;
            IsRentable = isRentable;
            RentalPrice = rentalPrice;
        }

    }
}
