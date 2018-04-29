using _vistalibre.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _vistalibre.BLL
{
    static class ComplementariosBLL
    {
        private static DataBase db = new DataBase();

        public static void Crear(int monto, string detalle, int cotizacion_id)
        {
            db.complementarios.Add(new complementarios() { monto = monto, detalle = detalle, cotizacion_id = cotizacion_id });
            db.SaveChanges();
        }
    }
}
