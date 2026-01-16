using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibreriaVisualFinal
{
    /// <summary>
    /// Botón personalizado que cambia su color de fondo a un color aleatorio cuando se pulsa.
    /// </summary>
    /// <remarks>
    /// Este control extiende Button y sobreescribe OnApplyTemplate para adjuntar el manejador de Click.
    /// Útil como control visual demostrativo o para interfaces que requieran retroalimentación visual.
    /// </remarks>
    /// <author>Salvador Bueno González</author>
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

        /// <summary>
        /// Se ejecuta cuando la plantilla del control se aplica; asegura que el evento Click esté suscrito una sola vez.
        /// </summary>
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

        /// <summary>
        /// Manejador del evento Click que asigna un color RGB aleatorio al Background del botón.
        /// </summary>
        /// <remarks>
        /// No realiza acceso a hilos ni tareas asíncronas. Si se desea persistencia del color, gestionarla externamente.
        /// </remarks>
        private void BotonVisual_Click(object sender, RoutedEventArgs e)
        {
            byte r = (byte)_random.Next(0, 256);
            byte g = (byte)_random.Next(0, 256);
            byte b = (byte)_random.Next(0, 256);

            Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}