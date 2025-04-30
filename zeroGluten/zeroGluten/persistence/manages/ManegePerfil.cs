using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeroGluten.domain;

namespace zeroGluten.persistence.manages
{
    class ManegePerfil
    {
        DBBroker dBBroker;
        int lastId;

        public ManegePerfil()
        {
            dBBroker = DBBroker.obtenerAgente();
        }


        /// <summary>
        ///     Obtiene el último id de la tabla perfil
        /// </summary>
        /// <returns>
        ///     Devolvemos el ultidmo id + 1
        /// </returns>
        public int getLastId(Usuario usuario)
        {
            List<Object> listaAux;
            listaAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idPerfil), 0) FROM zeroGlutenDatabase.perfil");

            foreach (List<Object> aux in listaAux)
            {
                lastId = Convert.ToInt32(aux[0]) + 1;
            }
            return lastId;
        }


        /// <summary>
        ///    Método que nos devuelve todos los perfiles de la base de datos
        /// </summary>
        /// <returns>
        ///     Devolvemos una lista con todos los perfiles de la bbdd
        /// </returns>
        public List<Perfil> obtenerTodosPerfiles()
        {
            List<Perfil> listaPerfiles = new List<Perfil>();

            List<Object> listaAux = DBBroker.obtenerAgente().leer("select * from zeroGlutenDatabase.perfil;");
            foreach (List<Object> aux in listaAux)
            {
                Perfil p = new Perfil();
                p = new Perfil(Convert.ToInt32(aux[0]), Convert.ToDouble(aux[1]), Convert.ToDouble(aux[2]), aux[3].ToString(), Convert.ToBoolean(aux[4]), aux[5].ToString(), aux[6].ToString(), Convert.ToBoolean(aux[7]), aux[8].ToString(), Convert.ToBoolean(aux[9]), aux[10].ToString());
                listaPerfiles.Add(p);
            }
            return listaPerfiles;
        }
    }
}
