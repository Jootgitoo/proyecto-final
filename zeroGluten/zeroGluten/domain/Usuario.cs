using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using zeroGluten.persistence.manages;

namespace zeroGluten.domain
{
    class Usuario
    {
        //ATRIBUTOS

        ManageUsuario mu;

        private int idUsuario;
        private string nombreUsuario;
        private string primerApellido;
        private string email;
        private string password;
        private DateTime fechaNacimiento;
        private string sexo;
        private double peso;
        private double altura;
        private string tipoDieta;

        //-------------------------------------------------------------------------------------------------------------------
        //CONSTRUCTORES
        public Usuario()
        {
            mu = new ManageUsuario();
        }

        public Usuario(int idUsuario, string nombreUsuario, string primerApellido, string email, string password, DateTime fechaNacimiento, string sexo, double peso, double altura, string tipo_dieta)
        {

            mu = new ManageUsuario();

            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.primerApellido = primerApellido;
            this.email = email;
            this.password = password;
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
            this.altura = altura;
            this.tipoDieta = tipo_dieta;
        }

        public Usuario(string nombreUsuario, string primerApellido, string email, string password, DateTime fechaNacimiento, string sexo, double peso, double altura, string tipo_dieta)
        {
            mu = new ManageUsuario();

            this.nombreUsuario = nombreUsuario;
            this.primerApellido = primerApellido;
            this.email = email;
            this.password = password;
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
            this.altura = altura;
            this.tipoDieta = tipo_dieta;
        }

//-------------------------------------------------------------------------------------------------
        //MÉTODOS

        public List<Usuario> obtenerTodosUsuarios()
        {
            List<Usuario> listaTodosUsuarios = mu.obtenerTodosUsuarios();

            return listaTodosUsuarios;
        }

//-------------------------------------------------------------------------------------------------
        //GETTERS Y SETTERS
        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string PrimerApellido { get => primerApellido; set => primerApellido = value;}
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
        public string Sexo { get => sexo; set => sexo = value; }
        public double Peso { get => peso; set => peso = value; }
        public double Altura { get => altura; set => altura = value; }
        public string TipoDieta { get => tipoDieta; set => tipoDieta = value; }


    }
}
