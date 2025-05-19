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
            string apiUrl = $"https://api.spoonacular.com/food/products/search?apiKey={apiKey}&query=b&number=5";

            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.GetAsync(apiUrl);

            if (respuesta.IsSuccessStatusCode)
            {
                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaProductos>(jsonRespuesta);
                List<Producto> listaProductosDevueltos = resultado.listaProductos;

                // Lista para almacenar los productos completos con precio
                List<Producto> listaProductosCompletos = new List<Producto>();

                foreach (var producto in listaProductosDevueltos)
                {
                    // Obtenemos los detalles del producto usando el ID
                    string detalleUrl = $"https://api.spoonacular.com/food/products/{producto.IdProducto}?apiKey={apiKey}";
                    HttpResponseMessage respuestaDetalle = await cliente.GetAsync(detalleUrl);

                    if (respuestaDetalle.IsSuccessStatusCode)
                    {
                        string jsonDetalle = await respuestaDetalle.Content.ReadAsStringAsync();
                        Producto productoCompleto = JsonConvert.DeserializeObject<Producto>(jsonDetalle);
                        listaProductosCompletos.Add(productoCompleto);
                    }
                }

                return listaProductosCompletos;
            }
            else
            {
                throw new Exception($"Error: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
            }
        }



        /// <summary>
        ///      Obtenemos una lista de productos de la api que cumplan unos requisitos
        /// </summary>
        /// <param name="nombre"> Nombre del producto </param>
        /// <param name="caloriasMaximas"> Calorias maximas del producto </param>
        /// <param name="proteinasMinimas"> Proteinas minimas del producto </param>
        /// <param name="grasasMaximas"> Grasas maximas del producto </param>
        /// <returns> Lista con productos que cumplan las condiciones de los filtros </returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Producto>> obtenerProductosConFiltros(string nombre, string caloriasMaximas, string proteinasMinimas, string grasasMaximas)
        {
            string apiKey = "174c5ea2fee04cd99c92504eaeafffbe";
            string apiUrl = $"https://api.spoonacular.com/food/products/search?";

            // Aplicar filtros
            if (!string.IsNullOrEmpty(nombre) )
            {
                apiUrl += $"query={nombre}&";
            }
            else
            {
                apiUrl += "query=food&";
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

            apiUrl += $"apiKey={apiKey}"; // Limitar a 5 productos por solicitud

            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.GetAsync(apiUrl);

            if (respuesta.IsSuccessStatusCode)
            {
                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaProductos>(jsonRespuesta);
                List<Producto> listaProductosDevueltos = resultado.listaProductos;

                // Lista para almacenar los productos completos con todos los detalles
                List<Producto> listaProductosCompletos = new List<Producto>();

                foreach (var producto in listaProductosDevueltos)
                {
                    // Obtener detalles de cada producto utilizando su ID
                    string detalleUrl = $"https://api.spoonacular.com/food/products/{producto.IdProducto}?apiKey={apiKey}";
                    HttpResponseMessage respuestaDetalle = await cliente.GetAsync(detalleUrl);

                    if (respuestaDetalle.IsSuccessStatusCode)
                    {
                        string jsonDetalle = await respuestaDetalle.Content.ReadAsStringAsync();
                        Producto productoCompleto = JsonConvert.DeserializeObject<Producto>(jsonDetalle);
                        listaProductosCompletos.Add(productoCompleto);
                    }
                }

                return listaProductosCompletos;
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

            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.GetAsync(apiUrl);

            if (respuesta.IsSuccessStatusCode)
            {
                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaRecetas>(jsonRespuesta);
                List<Receta> listaRecetasBasicas = resultado.listaRecetas;

                List<Receta> listaRecetasCompletas = new List<Receta>();

                foreach (Receta recetaBasica in listaRecetasBasicas)
                {
                    string detalleUrl = $"https://api.spoonacular.com/recipes/{recetaBasica.IdReceta}/information?apiKey={apiKey}";
                    HttpResponseMessage respuestaDetalle = await cliente.GetAsync(detalleUrl);

                    if (respuestaDetalle.IsSuccessStatusCode)
                    {
                        string jsonDetalle = await respuestaDetalle.Content.ReadAsStringAsync();
                        Receta recetaCompleta = JsonConvert.DeserializeObject<Receta>(jsonDetalle);

                        recetaCompleta.Descripcion = QuitarEtiquetasHTML(recetaCompleta.Descripcion);

                        listaRecetasCompletas.Add(recetaCompleta);
                    }
                }

                return listaRecetasCompletas;
            }
            else
            {
                throw new Exception($"Error: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
            }
        }



        /// <summary>
        ///       Obtenemos una receta de la api a partir de su id
        /// </summary>
        /// <param name="id"> Id de la receta que queremos</param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Receta> ObtenerDetalleRecetaPorId(int id)
        {
            string apiKey = "174c5ea2fee04cd99c92504eaeafffbe";
            string apiUrl = $"https://api.spoonacular.com/recipes/{id}/information?apiKey={apiKey}";

            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.GetAsync(apiUrl);

            if (respuesta.IsSuccessStatusCode)
            {
                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();
                Receta recetaCompleta = JsonConvert.DeserializeObject<Receta>(jsonRespuesta);
                return recetaCompleta;
            }
            else
            {
                throw new Exception($"Error al obtener receta con ID {id}: {respuesta.StatusCode}");
            }
        }

        /// <summary>
        ///       Obtenemos una lista de recetas de la api que cumplan unos requisitos
        /// </summary>
        /// <param name="nombre"> Nombre de la receta/producto principal</param>
        /// <param name="tiempoPreparacion">  Tiempo de preparacion de la receta </param>
        /// <param name="intolerancia"> Intolerancias que NO quieres que tenga la api</param>
        /// <param name="tipoComida"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<Receta>> obtenerRecetasConFiltros(string nombre, string tiempoPreparacion, string intolerancia, string tipoComida)
        {
            string apiKey = "174c5ea2fee04cd99c92504eaeafffbe";
            string apiUrl = $"https://api.spoonacular.com/recipes/complexSearch?";

            if (!string.IsNullOrEmpty(nombre))
                apiUrl += $"query={nombre}&";
            else
                apiUrl += "query=food&";

            if (!string.IsNullOrEmpty(tiempoPreparacion))
                apiUrl += $"maxReadyTime={tiempoPreparacion}&";

            if (!string.IsNullOrEmpty(intolerancia))
                apiUrl += $"intolerances={intolerancia}&";

            if (!string.IsNullOrEmpty(tipoComida))
                apiUrl += $"type={tipoComida}&";

            apiUrl += $"apiKey={apiKey}&number=1"; // Puedes cambiar el número de resultados

            HttpClient cliente = new HttpClient();
            HttpResponseMessage respuesta = await cliente.GetAsync(apiUrl);

            if (respuesta.IsSuccessStatusCode)
            {

                string jsonRespuesta = await respuesta.Content.ReadAsStringAsync();
                var resultado = JsonConvert.DeserializeObject<RespuestaRecetas>(jsonRespuesta);
                List<Receta> listaFinal = new List<Receta>();

                foreach (var recetaBasica in resultado.listaRecetas)
                {
                    // Aquí haces la segunda petición para cada receta por ID
                    string urlDetalles = $"https://api.spoonacular.com/recipes/{recetaBasica.IdReceta}/information?apiKey={apiKey}";

                    HttpResponseMessage detalleResp = await cliente.GetAsync(urlDetalles);
                    if (detalleResp.IsSuccessStatusCode)
                    {
                        string jsonDetalle = await detalleResp.Content.ReadAsStringAsync();
                        var recetaCompleta = JsonConvert.DeserializeObject<Receta>(jsonDetalle);

                        detalleResp = await cliente.GetAsync(recetaCompleta.UrlImagen);
                        
                        //if (!detalleResp.IsSuccessStatusCode)
                        //{
                        //    throw new Exception($"Error al obtener la imagen de la receta con ID {recetaCompleta.IdReceta}: {detalleResp.StatusCode}");
                        //}

                        recetaCompleta.Descripcion = QuitarEtiquetasHTML(recetaCompleta.Descripcion);


                        // Si quieres, puedes mantener valores del resultado original, pero normalmente ya viene todo en el detalle
                        listaFinal.Add(recetaCompleta);
                    }
                }

                return listaFinal;
            }
            else
            {
                throw new Exception($"Error: {respuesta.StatusCode} - {respuesta.ReasonPhrase}");
            }
        }

        public static string QuitarEtiquetasHTML(string texto)
        {
            return Regex.Replace(texto, "<.*?>", string.Empty);
        }

    }
}