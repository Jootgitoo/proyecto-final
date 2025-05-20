using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zeroGluten.domain
{
    class RespuestaRecetas
    {
        //Clase para deserializar la respuesta de la API de recetas
        [JsonProperty("results")]
        public List<Receta> listaRecetas { get; set; }
    }
}
