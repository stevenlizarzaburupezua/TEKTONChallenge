using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekTon.ProductAPI.DTO
{
    public class RegistrarProductoRequest
    {
        [JsonProperty("nombreProducto")]
        [SwaggerSchema("Nombre del producto")]
        public string NombreProducto { get; set; }

        [JsonProperty("foto")]
        [SwaggerSchema("foto del producto")]
        public byte[] FotoProducto { get; set; }

        [JsonProperty("descripcion")]
        [SwaggerSchema("Descripcion del producto")]
        public string DescripcionProducto { get; set; }

        [JsonProperty("idCategoria")]
        [SwaggerSchema("Id de la categoria del producto")]
        public int IdCategoria { get; set; }

        [JsonProperty("stock")]
        [SwaggerSchema("Stock del producto.")]
        public int Stock { get; set; }

        [JsonProperty("precio")]
        [SwaggerSchema("Precio del producto.")]
        public decimal PrecioProducto { get; set; }

        [JsonProperty("flgActive")]
        [SwaggerSchema("Flag que indica si el producto se encuentra disponible.")]
        public bool FlgActive { get; set; }

        [JsonProperty("idEstado")]
        [SwaggerSchema("Id del estado del producto")]
        public int IdEstadoProducto { get; set; }

        [JsonProperty("fechaRegistroProducto")]
        [SwaggerSchema("Fecha en la que se registró el producto")]
        public DateTime FechaRegistro { get; set; }

    }
}
