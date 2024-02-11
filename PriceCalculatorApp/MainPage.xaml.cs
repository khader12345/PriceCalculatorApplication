using PriceCalculatorApp.BusinessLogic;
using Microsoft.Maui.Controls;
using System;

namespace PriceCalculatorApp
{

    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            discountPicker.SelectedIndex = 0;
        }
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();

        }



    }
}