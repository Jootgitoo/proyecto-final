using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeroGluten.domain
{
    class Producto
    {
        private int idProducto;
        private string nombre;
        private string urlImagen;
        private string[] listaAlergias; 
        private double precio;

        public Producto()
        {

        }


        public Producto(int idProducto, string nombre, string urlImagen, string[] listaAlergias, double precio)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.urlImagen = urlImagen;
            this.listaAlergias = listaAlergias;
            this.precio = precio;
        }

        public Producto(string nombre, string urlImagen, string[] listaAlergias, double precio)
        {
            this.nombre = nombre;
            this.urlImagen = urlImagen;
            this.listaAlergias = listaAlergias;
            this.precio = precio;
        }

        [JsonProperty("id")]
        public int IdProducto { get => idProducto; set => idProducto = value; }

        [JsonProperty("title")]
        public string Nombre { get => nombre; set => nombre = value; }

        [JsonProperty("image")]
        public string UrlImagen { get => urlImagen; set => urlImagen = value; }

        public string[] ListaAlergias { get => listaAlergias; set => listaAlergias = value; }

        public double Precio { get => precio; set => precio = value; }

    }
}
