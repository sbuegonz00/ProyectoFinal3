using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibreriaVisualFinal
{
    public class BotonVisual : Button
    {
        private readonly Random _random = new Random();
        private bool _clickHandlerAttached;

        static BotonVisual()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(BotonVisual),
                new FrameworkPropertyMetadata(typeof(BotonVisual)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (_clickHandlerAttached)
            {
                return;
            }

            Click += BotonVisual_Click;
            _clickHandlerAttached = true;
        }

        private void BotonVisual_Click(object sender, RoutedEventArgs e)
        {
            byte r = (byte)_random.Next(0, 256);
            byte g = (byte)_random.Next(0, 256);
            byte b = (byte)_random.Next(0, 256);

            Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}
