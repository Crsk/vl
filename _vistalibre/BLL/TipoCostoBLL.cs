using _vistalibre.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _vistalibre.BLL
{
    static class TipoCostoBLL
    {
        private static DataBase db = new DataBase();

        public static List<tipo_costo> ObtenerTipoCostos()
        {
            return db.tipo_costo.Where(x => x.es_sueldo == false).ToList();
        }

        public static List<tipo_costo> ObtenerTipoSueldos()
        {
            return db.tipo_costo.Where(x => x.es_sueldo == true).ToList();
        }
    }
}
