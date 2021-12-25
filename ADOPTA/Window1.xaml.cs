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
using System.Xml;

namespace ADOPTA
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        private List<Animal> listadoAnimales;

        public Window1()
        {
            InitializeComponent();
            listadoAnimales = CargarContenidoXML();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            DataContext = listadoAnimales;
        }

        private List<Animal> CargarContenidoXML()
        {
            List<Animal> listado = new List<Animal>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("animales.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoAnimal = new Animal("", "", "", 0,"", "", null);
                nuevoAnimal.Nombre = node.Attributes["Nombre"].Value;
                nuevoAnimal.Tipo = node.Attributes["Tipo"].Value;
                nuevoAnimal.Sexo = node.Attributes["Sexo"].Value;
                nuevoAnimal.Edad = Convert.ToInt32(node.Attributes["Edad"].Value);
                nuevoAnimal.Raza = node.Attributes["Raza"].Value;
                nuevoAnimal.Tamanio = node.Attributes["Tamanio"].Value;
                nuevoAnimal.Imagen = new Uri(node.Attributes["Imagen"].Value, UriKind.Relative);
                listado.Add(nuevoAnimal);
            }
            return listado;
        }

        private void btnAniadir_Click(object sender, RoutedEventArgs e)
        {
            AniadirAnimal nuevo = new AniadirAnimal();
            nuevo.Show();
            lstListaAnimales.Items.Refresh();
        }
    }
}