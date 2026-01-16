using System.Windows;
using System.Windows.Controls;

namespace LibreriaVisualFinal
{
    /// <summary>
    /// Control de usuario que visualiza el progreso de una operación y un mensaje de estado.
    /// </summary>
    /// <remarks>
    /// Este control expone propiedades de dependencia para facilitar el enlace de datos (Data Binding).
    /// </remarks>
    /// <author>Cloud Agent</author>
    public partial class VisorProgreso : UserControl
    {
        /// <summary>
        /// Identifica la propiedad de dependencia <see cref="MensajeAccion"/>.
        /// </summary>
        public static readonly DependencyProperty MensajeAccionProperty =
            DependencyProperty.Register(
                nameof(MensajeAccion),
                typeof(string),
                typeof(VisorProgreso),
                new PropertyMetadata("Esperando interacción..."));

        /// <summary>
        /// Identifica la propiedad de dependencia <see cref="ProgresoValor"/>.
        /// </summary>
        public static readonly DependencyProperty ProgresoValorProperty =
            DependencyProperty.Register(
                nameof(ProgresoValor),
                typeof(double),
                typeof(VisorProgreso),
                new PropertyMetadata(0d));

        /// <summary>
        /// Obtiene o establece el mensaje que describe la acción actual.
        /// </summary>
        /// <value>Cadena de texto con la descripción de la acción.</value>
        public string MensajeAccion
        {
            get => (string)GetValue(MensajeAccionProperty);
            set => SetValue(MensajeAccionProperty, value);
        }

        /// <summary>
        /// Obtiene o establece el valor numérico del progreso actual.
        /// </summary>
        /// <value>Valor de punto flotante (double) que representa el progreso (ej: 0 a 100).</value>
        public double ProgresoValor
        {
            get => (double)GetValue(ProgresoValorProperty);
            set => SetValue(ProgresoValorProperty, value);
        }

        public VisorProgreso()
        {
            InitializeComponent();
        }
    }
}
