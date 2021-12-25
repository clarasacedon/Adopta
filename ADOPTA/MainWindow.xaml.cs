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

namespace ADOPTA
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BitmapImage imagOriginal = new BitmapImage(new Uri("fotos/usuario1.jpg", UriKind.Relative));
        private BitmapImage imagRollOver = new BitmapImage(new Uri("fotos/usuario2.jpg", UriKind.Relative));

        string[,] usuarios = { {"1234", "1234" }, {"Ana", "2016" } , { "Clara", "2021" } };
       

        private BitmapImage imagCheck = new BitmapImage(new Uri("fotos/ok.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("fotos/nok.png", UriKind.Relative));

        public MainWindow()
        {
            InitializeComponent();
            App.DefineIdioma("es-ES");
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            // se hará la comprobación al pulsar el "Enter"
            if (e.Key == Key.Return)
            {
                if (!String.IsNullOrEmpty(txtUsuario.Text)
                && ComprobarUsuarios(usuarios,
                txtUsuario, imgCheckUsuario))
                {
                    // habilitar entrada de contraseña y pasarle el foco
                    passContrasena.IsEnabled = true;
                    passContrasena.Focus();
                    // deshabilitar entrada de login
                    txtUsuario.IsEnabled = false;
                }
            }
        }

        private void imgAvatar_MouseEnter(object sender, MouseEventArgs e)
        {
            imgAvatar.Source = imagRollOver;
        }

        private void imgAvatar_MouseLeave(object sender, MouseEventArgs e)
        {
            imgAvatar.Source = imagOriginal;
        }

        /*private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
          {
              MessageBox.Show("Gracias por usar nuestra aplicación...", "Despedida");
          }*/

        private Boolean ComprobarUsuarios(string [,] usuarios,
                                         Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            componenteEntrada.BorderThickness = new Thickness(2);
            if ((txtUsuario.Text == usuarios[0, 0])|| ( txtUsuario.Text == usuarios[1, 0]) || (txtUsuario.Text == usuarios[2, 0]))
            {
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.LightSalmon;
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }

        private Boolean ComprobarContrasena(string[,] usuarios,
                                      Control componenteEntrada, Image imagenFeedBack)
        {
            Boolean valido = false;
            componenteEntrada.BorderThickness = new Thickness(2);
            if (( txtUsuario.Text==usuarios[0,0] &&  passContrasena.Password == usuarios[0, 1]) || (txtUsuario.Text == usuarios[1, 0] && passContrasena.Password == usuarios[1, 1]) || (txtUsuario.Text == usuarios[2, 0] && passContrasena.Password == usuarios[2, 1]))             {
                componenteEntrada.BorderBrush = Brushes.Green;
                componenteEntrada.Background = Brushes.LightGreen;
                imagenFeedBack.Source = imagCheck;
                valido = true;
            }
            else
            {
                componenteEntrada.BorderBrush = Brushes.Red;
                componenteEntrada.Background = Brushes.LightSalmon;
                imagenFeedBack.Source = imagCross;
                valido = false;
            }
            return valido;
        }
     

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // La comprobación ya lleva implícita que las entradas
            // estén vacías
            if (ComprobarUsuarios(usuarios, txtUsuario, imgCheckUsuario)
                &&
                ComprobarContrasena(usuarios, passContrasena, imgCheckContrasena))
            {

                Menu menu = new Menu();
                String nombre = txtUsuario.Text;
                
                String msgBienvenida= "¡Bienvenido a ADOPTA " + nombre +"!";
                String msgConexion = "Última conexión: " + DateTime.Today;
                menu.lblBienvenida.Content = msgBienvenida;
                menu.lblConexion.Content = msgConexion;

                menu.Show();
            }
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
            ventanaAyuda ventanaAyuda = new ventanaAyuda();
            ventanaAyuda.Show();
        }

       

        private void cbIdioma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
                string idioma = "";
                int cbi = cbIdioma.SelectedIndex;
                switch (cbi)
                {
                    case 0:
                        idioma = "es-ES";
                        break;
                    case 1:
                        idioma = "en-UK";
                        break;
                }
                Resources.MergedDictionaries.Add(App.DefineIdioma(idioma));
            }

     
        private void btnMostrarContrasena_Click(object sender, RoutedEventArgs e)
        {
            passContrasena.Visibility = Visibility.Hidden;
            lblContrasenaVisible.Visibility = Visibility.Visible;
            lblContrasenaVisible.IsEnabled = true;
            btnOcultarContrasena.Visibility = Visibility.Hidden;
            lblContrasenaVisible.Text = passContrasena.Password; //asignar el contenido de la PasswordBox a la label
            lblContrasenaVisible.Visibility = Visibility.Visible; //hacer la label visible

        }

        private void btnOcultarContrasena_Click(object sender, RoutedEventArgs e)
        {

            passContrasena.Visibility = Visibility.Visible;
            lblContrasenaVisible.Visibility = Visibility.Hidden;
            btnOcultarContrasena.Visibility = Visibility.Visible;
            
        }

        private void passContrasena_KeyUp(object sender, KeyEventArgs e)
        {
            lblContrasenaVisible.Visibility = Visibility.Hidden;
            lblContrasenaVisible.Text = passContrasena.Password;

            if (ComprobarContrasena(usuarios,
                passContrasena, imgCheckContrasena))
            {
                btnLogin.Focus();
            }
        }
    }
}
