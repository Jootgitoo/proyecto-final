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
        private string tipoDieta;
        private bool actividadFisica;
        private string frecuenciaActividad;
        private string condicionMedica;
        private bool medicacion;
        private string puntuacionAlimentacion;
        private bool fumador;
        private string enfermedades;


//-------------------------------------------------------------------------------------------------------------------
        //CONSTRUCTORES

        public Perfil()
        {
            mp = new ManagePerfil();
            this.idPerfil = mp.getLastId(this);
        }

        public Perfil(int idPerfil, double peso, double altura, string tipoDieta, bool actividadFisica, string frecuenciaActividad, string condicionMedica, bool medicacion, string puntuacionAlimentacion, bool fumador, string enfermedades)
        {
            mp = new ManagePerfil();

            idPerfil = idPerfil;
            peso = peso;
            altura = altura;
            tipoDieta = tipoDieta;
            actividadFisica = actividadFisica;
            frecuenciaActividad = frecuenciaActividad;
            condicionMedica = condicionMedica;
            medicacion = medicacion;
            puntuacionAlimentacion = puntuacionAlimentacion;
            fumador = fumador;
            enfermedades = enfermedades;
            
        }

        public Perfil( double peso, double altura, string tipoDieta, bool actividadFisica, string frecuenciaActividad, string condicionMedica, bool medicacion, string puntuacionAlimentacion, bool fumador, string enfermedades)
        {
            mp = new ManagePerfil();

            peso = peso;
            altura = altura;
            tipoDieta = tipoDieta;
            actividadFisica = actividadFisica;
            frecuenciaActividad = frecuenciaActividad;
            condicionMedica = condicionMedica;
            medicacion = medicacion;
            puntuacionAlimentacion = puntuacionAlimentacion;
            fumador = fumador;
            enfermedades = enfermedades;

        }


//-------------------------------------------------------------------------------------------------
        //MÉTODOS
        public List<Perfil> obtenerTodosPerfiles()
        {
            List<Perfil> listaTodosPerfiles = mp.obtenerTodosPerfiles();
            return listaTodosPerfiles;
        }

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

    }
}
