using System;
using Xamarin.Forms;

namespace XamarinForms.Controls.RadioButtons
{
    public class RadioButton : ContentView
    {
        public RadioButton()
        {
            Padding = new Thickness(0);
            Margin = new Thickness(40, 20, 40, 20);

            var radioButtonLabel = new Label()
            {
                Text = "\u25CB",
                FontFamily = "Arial",
                FontSize = 40,
                TextColor = Color.FromHex("#7f8082")
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (object sender, EventArgs args) =>
            radioButtonLabel.Text = radioButtonLabel.Text == "\u25CB"
            ? "\u25CF"
            : "\u25CB";

            StackLayout stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { radioButtonLabel }
            };

            stackLayout.GestureRecognizers.Add(tapGestureRecognizer);

            Content = stackLayout;
        }
    }
}