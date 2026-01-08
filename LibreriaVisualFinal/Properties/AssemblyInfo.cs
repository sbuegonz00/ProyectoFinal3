using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Markup;

[assembly: AssemblyTitle("LibreriaVisualFinal")]
[assembly: AssemblyDescription("Controles visuales reutilizables (WPF)")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("LibreriaVisualFinal")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

[assembly: ComVisible(false)]

[assembly: Guid("0f744f38-6fc8-4c29-a702-95d5512f3985")]

[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

// Mapeo XMLNS profesional para XAML
[assembly: XmlnsDefinition("http://miscontroles.com/final", "LibreriaVisualFinal")]
[assembly: XmlnsPrefix("http://miscontroles.com/final", "final")]

// Necesario para que WPF localice Themes/Generic.xaml
[assembly: ThemeInfo(ResourceDictionaryLocation.None, ResourceDictionaryLocation.SourceAssembly)]
