using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using zeroGluten.domain;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace zeroGluten.persistence.manages
{
    
    class ApiManage
    {

        /// <summary>
        ///     Obtenemos una lista de productos de la api
        /// </summary>
        /// <returns>
        ///     Lista de objetos Producto de la API
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Producto>> obtenerTodosProductos()
        {
            
            string apiKey = "174c5ea2fee04cd99c92504eaeafffbe";
            string apiUrl = $"https://api.spoonacular.com/food/products/search?apiKey={apiKey}&query=a&number=1";

            //Nos creamos un "cliente" para hacer una solicitud a la api
            HttpClient cliente = new HttpClient();

            //Enviamos una solicitud HTTP GET a la API
            HttpResponseMessage respuesta = await cliente.GetAsync(apiUrl);

            if (respuesta.IsSuccessStatusCode) //Si el codigo devuelto es exitoso
            {

                //Me devuelve en formato json la respuesta de la API
                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();

                //Devuelvo la respuesta deserializada para poder leerlo bien
                var resultado = JsonConvert.DeserializeObject<RespuestaProductos>(jsonRespuesta);
                List<Producto> listaProductosDevueltos = resultado.listaProductos;

                return listaProductosDevueltos;
            }
            else
            {
                throw new Exception($"Error: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
            }
        }


        public async Task<List<Producto>> obtenerProductosConFiltros(string nombre, string caloriasMaximas, string proteinasMinimas, string grasasMaximas)
        {
            string apiKey = "174c5ea2fee04cd99c92504eaeafffbe";
            string apiUrl = $"https://api.spoonacular.com/food/products/search?";

            if(!string.IsNullOrEmpty(nombre))
            {
                apiUrl += $"query={nombre}&";
            }
            if (!string.IsNullOrEmpty(caloriasMaximas))
            {
                apiUrl += $"maxCalories={caloriasMaximas}&";
            }
            if (!string.IsNullOrEmpty(proteinasMinimas))
            {
                apiUrl += $"minProtein={proteinasMinimas}&";
            }
            if (!string.IsNullOrEmpty(grasasMaximas))
            {
                apiUrl += $"maxFat={grasasMaximas}&";
            }

            apiUrl += $"apiKey={apiKey}&number=1";

            //Nos creamos un "cliente" para hacer una solicitud a la api
            HttpClient cliente = new HttpClient();

            //Enviamos una solicitud HTTP GET a la API
            HttpResponseMessage respuesta = await cliente.GetAsync(apiUrl);

            if (respuesta.IsSuccessStatusCode) //Si el codigo devuelto es exitoso
            {

                //Me devuelve en formato json la respuesta de la API
                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();

                //Devuelvo la respuesta deserializada para poder leerlo bien
                var resultado = JsonConvert.DeserializeObject<RespuestaProductos>(jsonRespuesta);
                List<Producto> listaProductosDevueltos = resultado.listaProductos;

                return listaProductosDevueltos;
            }
            else
            {
                throw new Exception($"Error: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
            }

        }


        /// <summary>
        ///   Obtenemos una lista de recetas de la api
        /// </summary>
        /// <returns>
        ///     Devolvemos una lista Recetas
        /// </returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Receta>> obtenerTodasRecetas()
        {

            string apiKey = "174c5ea2fee04cd99c92504eaeafffbe";
            string apiUrl = $"https://api.spoonacular.com/recipes/complexSearch?apiKey={apiKey}&query=a&number=1";

            //Nos creamos un "cliente" para hacer una solicitud a la api
            HttpClient cliente = new HttpClient();

            //Enviamos una solicitud HTTP GET a la API
            HttpResponseMessage respuesta = await cliente.GetAsync(apiUrl);

            if (respuesta.IsSuccessStatusCode) //Si el codigo devuelto es exitoso
            {

                //Me devuelve en formato json la respuesta de la API
                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();

                //Devuelvo la respuesta deserializada para poder leerlo bien
                var resultado = JsonConvert.DeserializeObject<RespuestaRecetas>(jsonRespuesta);
                List<Receta> listaRecetasDevueltos = resultado.listaRecetas;

                return listaRecetasDevueltos;
            }
            else
            {
                throw new Exception($"Error: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
            }
        }


        public void cargarRecetasConFiltros()
        {

        }

    }
    
}
