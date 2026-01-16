using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LibreriaVisualFinal
{
    /// <summary>
    /// Control de botón visual personalizado que cambia su color de fondo 
    /// de manera aleatoria cada vez que el usuario hace clic sobre él.
    /// </summary>
    /// <remarks>
    /// Este control hereda de <see cref="Button"/> y aplica un estilo personalizado 
    /// definido en Generic.xaml. El cambio de color se realiza generando valores RGB 
    /// aleatorios en el rango de 0 a 255 para cada componente de color.
    /// Requiere Windows Presentation Foundation (WPF) y .NET Framework 4.7.2 o superior.
    /// </remarks>
    /// <author>Sebastian Bueno González</author>
    public class BotonVisual : Button
    {
        /// <summary>
        /// Generador de números aleatorios utilizado para crear colores RGB aleatorios.
        /// </summary>
        private readonly Random _random = new Random();

        /// <summary>
        /// Indica si el manejador del evento Click ya ha sido registrado.
        /// </summary>
        private bool _clickHandlerAttached;

        /// <summary>
        /// Constructor estático que establece el estilo predeterminado del control.
        /// </summary>
        /// <remarks>
        /// Sobrescribe los metadatos de <see cref="FrameworkElement.DefaultStyleKeyProperty"/> 
        /// para aplicar el estilo definido en el diccionario de recursos Generic.xaml.
        /// </remarks>
        static BotonVisual()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(BotonVisual),
                new FrameworkPropertyMetadata(typeof(BotonVisual)));
        }

        /// <summary>
        /// Se invoca cuando se aplica la plantilla del control.
        /// </summary>
        /// <remarks>
        /// Este método registra el manejador del evento Click una única vez 
        /// para evitar múltiples suscripciones al evento cuando se vuelve a aplicar la plantilla.
        /// </remarks>
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
        /// Manejador del evento Click que cambia el color de fondo del botón.
        /// </summary>
        /// <param name="sender">El objeto que originó el evento.</param>
        /// <param name="e">Argumentos del evento de enrutamiento.</param>
        /// <remarks>
        /// Genera un color aleatorio utilizando componentes RGB con valores entre 0 y 255,
        /// y lo aplica como nuevo color de fondo del botón mediante un <see cref="SolidColorBrush"/>.
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
