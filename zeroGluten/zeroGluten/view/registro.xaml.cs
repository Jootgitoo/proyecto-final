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

            // Rellenamos el comboBox de la altura
            for (double altura = 1.10; altura <= 2.15; altura += 0.05)
            {
                cbAltura.Items.Add($"{altura:0.00} m");
            }

            // Rellenamos el comboBox de los pesos
            for (double peso = 30.00; peso <= 150.00; peso += 0.5)
            {
                cbPeso.Items.Add($"{peso:0.00} kg");
            }

            // Rellenamos el comboBox de las condiciones médicas
            String[] condiciones = { "Diabetes", "Hipertensión", "Obesidad","Teroides", "Asma", "Alergias", "Artritis", "Ninguna" };
            foreach(String c in condiciones)
            {
                cbCondicionMedica.Items.Add(c);
            }

            // Rellenadmos el comboBox de nota de la dieta
            for (int nota = 0; nota <= 10; nota += 1)
            {
                cbNotaDieta.Items.Add($"{nota} ptos");
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


    }
}
