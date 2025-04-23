using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeroGluten.domain;

namespace zeroGluten.persistence.manages
{
    class ManageUsuario
    {
        DBBroker dBBroker;
        int lastId;

        public ManageUsuario()
        {
            dBBroker = DBBroker.obtenerAgente();
        }

        /// <summary>
        ///     Obtiene el último id de la tabla usuario
        /// </summary>
        /// <returns>
        ///     Devolvemos el ultidmo id + 1
        /// </returns>
        public int getLastId(Usuario usuario)
        {
            List<Object> listaAux;
            listaAux = DBBroker.obtenerAgente().leer("SELECT COALESCE(MAX(idUsuario), 0) FROM zeroGlutenDatabase.usuario");

            foreach (List<Object> aux in listaAux)
            {
                lastId = Convert.ToInt32(aux[0]) + 1;
            }
            return lastId;
        }


        /// <summary>
        ///     Método que nos devuelve todos los usuarios de la base de datos
        /// </summary>
        /// <returns>
        ///     Devolvemos una lista con todos los usuarios de la bbdd
        /// </returns>
        public List<Usuario> obtenerTodosUsuarios()
        {
            List<Usuario> listaUsuarios = new List<Usuario>();

            List<Object> listaAux = DBBroker.obtenerAgente().leer("select * from zeroGlutenDatabase.usuario;");

            foreach (List<Object> aux in listaAux)
            {
                Usuario u = new Usuario();
                u = new Usuario(Convert.ToInt32(aux[0]), aux[1].ToString(), aux[2].ToString(), aux[3].ToString(), aux[4].ToString(), Convert.ToDateTime(aux[5]), aux[6].ToString(), Convert.ToDouble(aux[7]), Convert.ToDouble(aux[8]), aux[9].ToString());
                listaUsuarios.Add(u);
            }
            return listaUsuarios;
        }


        /// <summary>
        ///     Método que inserta un usuario en la base de datos
        /// </summary>
        /// <param name="usuario">
        ///     Usuario que se va a insertar
        /// </param>
        public void insertarUsuario(Usuario usuario)
        {
            string peso = Convert.ToString(usuario.Peso, CultureInfo.InvariantCulture);
            string altura = Convert.ToString(usuario.Altura, CultureInfo.InvariantCulture);

            dBBroker.modifier("INSERT INTO zeroGlutenDatabase.usuario VALUES ("+usuario.IdUsuario+", '"+usuario.NombreUsuario+"', '"+usuario.PrimerApellido+"', '"+usuario.Email+"', '"+usuario.Password+"', '"+usuario.FechaNacimiento.ToString("yyyy-MM-dd")+"', '"+usuario.Sexo+"', '"+peso+"', '"+altura+"', '"+usuario.TipoDieta+ "' )");
        }

        /// <summary>
        ///    Método que modifica un usuario de la base de datos
        /// </summary>
        /// <param name="usuario">
        ///     Usuario que se va a modificar
        /// </param>
        public void modificarUsuario(Usuario usuario)
        {
            dBBroker.modifier("UPDATE zeroGlutenDatabase.usuario SET nombreUsuario = '"+usuario.NombreUsuario+"', primerApellido = '"+usuario.PrimerApellido+"', email = '"+usuario.Email+"', password = '"+usuario.Password+"', fechaNacimiento = '"+usuario.FechaNacimiento.ToString("yyyy-MM-dd")+"', sexo = '"+usuario.Sexo+"', peso = '"+usuario.Peso+"', altura = '"+usuario.Altura+"', tipo_dieta = '"+usuario.TipoDieta+"'  WHERE idUsuario = "+usuario.IdUsuario+" ");
        }


        /// <summary>
        ///    Método que elimina un usuario de la base de datos
        /// </summary>
        /// <param name="usuario">
        ///     Usuario que se va a eliminar
        /// </param>
        public void eliminarUsuario(Usuario usuario)
        {
            dBBroker.modifier("DELETE FROM zeroGlutenDatabase.usuario WHERE idUsuario = " + usuario.IdUsuario + " ");

        }
    }
}
