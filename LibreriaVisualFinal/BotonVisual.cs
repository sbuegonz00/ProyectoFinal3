using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibreriaVisualFinal
{
    /// <summary>
    /// Control personalizado que hereda de Button.
    /// Cambia su color de fondo aleatoriamente al ser presionado.
    /// </summary>
    /// <remarks>
    /// Este control utiliza la clase <see cref="Random"/> para generar colores RGB.
    /// Es útil para demostraciones de controles personalizados (Custom Controls).
    /// </remarks>
    /// <author>Cloud Agent</author>
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
