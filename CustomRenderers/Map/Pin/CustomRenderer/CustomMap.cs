using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Maps;

namespace CustomRenderer
{
    public class CustomMap : Map
    {
        public static readonly BindableProperty CustomPinsProperty =
            BindableProperty.Create(nameof(CustomPins),
                typeof(IList<CustomPin>),
                typeof(CustomMap),
                null,
                BindingMode.TwoWay, null, OnCustomPinsPropertyChanged);

        private static void OnCustomPinsPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            var control = (CustomMap)bindable;
            if (control != null)
            {
                if (newvalue is IList<CustomPin> customPins)
                {
                    customPins.ForEach(p => control.Pins.Add(p));
                }
            }
        }

        public IList<CustomPin> CustomPins
        {
            get => (IList<CustomPin>)GetValue(CustomPinsProperty);
            set => SetValue(CustomPinsProperty, value);
        }
    }
}
