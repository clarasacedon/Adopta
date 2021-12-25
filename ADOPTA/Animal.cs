using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOPTA
{
    class Animal
    {
        public string Nombre { set; get; }
        public string Tipo { set; get; }
        public string Sexo { set; get; }
        public int Edad { set; get; }
        public string Raza { set; get; }
        public string Tamanio { set; get; }
        public Uri Imagen { set; get; }

        public Animal(){}

        public Animal(string nombre, string tipo, string sexo, int edad, string raza, string tamanio, Uri imagen)
        {
            Nombre = nombre;
            Tipo = tipo;
            Sexo = sexo;
            Edad = edad;
            Raza = raza;
            Tamanio = tamanio;
            Imagen = imagen;
        }
    }
}
