using System.Windows.Controls;

namespace _vistalibre.items
{
    public partial class ItemDetalle : UserControl
    {
        public int ValorInicial { get; set; }
        public int CostoFinal { get; set; }
        public string Desgloce { get; set; }

        public ItemDetalle()
        {
            InitializeComponent();
            Loaded += ItemDetalle_Loaded;
        }

        private void ItemDetalle_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            lbValorInicial.Content = $"{ValorInicial}";
            lbCostoFinal.Content = $"{CostoFinal}";
            lbDesgloce.Content = Desgloce;
        }
    }
}
