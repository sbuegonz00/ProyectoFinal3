using System.Windows;
using System.Windows.Controls;

namespace LibreriaVisualFinal
{
    /// <summary>
    /// Control de usuario que muestra una barra de progreso junto con un mensaje 
    /// descriptivo de la acción en curso.
    /// </summary>
    /// <remarks>
    /// Este control combina un <see cref="ProgressBar"/> con un <see cref="TextBlock"/> 
    /// para proporcionar retroalimentación visual del progreso de operaciones.
    /// Utiliza Dependency Properties para permitir el enlace de datos (Data Binding) 
    /// desde XAML o código.
    /// Requiere Windows Presentation Foundation (WPF) y .NET Framework 4.7.2 o superior.
    /// </remarks>
    /// <author>Sebastian Bueno González</author>
    public partial class VisorProgreso : UserControl
    {
        /// <summary>
        /// Identifica la propiedad de dependencia <see cref="MensajeAccion"/>.
        /// </summary>
        /// <remarks>
        /// Esta propiedad de dependencia permite el enlace de datos y la animación 
        /// del mensaje de acción mostrado en el control.
        /// El valor predeterminado es "Esperando interacción...".
        /// </remarks>
        public static readonly DependencyProperty MensajeAccionProperty =
            DependencyProperty.Register(
                nameof(MensajeAccion),
                typeof(string),
                typeof(VisorProgreso),
                new PropertyMetadata("Esperando interacción..."));

        /// <summary>
        /// Identifica la propiedad de dependencia <see cref="ProgresoValor"/>.
        /// </summary>
        /// <remarks>
        /// Esta propiedad de dependencia permite el enlace de datos y la animación 
        /// del valor de progreso mostrado en la barra de progreso.
        /// El valor predeterminado es 0.
        /// </remarks>
        public static readonly DependencyProperty ProgresoValorProperty =
            DependencyProperty.Register(
                nameof(ProgresoValor),
                typeof(double),
                typeof(VisorProgreso),
                new PropertyMetadata(0d));

        /// <summary>
        /// Obtiene o establece el mensaje descriptivo de la acción en curso.
        /// </summary>
        /// <value>
        /// Cadena de texto que describe la operación actual. 
        /// Acepta cualquier valor de tipo <see cref="string"/>.
        /// El valor predeterminado es "Esperando interacción...".
        /// </value>
        /// <remarks>
        /// Este mensaje se muestra en un <see cref="TextBlock"/> junto a la barra de progreso
        /// para informar al usuario sobre qué operación se está realizando.
        /// </remarks>
        public string MensajeAccion
        {
            get => (string)GetValue(MensajeAccionProperty);
            set => SetValue(MensajeAccionProperty, value);
        }

        /// <summary>
        /// Obtiene o establece el valor actual del progreso.
        /// </summary>
        /// <value>
        /// Valor numérico de tipo <see cref="double"/> que representa el porcentaje de progreso.
        /// Valores entre 0 y 100, donde 0 representa 0% y 100 representa 100% completado.
        /// El valor predeterminado es 0.
        /// </value>
        /// <remarks>
        /// Este valor se enlaza a la propiedad Value del <see cref="ProgressBar"/> interno.
        /// Se recomienda mantener los valores dentro del rango 0-100 para un comportamiento correcto.
        /// </remarks>
        public double ProgresoValor
        {
            get => (double)GetValue(ProgresoValorProperty);
            set => SetValue(ProgresoValorProperty, value);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="VisorProgreso"/>.
        /// </summary>
        /// <remarks>
        /// El constructor llama a <see cref="InitializeComponent"/> para cargar 
        /// la interfaz de usuario definida en el archivo XAML correspondiente.
        /// </remarks>
        public VisorProgreso()
        {
            InitializeComponent();
        }
    }
}
