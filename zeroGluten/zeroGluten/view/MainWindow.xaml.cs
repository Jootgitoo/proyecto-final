using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using zeroGluten.view;

namespace zeroGluten;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }


    /// <summary>
    ///     Se borra el contenido del textBox del nombre de usuario al hacer click en él
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBox_GotFocusUsuario(object sender, RoutedEventArgs e)
    {
        txtBlockNombreUsuario.Clear(); // Limpia el contenido del TextBox
    }


    /// <summary>
    ///     Se borra el contenido del textBox de la password al hacer click en él
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBox_GotFocusPassword(object sender, RoutedEventArgs e)
    {
        txtBlockPassword.Clear(); // Limpia el contenido del TextBox
    }


    /// <summary>
    ///   Se abre la ventana de registro al hacer click en el botón "Registrarse"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
    {
        registro ventanaRegistro = new registro();
        ventanaRegistro.ShowDialog();
    }


    /// <summary>
    /// Comprobamos si el usuario ha escrito bien su nombre y su contraseña
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
    {
        string nombreUsuario = txtBlockNombreUsuario.Text;
        string password = txtBlockPassword.Text;

        //Sacamos una lista de todos los usuarios de la bbdd

        //Comprobamos si el nombre de usuario y la contraseña son correctos

        // Si son correctos abrimos la ventana principal
        // Si no son correctos mostramos un mensaje de error y que vuelva a intentarlo
    }
}