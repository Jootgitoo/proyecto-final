using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeroGluten.domain
{
    class RespuestaProductos
    {

        //Clase para deserializar la respuesta de la API de productos
        [JsonProperty("products")]
        public List<Producto> listaProductos { get; set; }
        
    }
}
