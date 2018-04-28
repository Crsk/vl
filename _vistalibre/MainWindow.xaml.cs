using _vistalibre.BLL;
using _vistalibre.items;
using _vistalibre.model;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace _vistalibre
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            cbRegiones.ItemsSource = RegionesBLL.ObtenerTodasConCostoViaje();
            cbRegiones.DisplayMemberPath = "nombre";

            cbTipoVidrio.ItemsSource = TipoVidrioBLL.ObtenerTodos();
            cbTipoVidrio.DisplayMemberPath = "nombre";

            txtCantVanos.TextChanged += TxtCantVanos_TextChanged;

            cbTipoVidrio.SelectionChanged += CbTipoVidrio_SelectionChanged;
            cbRegiones.SelectionChanged += CbRegiones_SelectionChanged;

            btnCalcularVanos.Click += BtnCalcularVanos_Click;

            Loaded += MainWindow_Loaded;

            txtCantVanos.Text = "1";
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var icu = new ItemCostoUno() { Glosa = "Metro lineal sistema", ValorInicial = 1 };
            //spCostosUno.Children.Add()
        }

        private void BtnCalcularVanos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal totalAnchoVanos = 0;
                decimal totalAltoVanos = 0;

                spVanos.Children.OfType<ItemVano>().Where(x => x.txtAncho.Text != "").ToList().ForEach(iv => totalAnchoVanos += Convert.ToDecimal(iv.txtAncho.Text));
                spVanos.Children.OfType<ItemVano>().Where(x => x.txtAlto.Text != "").ToList().ForEach(iv => totalAltoVanos += Convert.ToDecimal(iv.txtAlto.Text));
                MessageBox.Show($"Total ancho: {totalAnchoVanos}, Total alto: {totalAltoVanos}");
                wrapValores.Children.OfType<ItemValor>().Where(x => x.Procedencia == "calculo_vanos").ToList().ForEach(item => wrapValores.Children.Remove(item));
                wrapValores.Children.Insert(0, new ItemValor() { Nombre = "Ancho vanos", ValorDecimal = totalAnchoVanos, Procedencia = "calculo_vanos" });
                wrapValores.Children.Insert(0, new ItemValor() { Nombre = "Alto vanos", ValorDecimal = totalAltoVanos, Procedencia = "calculo_vanos" });
            }
            catch
            {
            }
        }

        private void CbTipoVidrio_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = (ComboBox)sender;
            tipo_vidrio tv = cb.SelectedItem as tipo_vidrio;
            wrapValores.Children.OfType<ItemValor>().Where(x => x.Procedencia == "tipo_vidrio").ToList().ForEach(item => wrapValores.Children.Remove(item));
            wrapValores.Children.Insert(0, new ItemValor() { Nombre = $"{tv.nombre}", ValorInt = tv.precio, Procedencia = "tipo_vidrio" });
            
        }

        private void CbRegiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = (ComboBox)sender;
            regiones reg = cb.SelectedItem as regiones;
            wrapValores.Children.OfType<ItemValor>().Where(x => x.Procedencia == "region").ToList().ForEach(item => wrapValores.Children.Remove(item));
            wrapValores.Children.Add(new ItemValor() { Nombre = $"Costo viaje", ValorInt = reg.costo_viaje, Procedencia = "region" });
            wrapValores.Children.Add(new ItemValor() { Nombre = $"Taza imprevisto", ValorInt = reg.taza_imprevisto, Procedencia = "region" });
        }

        private void TxtCantVanos_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtCantVanos.Text != "")
                {
                    spVanos.Children.Clear();
                    int cantidadVanos = Convert.ToInt32(txtCantVanos.Text);
                    for (int i = 1; i <= cantidadVanos; i++)
                    {
                        var iv = new ItemVano($"Vano {i}");
                        spVanos.Children.Add(new ItemVano($"Vano {i}"));
                    }
                    spBtnCalcularVanos.Children.Clear();
                    spBtnCalcularVanos.Children.Add(btnCalcularVanos);
                }
                else
                {
                    spVanos.Children.Clear();
                    spBtnCalcularVanos.Children.Clear();
                }
            }
            catch
            {
            }
        }
        

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
