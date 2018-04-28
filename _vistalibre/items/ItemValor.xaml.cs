using System;
using System.Windows;
using System.Windows.Controls;

namespace _vistalibre.items
{
    public partial class ItemValor : UserControl
    {
        public string Nombre { get; set; }
        public int? ValorInt { get; set; }
        public decimal? ValorDecimal { get; set; }
        public string Procedencia { get; set; }

        public ItemValor()
        {
            InitializeComponent();
            Loaded += (se, a) => 
            {
                try
                {
                    lbNombre.Content = $"{Nombre}: ";
                    if (ValorInt != null && ValorInt != 0)
                    {
                        int _valorInt = Convert.ToInt32(ValorInt);
                        lbValor.Content = $"${_valorInt.ToString("###,###")}";
                    }
                    if (ValorDecimal != null && ValorDecimal != 0)
                    {
                        lbValor.Content = ValorDecimal;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error al convertir valor");
                }
            };
        }
    }
}
