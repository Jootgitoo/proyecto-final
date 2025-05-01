using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using zeroGluten.domain;
using zeroGluten.view;

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
                u = new Usuario(Convert.ToInt32(aux[0]), aux[1].ToString(), aux[2].ToString(), aux[3].ToString(), aux[4].ToString(), Convert.ToDateTime(aux[5]), aux[6].ToString());
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
            string passwordEncriptada = EncryptSHA256(usuario.Password);

           dBBroker.modifier("INSERT INTO zeroGlutenDatabase.usuario (idUsuario, nombreUsuario, primerApellido, email, password, fecha_nacimiento, sexo) " +
                  "VALUES (" + usuario.IdUsuario + ", '" + usuario.NombreUsuario + "', '" + usuario.PrimerApellido + "', '" +
                  usuario.Email + "', '" + passwordEncriptada + "', '" + usuario.FechaNacimiento.ToString("yyyy-MM-dd") + "', '" +
                  usuario.Sexo + "')");

        }


        /// <summary>
        ///   Método que encripta una cadena de texto con SHA256
        /// </summary>
        /// <param name="text"></param>
        /// <returns>
        ///     Devolvemos la cadena de texto encriptada
        /// </returns>
        static string EncryptSHA256(string text)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(text);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        ///    Método que modifica un usuario de la base de datos
        /// </summary>
        /// <param name="usuario">
        ///     Usuario que se va a modificar
        /// </param>
        public void modificarUsuario(Usuario usuario)
        {
            dBBroker.modifier("UPDATE zeroGlutenDatabase.usuario SET nombreUsuario = '"+usuario.NombreUsuario+"', primerApellido = '"+usuario.PrimerApellido+"', email = '"+usuario.Email+"', password = '"+usuario.Password+"', fechaNacimiento = '"+usuario.FechaNacimiento.ToString("yyyy-MM-dd")+"', sexo = '"+usuario.Sexo+"' WHERE idUsuario = "+usuario.IdUsuario+" ");
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
