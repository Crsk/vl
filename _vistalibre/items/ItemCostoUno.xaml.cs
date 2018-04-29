using _vistalibre.BLL;
using System.Windows.Controls;

namespace _vistalibre.items
{
    public partial class ItemCostoUno : UserControl
    {
        public int ValorInicial { get; set; }
        public int CostoFinal { get; set; }
        public string Glosa { get; set; }
        public bool EsSueldo { get; set; }

        public ItemCostoUno()
        {
            InitializeComponent();

            Loaded += ItemCostoUno_Loaded;

        }

        private void ItemCostoUno_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (EsSueldo == true)
                cbGlosa.ItemsSource = TipoCostoBLL.ObtenerTipoSueldos();
            else
                cbGlosa.ItemsSource = TipoCostoBLL.ObtenerTipoCostos();

            cbGlosa.DisplayMemberPath = "nombre";
            txtValorInicial.Text = $"{ValorInicial}";
            txtCostoFinal.Text = $"{CostoFinal}";
        }
    }
}
