using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _vistalibre.items
{
    public partial class ItemVano : UserControl
    {
        public int CantAperturas { get; set; }

        public ItemVano(string titulo)
        {
            InitializeComponent();
            lbTitulo.Content = titulo;
            txtAlto.TextChanged += TxtAlto_TextChanged;
            txtAncho.TextChanged += TxtAncho_TextChanged;
        }

        private void TxtAncho_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAncho.Text != "" && txtAlto.Text != "")
            {
                try
                {
                    decimal ancho = Convert.ToDecimal(txtAncho.Text);
                    decimal alto = Convert.ToDecimal(txtAlto.Text);
                    lbPaneles.Content = $"{Math.Round(ancho / 0.6m, 0)}";
                    lbArea.Content = $"{Math.Round(alto * ancho, 1)}";

                }
                catch
                {
                    lbPaneles.Content = "";
                    lbArea.Content = "";
                }
            }
            else
            {
                lbPaneles.Content = "";
                lbArea.Content = "";
            }
        }

        private void TxtAlto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtAncho.Text != "" && txtAlto.Text != "")
            {
                try
                {
                    decimal ancho = Convert.ToDecimal(txtAncho.Text);
                    decimal alto = Convert.ToDecimal(txtAlto.Text);
                    lbPaneles.Content = $"{Math.Round(ancho / 0.6m, 0)}";
                    lbArea.Content = $"{Math.Round(alto * ancho, 1)}";
                }
                catch
                {
                    lbPaneles.Content = "";
                    lbArea.Content = "";
                }
            }
            else
            {
                lbPaneles.Content = "";
                lbArea.Content = "";
            }
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
