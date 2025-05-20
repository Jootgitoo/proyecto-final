using System.Security.Cryptography;
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
using zeroGluten.domain;
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
        txtBlockNombreUsuario.Clear();
    }


    /// <summary>
    ///     Se borra el contenido del textBox de la password al hacer click en él
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TextBox_GotFocusPassword(object sender, RoutedEventArgs e)
    {
        pwBox.Clear();
    }


    /// <summary>
    ///     Se abre la ventana de registro al hacer click en el botón "Registrarse"
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnRegistrarse_Click(object sender, RoutedEventArgs e)
    {
        Registro ventanaRegistro = new Registro();
        ventanaRegistro.ShowDialog();
    }


    /// <summary>
    ///     Comprobamos si el usuario ha escrito bien su nombre y su contraseña para iniciar sesión
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnIniciarSesion_Click(object sender, RoutedEventArgs e)
    {
        //Recogemos los datos de la pantalla
        string nombreUsuario = txtBlockNombreUsuario.Text;
        string passwordEncriptada = EncryptSHA256(pwBox.Password);

        //Sacamos una lista de todos los usuarios de la bbdd
        List<Usuario> listaUsuarios = new List<Usuario>();
        Usuario user = new Usuario();
        listaUsuarios = user.obtenerTodosUsuarios();

        //Para salir del bucle cuando encontramos el usuario
        bool encontrado = false;

        //Comprobamos si el nombre de usuario y la contraseña son correctos
        foreach ( Usuario u in listaUsuarios)
        {

            if ( u.NombreUsuario.Equals(nombreUsuario) && u.Password.Equals(passwordEncriptada))
            {
                encontrado = true;

                //Abrimos la ventana de productos
                Productos ventanaProductos = new Productos();
                ventanaProductos.Show();

                break;
            }
            
        }

        if (!encontrado)
        {
            MessageBox.Show("Usuario no encontrado. Escriba correctamente el nombre " +
                "y/o la contraseña. Si no está registrado pulse en el botón Registrarse", "Usuario no encontrado", MessageBoxButton.OK);
        }

    }


    /// <summary>
    ///   Método que encripta una cadena de texto con SHA256
    /// </summary>
    /// <param name="text"></param>
    /// <returns>
    ///     Devolvemos la cadena de texto encriptada
    /// </returns>
    static string EncryptSHA256(string text)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(text);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }

    /// <summary>
    ///     Método que minimiza la ventana actual al hacer click 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnMinimizar_Click(object sender, RoutedEventArgs e)
    {
        WindowState = WindowState.Minimized;
    }


    /// <summary>
    ///    Método que cierra la ventana actual al hacer click
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnCerrar_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}