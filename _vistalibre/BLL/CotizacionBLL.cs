using _vistalibre.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _vistalibre.BLL
{
    static class CotizacionBLL
    {
        private static DataBase db = new DataBase();

        public static cotizaciones Crear(int region_id, int tipo_vidrio_id, int descuento)
        {
            cotizaciones cot = new cotizaciones() { region_id = region_id, tipo_vidrio_id = tipo_vidrio_id, descuento = descuento };
            db.cotizaciones.Add(cot);
            db.SaveChanges();
            return cot;
        }
        public static int ObtenerUltimaCotizacionId()
        {
            return db.cotizaciones.ToList().LastOrDefault().id;
        }
    }
}
