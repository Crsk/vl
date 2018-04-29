using _vistalibre.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _vistalibre.BLL
{
    static class CostosBLL
    {
        private static DataBase db = new DataBase();

        public static void Crear(string nombre, int valor_inicial, int costo_final, int tipo_costo_id, int cotizacion_id)
        {
            db.costos.Add(new costos() { valor_inicial = valor_inicial, costo_final = costo_final, tipo_costo_id = tipo_costo_id, cotizacion_id = cotizacion_id });
            db.SaveChanges();
        }
    }
}
