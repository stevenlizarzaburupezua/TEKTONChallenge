using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using TekTon.ProductAPI.Domain.Entities;
using TekTon.ProductAPI.Domain.Seedwork.Data;

namespace TekTon.ProductAPI.DTO
{
    public class ConsultaProductoDTO : RawDTO
    {
        [SwaggerSchema("id del Producto")]
        [Display(Order = 0)]
        [JsonProperty("idProducto")]
 
        public int IdProducto { get; set; }
        [SwaggerSchema("id del Producto")]
        [Display(Order = 1)]
        [JsonProperty("nombreProducto")]
      
        public string? NombreProducto { get; set; }

        [Display(Order = 2)]
        [JsonProperty("fotoProducto")]
        [SwaggerSchema("Foto del Producto")]
        public byte[]? FotoProducto { get; set; }

        [Display(Order = 3)]
        [JsonProperty("descripcionProducto")]
        [SwaggerSchema("Descripcion del Producto")]
        public string? DescripcionProducto { get; set; }

        [Display(Order = 4)]
        [JsonProperty("idCategoria")]
        [SwaggerSchema("Id Categoria")]
        public int IdCategoria { get; set; }

        [Display(Order = 5)]
        [JsonProperty("nombreCategoria")]
        [SwaggerSchema("Nombre de la Categoria")]
        public string? NombreCategoria { get; set; }

        [Display(Order = 6)]
        [JsonProperty("idEstado")]
        [SwaggerSchema("Id del estado")]
        public int IdEstado { get; set; }

        [Display(Order = 7)]
        [JsonProperty("nombreEstado")]
        [SwaggerSchema("Nombre del estado")]
        public string? NombreEstado { get; set; }
     
    }
}
