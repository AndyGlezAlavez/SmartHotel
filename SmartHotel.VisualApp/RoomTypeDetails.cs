using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHotel.VisualApp
{
    public partial class RoomTypeDetails : ObservableObject
    {
        [ObservableProperty]
        public CategoryDetails _categoryDetails;

        [ObservableProperty]
        public CapacityDetails _capacityDetails;

        public RoomTypeDetails (CategoryDetails categoryDetails, CapacityDetails capacityDetails)
        {

            _categoryDetails = categoryDetails;
            _capacityDetails = capacityDetails;
        }
    }
}
