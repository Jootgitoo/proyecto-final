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
        

//-------------------------------------------------------------------------------------------------------------------
        //CONSTRUCTORES
        public Usuario()
        {
            mu = new ManageUsuario();
            this.idUsuario = mu.getLastId(this);

        }

        public Usuario(int idUsuario, string nombreUsuario, string primerApellido, string email, string password, DateTime fechaNacimiento, string sexo)
        { 

            mu = new ManageUsuario();

            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.primerApellido = primerApellido;
            this.email = email;
            this.password = password;
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
            
        }

        public Usuario(string nombreUsuario, string primerApellido, string email, string password, DateTime fechaNacimiento, string sexo)
        {
            mu = new ManageUsuario();

            this.idUsuario = mu.getLastId(this);
            this.nombreUsuario = nombreUsuario;
            this.primerApellido = primerApellido;
            this.email = email;
            this.password = password;
            this.fechaNacimiento = fechaNacimiento;
            this.sexo = sexo;
            
        }

        //-------------------------------------------------------------------------------------------------
        //MÉTODOS

        /// <summary>
        ///   Método que nos devuelve todos los usuarios de la bbdd
        /// </summary>
        /// <returns>
        ///     Devolvemos una lista con todos los usuarios de la bbdd
        /// </returns>
        public List<Usuario> obtenerTodosUsuarios()
        {
            List<Usuario> listaTodosUsuarios = mu.obtenerTodosUsuarios();

            return listaTodosUsuarios;
        }


        /// <summary>
        ///   Método que nos inserta un usuario de la bbdd
        /// </summary>
        public void insertarUsuario()
        {
            mu.insertarUsuario(this);
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

    }
}
