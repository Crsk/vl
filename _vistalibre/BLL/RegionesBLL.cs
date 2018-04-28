using _vistalibre.model;
using System.Collections.Generic;
using System.Linq;

namespace _vistalibre.BLL
{
    static class RegionesBLL
    {
        private static DataBase db = new DataBase();

        public static List<regiones> ObtenerTodas()
        {
            return db.regiones.ToList();
        }

        public static List<regiones> ObtenerTodasConCostoViaje()
        {
            return db.regiones.Where(x => x.costo_viaje != 0 && x.costo_viaje != null).ToList();
        }
    }
}
