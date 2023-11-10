using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekTon.ProductAPI.DTO.ValidateRequest
{
    public class RegistrarProductoValidation : AbstractValidator<RegistrarProductoRequest>
    {
        public RegistrarProductoValidation()
        {
            RuleFor(r => r.NombreProducto)
            .NotEmpty()
            .MaximumLength(50);
        }
    }
}
