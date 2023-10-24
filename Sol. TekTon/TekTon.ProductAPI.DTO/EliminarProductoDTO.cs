using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TekTon.ProductAPI.Domain.Seedwork;

namespace TekTon.ProductAPI.DTO
{
    public class EliminarProductoDTO
    {
        [Display(Order = 0)]
        [JsonProperty("transactionSuccess")]
        [SwaggerSchema("flag que indica si la operacion se realizó correctamente")]
        public bool TransactionSuccess { get; set; }

        [Display(Order = 1)]
        [JsonProperty("id")]
        [SwaggerSchema("Identificador del producto.")]
        public int Id { get; set; }

        [Display(Order = 2)]
        [JsonProperty("nombreProducto")]
        [SwaggerSchema("Nombre del producto que se acaba de eliminar.")]
        public string? NombreProducto { get; set; }
    }
}
