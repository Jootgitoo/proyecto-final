using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace zeroGluten.domain
{
    class Receta
    {
        //ATRIBUTOS
        private int idReceta;
        private string nombreReceta;
        private int tiempoPreparacion;
        private string urlImagen;
        private string descripcion;
        private bool vegetariano;
        private bool vegano;
        private bool sinGluten;
        private string instrucciones;
        private double calorias;

//---------------------------------------------------------------------------------------
        //CONSTRUCTORES
        public Receta()
        {

        }

        public Receta(int idReceta, string nombreReceta, int tiempoPreparacion, string urlImagen, string descripcion, bool vegetariano, bool vegano, bool sinGluten, string instrucciones, double calorias)
        {
            this.idReceta = idReceta;
            this.nombreReceta = nombreReceta;
            this.tiempoPreparacion = tiempoPreparacion;
            this.urlImagen = urlImagen;
            this.descripcion = descripcion;
            this.vegetariano = vegetariano;
            this.vegano = vegano;
            this.sinGluten = sinGluten;
            this.instrucciones = instrucciones;
            this.calorias = calorias;
        }

        public Receta(string nombreReceta, int tiempoPreparacion, string urlImagen, string descripcion, bool vegetariano, bool vegano, bool sinGluten, string instrucciones, double calorias)
        {
            //this.idReceta = getLastId;
            this.nombreReceta = nombreReceta;
            this.tiempoPreparacion = tiempoPreparacion;
            this.urlImagen = urlImagen;
            this.descripcion = descripcion;
            this.vegetariano = vegetariano;
            this.vegano = vegano;
            this.sinGluten = sinGluten;
            this.instrucciones = instrucciones;
            this.calorias = calorias;
        }


//---------------------------------------------------------------------------------------
        //GETTERS Y SETTERS

        [JsonProperty("id")]
        public int IdReceta { get => idReceta; set => idReceta = value; }

        [JsonProperty("title")]
        public string NombreReceta { get => nombreReceta; set => nombreReceta = value; }
        
        [JsonProperty("readyInMinutes")]
        public int TiempoPreparacion { get => tiempoPreparacion; set => tiempoPreparacion = value; }

        [JsonProperty("image")]
        public string UrlImagen { get => urlImagen; set => urlImagen = value; }
        [JsonProperty("summary")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        [JsonProperty("vegetarian")]
        public bool Vegetariano { get => vegetariano; set => vegetariano = value; }
        [JsonProperty("vegan")]
        public bool Vegano { get => vegano; set => vegano = value; }
        [JsonProperty("glutenFree")]
        public bool SinGluten { get => sinGluten; set => sinGluten = value; }
        public string Instrucciones { get => instrucciones; set => instrucciones = value; }
        public double Calorias { get => calorias; set => calorias = value; }

    }
}
