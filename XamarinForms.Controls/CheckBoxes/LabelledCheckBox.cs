using System;
using Xamarin.Forms;

namespace XamarinForms.Controls.CheckBoxes
{
    public class LabelledCheckBox : ContentView
    {        
        public LabelledCheckBox(
            string label,
            double fontSize = 20,
            string fonFamily = "Arial",
            FontAttributes fontAttributes = FontAttributes.None,
            Color? textColor = null)
        {
            Padding = new Thickness(0);
            Margin = new Thickness(40, 20, 40, 20);

            var checBoxLabel = new Label()
            {
                Text = "\u2610",
                FontFamily = fonFamily,
                FontSize = fontSize,
                TextColor = Color.FromHex("#7f8082")
            };

            var labelText = new Label
            {
                Text = label,
                FontFamily = fonFamily,
                FontSize = fontSize,
                FontAttributes = fontAttributes,
                TextColor = textColor ?? Color.Black,
                VerticalTextAlignment = TextAlignment.Center,
                Margin = new Thickness(10, 0, 10, 0)
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (object sender, EventArgs args) =>
            checBoxLabel.Text = checBoxLabel.Text == "\u2611"
            ? "\u2610"
            : "\u2611";

            StackLayout stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Children = { checBoxLabel, labelText }
            };

            stackLayout.GestureRecognizers.Add(tapGestureRecognizer);

            Content = stackLayout;
        }
    }
}