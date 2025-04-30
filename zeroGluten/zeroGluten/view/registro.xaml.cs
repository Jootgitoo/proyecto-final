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
    /// <summary>
    /// Lógica de interacción para registro.xaml
    /// </summary>
    public partial class registro : Window
    {
        public registro()
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
            String[] frecuencia = { "1 día", "3 días", "5 días", "6 días", "7 días" };
            foreach (String f in frecuencia)
            {
                cbFrecuenciaActividadFisica.Items.Add(f);
            }


            // Rellenamos el comboBox de las condiciones médicas
            String[] condiciones = { "Diabetes", "Hipertensión", "Obesidad","Teroides", "Asma", "Alergias", "Artritis", "Ninguna" };
            foreach(String c in condiciones)
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
            //Recogemos los datos de la pantalla
            string nombre = tbNombre.Text;
            string apellidos = tbApellido.Text;
            string email = tbEmail.Text;
            string password = tbPassword.Text;
            DateTime? fechaStr = dpFechaNacimiento.SelectedDate;
            string genero = cbGenero.Text;
            string pesoStr = cbPeso.Text;
            string alturaStr = cbAltura.Text;
            string actividadFisica = cbActividadFisica.Text;
            string frecuenciaActividadFisica = cbFrecuenciaActividadFisica.Text;
            string condicionMedica = cbCondicionMedica.Text;
            string medicacion = cbTomasMedicamentos.Text;
            string notaDietaStr = cbNotaDieta.Text;
            string fumador = cbFumador.Text;
            string enfermedades = cbEnfermedades.Text;
            string intolerancias = cbEnfermedadesAlimenticias.Text;
            string dieta = cbDietas.Text;

            //Intertamos el usuario en la base de datos
            Usuario u = new Usuario(nombre, apellidos, email, password, (DateTime)fechaStr, genero);
            u.insertarUsuario();

            //Insertamos el perfil en la base de datos
            Perfil p = new Perfil(pesoStr, alturaStr, dieta, actividadFisica, frecuenciaActividadFisica, condicionMedica, medicacion, notaDietaStr, fumador, enfermedades);

            //Si se ha insertado correctamente
            Productos ventanaProductos = new Productos();
            ventanaProductos.ShowDialog();
            //Si no
        }
    }
}
