using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using zeroGluten.domain;

namespace zeroGluten.view
{
    
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();

            // Rellenamos el comboBox de los generos
            String[] genero = { "Hombre", "Mujer", "Prefiero no decirlo" };
            foreach (String g in genero)
            {
                cbGenero.Items.Add(g);
            }


            // Rellenamos el comboBox de los pesos
            for (double peso = 30.00; peso <= 150.00; peso += 0.5)
            {
                cbPeso.Items.Add($"{peso:0.00} kg");
            }


            // Rellenamos el comboBox de la altura
            for (double altura = 1.10; altura <= 2.15; altura += 0.05)
            {
                cbAltura.Items.Add($"{altura:0.00} m");
            }


            // Rellenamos el comboBox de la actividad fica
            String[] actividadFisica = { "Si", "No" };
            foreach (String a in actividadFisica)
            {
                cbActividadFisica.Items.Add(a);
            }


            // Rellenamos el comboBox de la frecuencia de la actividad fisica
            String[] frecuencia = { "0 dias", "1 dia", "3 dias", "5 dias", "6 dias", "7 dias" };
            foreach (String f in frecuencia)
            {
                cbFrecuenciaActividadFisica.Items.Add(f);
            }


            // Rellenamos el comboBox de las condiciones médicas
            String[] condiciones = { "Diabetes", "Hipertensión", "Obesidad", "Teroides", "Asma", "Alergias", "Artritis", "Ninguna" };
            foreach (String c in condiciones)
            {
                cbCondicionMedica.Items.Add(c);
            }


            // Rellenamos el comboBox de la toma de medicamentos
            String[] tomasMedicacion = { "Si", "No" };
            foreach (String m in tomasMedicacion)
            {
                cbTomasMedicamentos.Items.Add(m);
            }


            // Rellenadmos el comboBox de nota de la dieta
            for (int nota = 0; nota <= 10; nota += 1)
            {
                cbNotaDieta.Items.Add($"{nota} ptos");
            }


            // Rellenamos el comboBox si es fumador o no
            String[] fumador = { "Si", "No" };
            foreach (String f in fumador)
            {
                cbFumador.Items.Add(f);
            }


            // Rellenamos el comboBox de si tiene alguna enfermedad
            String[] enfermedades = { "Si", "No" };
            foreach (String e in enfermedades)
            {
                cbEnfermedades.Items.Add(e);
            }


            // Rellenamos el comboBox de las intolerancias alimenticias
            String[] intolerancias = { "Lactosa", "Celiaco", "Fructosa", "Histamina", "Sorbitol", "Ninguna" };
            foreach (String i in intolerancias)
            {
                cbEnfermedadesAlimenticias.Items.Add(i);
            }


            // Rellenamos el comboBox de los tipos de dieta
            String[] tiposDieta = { "Sin gluten", "Vegetariana", "Vegana", "Sin lactosa", "Alta en proteina", "Baja en carbohidratos", "Baja en calorias", "Sin azucares", "Comida basura", "Ninguna de las anteriores" };
            foreach (String d in tiposDieta)
            {
                cbDietas.Items.Add(d);
            }

        }


        /// <summary>
        ///     Cuando te das de alta en la aplicacion correctamente, se abre la ventana productos, sino hay un mensaje de error
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDarAlta_Click(object sender, RoutedEventArgs e)
        {

            if (comprobarCamposRellenos())
            {
                //Recogemos los datos de los campos
                string nombre = tbNombre.Text;
                string apellidos = tbApellido.Text;
                string email = tbEmail.Text;
                string password = tbPassword.Text;
                string fechaStr = dpFechaNacimiento.Text;
                string sexo = cbGenero.Text;

                double peso = Convert.ToDouble(cbPeso.Text.Replace(" ", "").Replace("k", "").Replace("g", ""));
                double altura = Convert.ToDouble(cbAltura.Text.Replace(" ", "").Replace("m", ""));
                bool actividadFisica = false;
                if (cbActividadFisica.Text.Equals("Si"))
                {
                    actividadFisica = true;
                }
                string frecuenciaActividadFisica = cbFrecuenciaActividadFisica.Text;
                string condicionMedica = cbCondicionMedica.Text;

                bool medicacion = false;
                if (cbTomasMedicamentos.Text.Equals("Si"))
                {
                    medicacion = true;
                }
                string notaDietaStr = cbNotaDieta.Text;
                bool fumador = false;
                if (cbFumador.Text.Equals("Si"))
                {
                    fumador = true;
                }
                string enfermedades = cbEnfermedades.Text;
                string intolerancias = cbEnfermedadesAlimenticias.Text;
                string tipoDieta = cbDietas.Text;

                //Intertamos el usuario en la base de datos
                Usuario u = new Usuario(nombre, apellidos, email, password, DateTime.Parse(fechaStr), sexo);
                u.insertarUsuario();


                //Insertamos el perfil en la base de datos
                Perfil p = new Perfil(peso, altura, actividadFisica, frecuenciaActividadFisica, condicionMedica, medicacion, notaDietaStr, fumador, enfermedades, intolerancias, tipoDieta, u.IdUsuario);
                p.insertarPerfil();

                //Abrimos la ventana de productos
                Productos ventanaProductos = new Productos();
                ventanaProductos.ShowDialog();



            }
            else 
            {
                MessageBox.Show("Rellene todos los campos de forma correcta", "ERROR", MessageBoxButton.OK);
            }

        }

        /// <summary>
        ///     Comprobamos que todos los campos del registro están rellenos
        /// </summary>
        /// <returns>
        ///     True --> Todos los campos están rellenos
        ///     False --> Algún campo no está relleno
        /// </returns>
        public bool comprobarCamposRellenos()
        {
            if (tbNombre.Text == "" || tbApellido.Text == "" || tbEmail.Text == "" || tbPassword.Text == "" || dpFechaNacimiento.SelectedDate == null || cbGenero.Text == "" ||
                cbPeso.Text == "" || cbAltura.Text == "" || cbActividadFisica.Text == "" || cbFrecuenciaActividadFisica.Text == "" || cbCondicionMedica.Text == "" ||
                cbTomasMedicamentos.Text == "" || cbNotaDieta.Text == "" || cbFumador.Text == "" || cbEnfermedades.Text == "" || cbEnfermedadesAlimenticias.Text == "" ||
                cbDietas.Text == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
