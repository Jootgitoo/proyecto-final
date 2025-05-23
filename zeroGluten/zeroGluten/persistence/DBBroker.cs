using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeroGluten.persistence
{
    internal class DBBroker
    {
        //ATRIBUTOS
        private static DBBroker _instancia;
        private static MySql.Data.MySqlClient.MySqlConnection conexion;
        private String cadenaConexion;


        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //CONSTRUCTORES

        public DBBroker()
        {
            try
            {
                if (cadenaConexion == null)
                {
                    string rutaConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
                    string json = File.ReadAllText(rutaConfig);
                    Config config = JsonConvert.DeserializeObject<Config>(json);

                    cadenaConexion = $"server={config.server};database={config.database};uid={config.user};pwd={config.password}";
                }

                DBBroker.conexion = new MySql.Data.MySqlClient.MySqlConnection(cadenaConexion);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al leer el archivo de configuración: " + e.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //MÉTODOS

        /// <summary>
        ///     Obtenemos la instancia de la clase
        /// </summary>
        /// <returns></returns>
        public static DBBroker obtenerAgente()
        {
            if (DBBroker._instancia == null)
            {
                DBBroker._instancia = new DBBroker();
            }
            return DBBroker._instancia;
        }


        /// <summary>
        ///     Método preparado para hacer una SELECT en bbdd
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>
        ///     Lista con los objetos leidos de la lista
        /// </returns>
        public List<Object> leer(String sql)
        {
            List<Object> resultado = new List<object>();
            List<Object> fila;
            int i;
            MySql.Data.MySqlClient.MySqlDataReader reader;
            MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, DBBroker.conexion);
            conectar();
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                fila = new List<Object>();
                for (i = 0; i <= reader.FieldCount - 1; i++)
                {
                    fila.Add(reader[i].ToString());
                }
                resultado.Add(fila);
            }
            desconectar();
            return resultado;
        }


        /// <summary>
        ///     Método que se va utilizar para hacer sentencias de tipo insert, update y delete
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>
        ///     Numero de filas afectadas
        /// </returns>
        public int modifier(String sql)
        {
            MySql.Data.MySqlClient.MySqlCommand com = new MySql.Data.MySqlClient.MySqlCommand(sql, DBBroker.conexion);
            int resultado;
            conectar();
            resultado=com.ExecuteNonQuery();
            desconectar();
            return resultado;
        }


        /// <summary>
        ///     Conectar la conexion
        /// </summary>
        public void conectar()
        {
            if (DBBroker.conexion.State == System.Data.ConnectionState.Closed)
            {
                DBBroker.conexion.Open();
            }
        }


        /// <summary>
        ///     Desconectar la conexion
        /// </summary>
        public void desconectar()
        {
            if (DBBroker.conexion.State == System.Data.ConnectionState.Open)
            {
                DBBroker.conexion.Close();
            }
        }
    }
}
