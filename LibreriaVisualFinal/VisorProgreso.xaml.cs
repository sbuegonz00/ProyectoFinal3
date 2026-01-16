using System.Windows;
using System.Windows.Controls;

namespace LibreriaVisualFinal
{
    /// <summary>
    /// Control de usuario que muestra un mensaje de acción y un progreso en porcentaje.
    /// </summary>
    /// <remarks>
    /// Diseñado para enlazarse mediante data binding desde la vista o ViewModel.
    /// Asegurarse de que los valores de ProgresoValor estén en el rango esperado antes de asignar.
    /// </remarks>
    /// <author>Salvador Bueno González</author>
    public partial class VisorProgreso : UserControl
    {
        /// <summary>
        /// DependencyProperty para MensajeAccion. Contiene el texto descriptivo asociado al estado actual.
        /// </summary>
        /// <value>Cadena con el mensaje a mostrar al usuario (ej. "Cargando datos...").</value>
        /// <remarks>Por defecto: "Esperando interacción...". Se recomienda enlazar desde el ViewModel.</remarks>
        public static readonly DependencyProperty MensajeAccionProperty =
            DependencyProperty.Register(
                nameof(MensajeAccion),
                typeof(string),
                typeof(VisorProgreso),
                new PropertyMetadata("Esperando interacción..."));

        /// <summary>
        /// DependencyProperty para ProgresoValor. Representa el porcentaje de progreso mostrado.
        /// </summary>
        /// <value>Valores entre 0 y 100 (double).</value>
        /// <remarks>El control no nivela ni valida automáticamente fuera del rango 0-100; validar en la capa que asigna el valor si es necesario.</remarks>
        public static readonly DependencyProperty ProgresoValorProperty =
            DependencyProperty.Register(
                nameof(ProgresoValor),
                typeof(double),
                typeof(VisorProgreso),
                new PropertyMetadata(0d));

        /// <summary>
        /// Mensaje de acción que se presenta en el visor.
        /// </summary>
        /// <value>Cadena con el texto a mostrar (ej. "Guardando..." o "Listo").</value>
        /// <remarks>Bindable. Actualiza la interfaz al cambiarse mediante binding o asignación directa.</remarks>
        public string MensajeAccion
        {
            get => (string)GetValue(MensajeAccionProperty);
            set => SetValue(MensajeAccionProperty, value);
        }

        /// <summary>
        /// Porcentaje de progreso mostrado por el control.
        /// </summary>
        /// <value>Double con valores típicos entre 0 y 100.</value>
        /// <remarks>Bindable. Se puede ligar a un ProgressBar o similar en la plantilla del control.</remarks>
        public double ProgresoValor
        {
            get => (double)GetValue(ProgresoValorProperty);
            set => SetValue(ProgresoValorProperty, value);
        }

        /// <summary>
        /// Inicializa una nueva instancia del VisorProgreso.
        /// </summary>
        /// <remarks>Ejecuta InitializeComponent y deja el control listo para enlazarse.</remarks>
        public VisorProgreso()
        {
            InitializeComponent();
        }
    }
}