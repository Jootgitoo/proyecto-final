using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zeroGluten.persistence.manages;

namespace zeroGluten.domain
{
    class Perfil
    {
        //ATRIBUTOS
        ManagePerfil mp;

        private int idPerfil;
        private double peso;
        private double altura;
        private bool actividadFisica;
        private string frecuenciaActividad;
        private string condicionMedica;
        private bool medicacion;
        private string puntuacionAlimentacion;
        private bool fumador;
        private string enfermedades;
        private string intolerancias;
        private string tipoDieta;
        private int idUsuario;


//-------------------------------------------------------------------------------------------------------------------
        //CONSTRUCTORES

        public Perfil()
        {
            mp = new ManagePerfil();
            this.idPerfil = mp.getLastId(this);
        }

        public Perfil(int idPerfil, double peso, double altura, bool actividadFisica, string frecuenciaActividad, string condicionMedica, bool medicacion, string puntuacionAlimentacion, bool fumador, string enfermedades, string intolerancias, string tipoDieta, int idUsuario)
        {
            mp = new ManagePerfil();

            this.idPerfil = idPerfil;
            this.peso = peso;
            this.altura = altura;
            this.actividadFisica = actividadFisica;
            this.frecuenciaActividad = frecuenciaActividad;
            this.condicionMedica = condicionMedica;
            this.medicacion = medicacion;
            this.puntuacionAlimentacion = puntuacionAlimentacion;
            this.fumador = fumador;
            this.enfermedades = enfermedades;
            this.intolerancias = intolerancias;
            this.tipoDieta = tipoDieta;
            this.idUsuario = idUsuario;

        }

        public Perfil(double peso, double altura, bool actividadFisica, string frecuenciaActividad, string condicionMedica, bool medicacion, string puntuacionAlimentacion, bool fumador, string enfermedades, string intolerancias, string tipoDieta, int idUsuario)
        {
            mp = new ManagePerfil();

            this.idPerfil = mp.getLastId(this);
            this.peso = peso;
            this.altura = altura;
            this.actividadFisica = actividadFisica;
            this.frecuenciaActividad = frecuenciaActividad;
            this.condicionMedica = condicionMedica;
            this.medicacion = medicacion;
            this.puntuacionAlimentacion = puntuacionAlimentacion;
            this.fumador = fumador;
            this.enfermedades = enfermedades;
            this.intolerancias = intolerancias;
            this.tipoDieta = tipoDieta;
            this.idUsuario = idUsuario;

        }


//-------------------------------------------------------------------------------------------------
        //MÉTODOS

        /// <summary>
        ///   Método que obtiene todos los perfiles de la base de datos
        /// </summary>
        /// <returns>
        ///     Lista de perfiles de la base de datos
        /// </returns>
        public List<Perfil> obtenerTodosPerfiles()
        {
            List<Perfil> listaTodosPerfiles = mp.obtenerTodosPerfiles();
            return listaTodosPerfiles;
        }


        /// <summary>
        ///   Método que inserta un perfil de la base de datos
        /// </summary>
        public void insertarPerfil()
        {
            mp.insertarPerfil(this);
        }

        //-------------------------------------------------------------------------------------------------
        //GETTERS Y SETTERS
        public int IdPerfil { get => idPerfil; set => idPerfil = value; }
        public double Peso { get => peso; set => peso = value; }
        public double Altura { get => altura; set => altura = value; }
        public string TipoDieta { get => tipoDieta; set => tipoDieta = value; }
        public bool ActividadFisica { get => actividadFisica; set => actividadFisica = value; }
        public string FrecuenciaActividad { get => frecuenciaActividad; set => frecuenciaActividad = value; }
        public string CondicionMedica { get => condicionMedica; set => condicionMedica = value; }
        public bool Medicacion { get => medicacion; set => medicacion = value; }
        public string PuntuacionAlimentacion { get => puntuacionAlimentacion; set => puntuacionAlimentacion = value; }
        public bool Fumador { get => fumador; set => fumador = value; }
        public string Enfermedades { get => enfermedades; set => enfermedades = value; }
        public int IdUsuario { get => idUsuario; set => idUsuario = value; } 
        public string Intolerancias { get => intolerancias; set => intolerancias = value; }

    }
}
