using System.Windows.Controls;

namespace _vistalibre.items
{
    public partial class ItemCostoUno : UserControl
    {
        public int ValorInicial { get; set; }
        public int CostoFinal { get; set; }
        public string Glosa { get; set; }

        public ItemCostoUno()
        {
            InitializeComponent();
            lbGlosa.Content = Glosa;
            txtValorInicial.Text = $"{ValorInicial}";
            txtCostoFinal.Text = $"{CostoFinal}";
        }
    }
}
