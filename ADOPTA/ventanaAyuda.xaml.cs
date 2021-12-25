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
using System.Windows.Shapes;

namespace ADOPTA
{
    /// <summary>
    /// Lógica de interacción para ventanaAyuda.xaml
    /// </summary>
    public partial class ventanaAyuda : Window
    {

        const string MensajeDefecto = "\n\nHáblenos de su problema para que podamos ofrecerle la ayuda y " +
                "el soporte técnico que necesita.\n\nIntentaremos solucionar sus problemas " +
                "a la mayor brevedad posible.\n\n";

        public ventanaAyuda()
        {
            InitializeComponent();
            lblTituloAyuda.Content = "¿Necesitas ayuda?";
            InformacionAyuda.Text = MensajeDefecto;
        }

        private void Image_MouseDown_Chat(object sender, MouseButtonEventArgs e)
        {
            lblTituloAyuda.Content = "¿Necesitas ayuda?";
            InformacionAyuda.Text = MensajeDefecto;
            InformacionAyuda.IsReadOnly = false;
            btnEnviarComentarios.Visibility = Visibility.Visible;
        }

        private void Image_MouseDown_Info(object sender, MouseButtonEventArgs e)
        {
            lblTituloAyuda.Content = "Acerca de...";
            InformacionAyuda.Text = "\n\nVersión: 1.5\n\n" +
                "Autores: María Victoria Alcázar Clemente\n\tClara Sacedón Ortega" + "\n\n" +
                "Fecha de lanzamiento: Enero 2022" + "\n\n\n";
            InformacionAyuda.IsReadOnly = true;
            btnEnviarComentarios.Visibility = Visibility.Hidden;
        }

        private void Image_MouseDown_Contacto(object sender, MouseButtonEventArgs e)
        {
            lblTituloAyuda.Content = "Contacte con nosotros";
            InformacionAyuda.Text = "\n\nTeléfono: +34 91 254 77 52\n\n" +
                "Correo electrónico: ayuda@adoptame.es";
            InformacionAyuda.IsReadOnly = true;
            btnEnviarComentarios.Visibility = Visibility.Hidden;
        }

        private void btnEnviarComentarios_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("SU COMENTARIO SE HA ENVIADO CORRECTAMENTE.\n\n",
                            "Confirmación", MessageBoxButton.OK, MessageBoxImage.Information);
            InformacionAyuda.Text = MensajeDefecto;
        }
    }
}
