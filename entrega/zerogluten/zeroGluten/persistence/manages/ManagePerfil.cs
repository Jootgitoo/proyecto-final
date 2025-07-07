using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeroGluten.domain;

namespace zeroGluten.persistence.manages
{
    class ManagePerfil
    {
        //ATRIBUTOS

        DBBroker dBBroker;
        int lastId;


//----------------------------------------------------------------------------------------------------------------
        //CONSTRUCTORES

        public ManagePerfil()
        {
            dBBroker = DBBroker.obtenerAgente();
        }

//----------------------------------------------------------------------------------------------------------------
        //MÉTODOS


        /// <summary>
        ///     Obtiene el último id de la tabla perfil
        /// </summary>
        /// <returns>
        ///     Devolvemos el ultidmo id + 1
        /// </returns>
        public int getLastId(Perfil perfil)
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
                p = new Perfil(Convert.ToInt32(aux[0]), Convert.ToDouble(aux[1]), Convert.ToDouble(aux[2]), Convert.ToBoolean(aux[3]), aux[4].ToString(), aux[5].ToString(), Convert.ToBoolean(aux[6]), aux[7].ToString(), Convert.ToBoolean(aux[8]), aux[9].ToString(), aux[10].ToString(), aux[11].ToString(),  Convert.ToInt32(aux[12]) );
                listaPerfiles.Add(p);
            }
            return listaPerfiles;
        }


        /// <summary>
        ///     Método que inserta un perfil en la base de datos
        /// </summary>
        /// <param name="perfil"></param>
        public void insertarPerfil(Perfil perfil)
        {

            int actividadFisica = 0;
            int medicacion = 0;
            int fumador = 0;

            string peso = perfil.Peso.ToString(System.Globalization.CultureInfo.InvariantCulture);
            string altura = perfil.Altura.ToString(System.Globalization.CultureInfo.InvariantCulture);

            if (perfil.ActividadFisica.Equals(true))
            {
                actividadFisica = 1;
            }


            if (perfil.Medicacion.Equals(true))
            {
                medicacion = 1;
            }

            if (perfil.Fumador.Equals(true))
            {
                fumador = 1;
            }

            dBBroker.modifier("INSERT INTO zeroGlutenDatabase.perfil " +
                "(peso, altura, actividadFisica, frecuenciaActividadFisica, condicionMedica, medicacion, " +
                "puntuacionAlimentacion, fumador, enfermedades, intolerancias, tipoDieta, idUsuario) " +
                "VALUES (" + peso + ", " + altura + ", " + actividadFisica + ", '" +
                perfil.FrecuenciaActividad + "', '" + perfil.CondicionMedica + "', " + medicacion + ", '" +
                perfil.PuntuacionAlimentacion + "', " + fumador + ", '" + perfil.Enfermedades + "', '" +
                perfil.Intolerancias + "', '" + perfil.TipoDieta + "', " + perfil.IdUsuario + ");");

        }


        /// <summary>
        ///    Método que modifica un perfil de la base de datos
        /// </summary>
        /// <param name="perfil"></param>
        public void modificarPerfil(Perfil perfil)
        {
            int actividadFisica = 0;
            int medicacion = 0;
            int fumador = 0;
            if (perfil.ActividadFisica == true)
            {
                actividadFisica = 1;
            }
            if (perfil.Medicacion == true)
            {
                medicacion = 1;
            }
            if (perfil.Fumador == true)
            {
                fumador = 1;
            }

            dBBroker.modifier("UPDATE zeroGlutenDatabase.perfil SET peso = " + perfil.Peso + ", altura = " + perfil.Altura + ", tipoDieta = '" + perfil.TipoDieta + "', actividadFisica = " + actividadFisica + ", frecuenciaActividad = '" + perfil.FrecuenciaActividad + "', condicionMedica = '" + perfil.CondicionMedica + "', medicacion = " + medicacion + ", puntuacionAlimentacion = '" + perfil.PuntuacionAlimentacion + "', fumador = " + fumador + ", enfermedades = '" + perfil.Enfermedades + "' WHERE idPerfil = " + perfil.IdPerfil);

        }


        /// <summary>
        ///    Método que elimina un perfil de la base de datos
        /// </summary>
        /// <param name="perfil"></param>
        public void eliminarPerfil(Perfil perfil)
        {
            dBBroker.modifier("DELETE FROM zeroGlutenDatabase.perfil WHERE idPerfil = " + perfil.IdPerfil);
        }

    }
}
