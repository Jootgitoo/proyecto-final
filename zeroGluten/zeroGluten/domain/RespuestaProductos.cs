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

        //La respuesta de la API viene en formato JSON, cone esta clase
        // "transformamos" ese JSON a una lista de producto 
        [JsonProperty("products")]
        public List<Producto> listaProductos { get; set; }
        
    }
}
