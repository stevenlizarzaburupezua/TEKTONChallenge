using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
namespace TekTon.ProductAPI.DTO
{
    public class EliminarProductoRequest
    {
        [JsonProperty("id")]
        [SwaggerSchema("Identificador del producto.")]
        public int Id { get; set; }

        [JsonProperty("nombreProducto")]
        [SwaggerSchema("Nombre del producto que se va a eliminar")]
        public string? NombreProducto { get; set; }
    }
}
