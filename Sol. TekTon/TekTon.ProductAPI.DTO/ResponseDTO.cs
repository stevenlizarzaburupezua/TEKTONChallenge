using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekTon.ProductAPI.DTO
{
    public class ResponseDTO<T> : ResponseDTO
    {
        [SwaggerSchema("Lista de objetos obtenidos del servicio.")]
        public List<T> Values { get; set; }

        [SwaggerSchema("Objeto obtenido del servicio.")]
        public T Value { get; set; }

        [SwaggerSchema("Cantidad de datos obtenidos de una lista.")]    
        public int Count => Values?.Count ?? 0;

        [SwaggerSchema("Lista de errores.")]
        public List<string> Errors { get; set; }

        public Exception Exception { get; set; }
        public int indArcModificados { get; set; }

        public static ResponseDTO<T> List(List<T> values) => new ResponseDTO<T> { Success = true, Values = values };

        public static ResponseDTO<T> Single(T value) => new ResponseDTO<T> { Success = true, Value = value };

        public static ResponseDTO<T> Ok(string msg = null) => new ResponseDTO<T> { Success = true, Message = msg };

        public static ResponseDTO<T> BadRequest(string msg) => new ResponseDTO<T> { Success = false, Message = msg };

        public static ResponseDTO<T> BadRequest(Exception ex) => new ResponseDTO<T> { Success = false, Exception = ex };

        public static ResponseDTO<T> Error(List<string> errors) => new ResponseDTO<T> { Errors = errors };


        public ResponseDTO()
        {

        }

        public ResponseDTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ResponseDTO(string message)
        {
            Message = message;
        }

        public ResponseDTO(bool success)
        {
            Success = success;
        }
    }

    public class ResponseDTO
    {
        [SwaggerSchema("Flag que indica que la solicitud es correcta.")]
        public bool Success { get; set; }

        [SwaggerSchema("Mensaje de error o validación.")]
        public string Message { get; set; }


        public ResponseDTO()
        {

        }

        public ResponseDTO(string message)
        {
            Message = message;
        }

        public ResponseDTO(bool success)
        {
            Success = success;
        }
        public ResponseDTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}
