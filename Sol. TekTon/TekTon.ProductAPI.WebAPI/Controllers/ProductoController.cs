using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Swashbuckle.AspNetCore.Annotations;
using TekTon.ProductAPI.Application.Interface;
using TekTon.ProductAPI.DTO;

namespace TekTon.ProductAPI.WebAPI.Controllers
{
    [SwaggerTag("API que procesa la gestión de los producto")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [SwaggerOperation(
        Summary = "Servicio que registra un nuevo producto",
        OperationId = "RegistrarProducto")]
        [SwaggerResponse(200, "Registro de un nuevo producto exitoso")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpPost("registrar-producto")]
        public async Task<IActionResult> RegistrarProducto([Body] RegistrarProductoRequest request)
        {
            return Ok(  await _productoService.RegistrarProducto(request));
        }

        [SwaggerOperation(
        Summary = "Servicio que consulta la información del producto especifico",
        OperationId = "ConsultarProducto")]
        [SwaggerResponse(200, "Información del producto")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("consultar-producto")]
        public async Task<IActionResult> ConsultarProducto(int idProducto)
        {
            return Ok(await _productoService.ConsultarProducto(idProducto));
        }

        [SwaggerOperation(
        Summary = "Servicio que consulta la información de todos los productos registrados en el sistema",
        OperationId = "ConsultarProductos")]
        [SwaggerResponse(200, "Información del producto")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpGet("consultar-productos")]
        public async Task<IActionResult> ConsultarProductos()
        {
            return Ok(await _productoService.ConsultarProductos());
        }

        [SwaggerOperation(
        Summary = "Servicio que modificar un nuevo producto",
        OperationId = "ModificarProducto")]
        [SwaggerResponse(200, "Modificación del producto exitoso")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpPut("modificar-producto")]
        public async Task<IActionResult> ModificarProducto([FromBody] ModificarProductoRequest request)
        {
            return Ok(await _productoService.ModificarProducto(request));
        }

        [SwaggerOperation(
        Summary = "Servicio que elimina un producto especifico",
        OperationId = "EliminarProducto")]
        [SwaggerResponse(200, "Eliminación Correcta")]
        [SwaggerResponse(500, "Error interno en el servidor")]
        [HttpDelete("eliminar-producto")]
        public async Task<IActionResult> EliminarProducto([Body] EliminarProductoRequest request)
        {
            return Ok(await _productoService.EliminarProducto(request));
        }
    }
}
