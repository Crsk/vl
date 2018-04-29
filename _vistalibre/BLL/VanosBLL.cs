using _vistalibre.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _vistalibre.BLL
{
    static class VanosBLL
    {
        private static DataBase db = new DataBase();

        public static void Crear(int cantidad_aperturas, decimal ancho, decimal alto, int cotizacion_id)
        {
            db.vanos.Add(new vanos() { cantidad_aperturas = cantidad_aperturas, ancho = ancho, alto = alto, cotizacion_id = cotizacion_id });
            db.SaveChanges();
        }
    }
}
