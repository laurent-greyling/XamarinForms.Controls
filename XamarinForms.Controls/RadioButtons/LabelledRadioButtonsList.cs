using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace XamarinForms.Controls.RadioButtons
{
    public class LabelledRadioButtonsList : ContentView
    {
        public LabelledRadioButtonsList(
            List<string> labels,
            double fontSize = 20,
            string fontFamily = "Arial",
            FontAttributes fontAttributes = FontAttributes.None,
            Color? textColor = null)
        {
            Padding = new Thickness(0);
            Margin = new Thickness(40, 20, 40, 20);

            var dataTemplate = new DataTemplate(() =>
            {
                var templateGrid = new Grid
                {
                    RowSpacing = 1,
                    ColumnSpacing = 1,
                };

                var checBoxLabel = new Label()
                {
                    Text = "\u25CB",
                    FontFamily = fontFamily,
                    FontSize = fontSize * 2,
                    TextColor = Color.FromHex("#7f8082")
                };

                var labelText = new Label
                {
                    FontFamily = fontFamily,
                    FontSize = fontSize,
                    FontAttributes = fontAttributes,
                    TextColor = textColor ?? Color.Black,
                    VerticalTextAlignment = TextAlignment.Center,
                    Margin = new Thickness(10, 0, 10, 0)
                };

                labelText.SetBinding(Label.TextProperty, ".");

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (object sender, EventArgs args) =>
                checBoxLabel.Text = checBoxLabel.Text == "\u25CB"
                ? "\u25CF"
                : "\u25CB";

                foreach (var label in labels)
                {
                    templateGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Auto) });
                }

                StackLayout stackLayout = new StackLayout()
                {
                    Orientation = StackOrientation.Horizontal,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    Children = { checBoxLabel, labelText }
                };

                stackLayout.GestureRecognizers.Add(tapGestureRecognizer);
                templateGrid.Children.Add(stackLayout, 0, labels.Count);

                return new ViewCell { View = templateGrid };
            });

            Content = new ListView
            {
                ItemsSource = labels,
                ItemTemplate = dataTemplate,
                Margin = 5,
                SelectionMode = ListViewSelectionMode.None
            };
        }        
    }
}