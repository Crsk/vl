using _vistalibre.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _vistalibre.BLL
{
    static class TipoVidrioBLL
    {
        private static DataBase db = new DataBase();

        public static List<tipo_vidrio> ObtenerTodos()
        {
            return db.tipo_vidrio.ToList();
        }
    }
}
