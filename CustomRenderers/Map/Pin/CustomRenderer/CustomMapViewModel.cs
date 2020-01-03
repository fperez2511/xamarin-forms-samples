using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms.Maps;

namespace CustomRenderer
{
    public class CustomMapViewModel : INotifyPropertyChanged
    {
        private IList<CustomPin> _landmarks;
        public IList<CustomPin> Landmarks
        {
            get { return _landmarks; }
            set
            {
                if (_landmarks != value)
                {
                    _landmarks = value;
                    OnPropertyChanged();
                }
            }
        }

        public CustomMapViewModel()
        {
            CustomPin pin = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(37.79752, -122.40183),
                Label = "Xamarin San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA",
                Name = "Xamarin",
                Url = "http://xamarin.com/about/"
            };
            CustomPin pin2 = new CustomPin
            {
                Type = PinType.Place,
                Position = new Position(37.5, -122.40183),
                Label = "Another San Francisco Office",
                Address = "394 Pacific Ave, San Francisco CA",
                Name = "Xamarin",
                Url = "http://xamarin.com/about/"
            };
            Landmarks = new List<CustomPin> { pin, pin2 };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
