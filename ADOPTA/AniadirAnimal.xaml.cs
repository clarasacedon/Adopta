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
    /// Lógica de interacción para AniadirAnimal.xaml
    /// </summary>
    public partial class AniadirAnimal : Window
    {

        Window1 animales = new Window1();

        public AniadirAnimal()
        {
            InitializeComponent();
        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var nuevoAnimal = new Animal(txbNombre.Text, cbTipo.Text, cbSexo.Text, Int32.Parse(txbEdad.Text), 
                txbRaza.Text, cbTamanio.Text, new Uri("fotos/perro.png", UriKind.Relative));
                // Añadimos una nueva película a la lista de películas (listadoPeliculas)
                animales.listadoAnimales.Add(nuevoAnimal);
        }
    }
}
