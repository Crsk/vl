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
        public decimal VanosTotalAncho { get; set; }
        public decimal VanosTotalAlto { get; set; }
        public decimal VanosTotalArea { get; set; }

        public int TipoVidrioPrecio { get; set; }

        public int TasaImprevisto { get; set; }



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

            btnNuevaCotizacion.Click += BtnNuevaCotizacion_Click;

            //btnAgregarCosto.Click += BtnAgregarCosto_Click;

            btnAgregarSueldo.Click += BtnAgregarSueldo_Click;

            txtCantVanos.Text = "1";

            cbCostos.ItemsSource = TipoCostoBLL.ObtenerTipoCostos();
            cbCostos.DisplayMemberPath = "nombre";
            cbCostos.SelectionChanged += CbCostos_SelectionChanged;

            cbSueldos.ItemsSource = TipoCostoBLL.ObtenerTipoSueldos();
            cbSueldos.DisplayMemberPath = "nombre";
        }

        private void CbCostos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((cbCostos.SelectedItem as tipo_costo).nombre.ToLower())
            {
                case "metro lineal sistema":
                    txtCostoFinalCosto.IsEnabled = false;
                    if (txtValorInicialCosto.Text == "") return;
                    int valorInicial = Convert.ToInt32(txtValorInicialCosto.Text);
                    btnAgregarCosto.Click += (se, a) =>
                    {
                        var id = new ItemDetalle() { ValorInicial = Convert.ToInt32(txtValorInicialCosto.Text), CostoFinal = (int)(valorInicial * VanosTotalAncho), Desgloce = (cbCostos.SelectedItem as tipo_costo).nombre };
                        id.btnQuitarDetalle.Click += (se2, a2) => spDetalle.Children.Remove(id);
                        spDetalle.Children.Add(id);
                    };
                    break;
                case "area vano":
                    txtValorInicialCosto.Text = $"{TipoVidrioPrecio}";
                    txtCostoFinalCosto.Text = $"{VanosTotalArea * TipoVidrioPrecio}";
                    btnAgregarCosto.Click += (se, a) =>
                    {
                        var id = new ItemDetalle() { ValorInicial = TipoVidrioPrecio, CostoFinal = (int)(VanosTotalArea * TipoVidrioPrecio), Desgloce = (cbCostos.SelectedItem as tipo_costo).nombre };
                        id.btnQuitarDetalle.Click += (se2, a2) => spDetalle.Children.Remove(id);
                        spDetalle.Children.Add(id);
                    };
                    break;
                case "tasa imprevisto":
                    txtValorInicialCosto.Text = $"{TasaImprevisto}";
                    txtCostoFinalCosto.Text = $"{TasaImprevisto}";
                    btnAgregarCosto.Click += (se, a) =>
                    {
                        var id = new ItemDetalle() { ValorInicial = TasaImprevisto, CostoFinal = TasaImprevisto, Desgloce = (cbCostos.SelectedItem as tipo_costo).nombre };
                        id.btnQuitarDetalle.Click += (se2, a2) => spDetalle.Children.Remove(id);
                        spDetalle.Children.Add(id);
                    };
                    break;
                default:
                    txtCostoFinalCosto.IsEnabled = true;
                    break;
            }
        }

        private void BtnAgregarSueldo_Click(object sender, RoutedEventArgs e)
        {
            var id = new ItemDetalle() { ValorInicial = Convert.ToInt32(txtValorInicialSueldo.Text), CostoFinal = Convert.ToInt32(txtCostoFinalSueldo.Text), Desgloce = (cbSueldos.SelectedItem as tipo_costo).nombre };
            id.btnQuitarDetalle.Click += (se, a) => spDetalle.Children.Remove(id);
            spDetalle.Children.Add(id);
        }

        /*
        private void BtnAgregarCosto_Click(object sender, RoutedEventArgs e)
        {
            switch ((cbCostos.SelectedItem as tipo_costo).nombre.ToLower())
            {
                case "metro lineal sistema":
                    int valorInicial = Convert.ToInt32(txtValorInicialCosto.Text);
                    var id = new ItemDetalle() { ValorInicial = Convert.ToInt32(txtValorInicialCosto.Text), CostoFinal = (int)(valorInicial * VanosTotalAncho), Desgloce = (cbCostos.SelectedItem as tipo_costo).nombre };
                    id.btnQuitarDetalle.Click += (se, a) => spDetalle.Children.Remove(id);
                    spDetalle.Children.Add(id);
                    break;
                case "area vano":
                    int valorInicial = Convert.ToInt32(txtValorInicialCosto.Text);
                    var id = new ItemDetalle() { ValorInicial = Convert.ToInt32(txtValorInicialCosto.Text), CostoFinal = (int)(valorInicial * VanosTotalAncho), Desgloce = (cbCostos.SelectedItem as tipo_costo).nombre };
                    id.btnQuitarDetalle.Click += (se, a) => spDetalle.Children.Remove(id);
                    spDetalle.Children.Add(id);
                    break;
                case "tasa imprevisto":
                    break;
                default:
                    txtCostoFinalCosto.IsEnabled = true;
                    break;
            }

        }
        */
        private void BtnNuevaCotizacion_Click(object sender, RoutedEventArgs e)
        {
            int region_id = (cbRegiones.SelectedItem as regiones).id;
            int tipo_vidrio_id = (cbTipoVidrio.SelectedItem as tipo_vidrio).id;
            int descuento = 0; // TODO - implementar
            cotizaciones cot = CotizacionBLL.Crear(region_id, tipo_vidrio_id, descuento);

            spVanos.Children.OfType<ItemVano>().ToList().ForEach(iv =>
            {
                VanosBLL.Crear(Convert.ToInt32(iv.txtCantAperturas.Text), Convert.ToDecimal(iv.txtAncho.Text), Convert.ToDecimal(iv.txtAlto.Text), cot.id);
            });
        }

        private void BtnCalcularVanos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                decimal totalAnchoVanos = 0;
                decimal totalAltoVanos = 0;
                decimal totalAreaVanos = 0;
                int cantidadVanos = 0;

                spVanos.Children.OfType<ItemVano>().ToList().ForEach(iv =>
                {
                    if (iv.txtAncho.Text != "")
                        totalAnchoVanos += Convert.ToDecimal(iv.txtAncho.Text);
                    if (iv.txtAlto.Text != "")
                        totalAltoVanos += Convert.ToDecimal(iv.txtAlto.Text);
                    if (iv.txtAncho.Text != "" && iv.txtAlto.Text != "")
                    {
                        totalAreaVanos += Convert.ToDecimal(iv.txtAncho.Text) * Convert.ToDecimal(iv.txtAlto.Text);
                        cantidadVanos++;
                    }
                });

                VanosTotalAncho = totalAnchoVanos;
                VanosTotalAlto = totalAltoVanos / cantidadVanos;
                VanosTotalArea = totalAreaVanos;

                wrapValores.Children.OfType<ItemValor>().Where(x => x.Procedencia == "calculo_vanos").ToList().ForEach(item => wrapValores.Children.Remove(item));
                wrapValores.Children.Insert(0, new ItemValor() { Nombre = "Ancho vanos", ValorDecimal = VanosTotalAncho, Procedencia = "calculo_vanos" });
                wrapValores.Children.Insert(0, new ItemValor() { Nombre = "Alto vanos", ValorDecimal = VanosTotalAlto, Procedencia = "calculo_vanos" });
                wrapValores.Children.Insert(0, new ItemValor() { Nombre = "Area vanos", ValorDecimal = VanosTotalArea, Procedencia = "calculo_vanos" });
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
            TipoVidrioPrecio = tv.precio;

        }

        private void CbRegiones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var cb = (ComboBox)sender;
            regiones reg = cb.SelectedItem as regiones;
            wrapValores.Children.OfType<ItemValor>().Where(x => x.Procedencia == "region").ToList().ForEach(item => wrapValores.Children.Remove(item));
            wrapValores.Children.Add(new ItemValor() { Nombre = $"Costo viaje", ValorInt = reg.costo_viaje, Procedencia = "region" });
            wrapValores.Children.Add(new ItemValor() { Nombre = $"Taza imprevisto", ValorInt = reg.taza_imprevisto, Procedencia = "region" });

            TasaImprevisto = reg.taza_imprevisto;
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
