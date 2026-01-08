using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProyectoFinalUd2
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }

    public class Producto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
    }

    public partial class MainWindow : Window
    {
        private List<Categoria> categorias;
        private List<Producto> productos;
        private int nextProductoId = 107;
        private int ProductoSeleccionadoId = 0;
        private readonly Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            InicializarDatos();
            CargarCategorias();
            btnAccionVisual.Click += BtnAccionVisual_Click;
        }

        private void BtnAccionVisual_Click(object sender, RoutedEventArgs e)
        {
            miVisor.MensajeAccion = $"Acción lanzada a las {DateTime.Now:HH:mm:ss}";
            miVisor.ProgresoValor = _random.Next(0, 101);
        }

        private void InicializarDatos()
        {
            categorias = new List<Categoria>
            {
                new Categoria { Id = 1, Nombre = "Deportes" },
                new Categoria { Id = 2, Nombre = "Accesorios" },
                new Categoria { Id = 3, Nombre = "Calzado" },
            };

            productos = new List<Producto>
            {
                new Producto { Id = 101, CategoriaId = 1, Nombre = "Balon de futbol", Precio = 15.99m, Stock = 50 },
                new Producto { Id = 102, CategoriaId = 1, Nombre = "Caña de pescar", Precio = 59.90m, Stock = 30 },
                new Producto { Id = 103, CategoriaId = 2, Nombre = "Reloj Deportivo", Precio = 99.50m, Stock = 15 },
                new Producto { Id = 104, CategoriaId = 2, Nombre = "Ropa termica", Precio = 15.00m, Stock = 70 },
                new Producto { Id = 105, CategoriaId = 3, Nombre = "Zapatillas Running", Precio = 75.00m, Stock = 40 },
                new Producto { Id = 106, CategoriaId = 3, Nombre = "Botas de Futbol", Precio = 120.00m, Stock = 20 },
            };
            nextProductoId = productos.Any() ? productos.Max(p => p.Id) + 1 : 101;
        }

        private void CargarCategorias()
        {
            lstCategorias.ItemsSource = categorias;
            if (categorias.Any())
            {
                lstCategorias.SelectedIndex = 0;
            }
        }

        private void CargarProductos(int categoriaId, string filtro = null)
        {
            var productosFiltrados = productos.Where(p => p.CategoriaId == categoriaId).AsEnumerable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                string lowerFiltro = filtro.ToLower();
                productosFiltrados = productosFiltrados.Where(p =>
                    p.Nombre.ToLower().Contains(lowerFiltro) ||
                    p.Precio.ToString().Contains(lowerFiltro) ||
                    p.Stock.ToString().Contains(lowerFiltro));
            }

            gridProductos.ItemsSource = productosFiltrados.ToList();
            LimpiarFormulario();
        }

        private void lstCategorias_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstCategorias.SelectedValue is int categoriaId)
            {
                CargarProductos(categoriaId, txtBuscar.Text);
            }
        }

        private void txtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (lstCategorias.SelectedValue is int categoriaId)
            {
                CargarProductos(categoriaId, txtBuscar.Text);
            }
        }

        private void gridProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (gridProductos.SelectedItem is Producto productoSeleccionado)
            {
                ProductoSeleccionadoId = productoSeleccionado.Id;
                txtNombre.Text = productoSeleccionado.Nombre;
                txtPrecio.Text = productoSeleccionado.Precio.ToString("N2");
                txtStock.Text = productoSeleccionado.Stock.ToString();

                btnEliminar.IsEnabled = true;
                btnEliminar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E74C3C"));
            }
            else
            {
                LimpiarFormulario();
            }
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (!(lstCategorias.SelectedValue is int categoriaId))
            {
                MessageBox.Show("Por favor, selecciona una categoría.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                !decimal.TryParse(txtPrecio.Text.Replace('.', ','), out decimal precio) ||
                !int.TryParse(txtStock.Text, out int stock))
            {
                MessageBox.Show("Rellena todos los campos correctamente.", "Error de Validación", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (ProductoSeleccionadoId == 0)
            {
                Producto nuevoProducto = new Producto
                {
                    Id = nextProductoId++,
                    CategoriaId = categoriaId,
                    Nombre = txtNombre.Text.Trim(),
                    Precio = precio,
                    Stock = stock
                };
                productos.Add(nuevoProducto);
            }
            else
            {
                var productoAActualizar = productos.FirstOrDefault(p => p.Id == ProductoSeleccionadoId);
                if (productoAActualizar != null)
                {
                    productoAActualizar.Nombre = txtNombre.Text.Trim();
                    productoAActualizar.Precio = precio;
                    productoAActualizar.Stock = stock;
                    productoAActualizar.CategoriaId = categoriaId;
                }
            }

            CargarProductos(categoriaId, txtBuscar.Text);
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (ProductoSeleccionadoId == 0) return;

            var result = MessageBox.Show($"¿Eliminar producto ID: {ProductoSeleccionadoId}?",
                                         "Confirmar", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                productos.RemoveAll(p => p.Id == ProductoSeleccionadoId);

                if (lstCategorias.SelectedValue is int categoriaId)
                {
                    CargarProductos(categoriaId, txtBuscar.Text);
                }
            }
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            ProductoSeleccionadoId = 0;
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            gridProductos.SelectedItem = null;

            btnEliminar.IsEnabled = false;
            btnEliminar.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#3A3A3A"));
        }

        private void NumericTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            string tag = textBox.Tag.ToString();
            string text = textBox.Text;
            string newText = text;

            if (tag == "Precio")
            {
                newText = Regex.Replace(text, @"[^0-9\.,]", "");

                if (newText.Count(c => c == '.' || c == ',') > 1)
                {
                    int firstSeparatorIndex = newText.IndexOfAny(new char[] { '.', ',' });
                    if (firstSeparatorIndex != -1)
                    {
                        string firstPart = newText.Substring(0, firstSeparatorIndex + 1);
                        string secondPart = newText.Substring(firstSeparatorIndex + 1).Replace(".", "").Replace(",", "");
                        newText = firstPart + secondPart;
                    }
                }
            }
            else if (tag == "Stock")
            {
                newText = Regex.Replace(text, @"[^0-9]", "");
            }

            if (textBox.Text != newText)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    int cursorPosition = textBox.CaretIndex;
                    textBox.Text = newText;
                    textBox.CaretIndex = cursorPosition - (text.Length - newText.Length);
                }), System.Windows.Threading.DispatcherPriority.Send);
            }
        }
    }
}