using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TekTon.ProductAPI.Seedwork
{
    public class ApplicationValidationErrorsException : Exception
    {
        public string Codigo { get; }

        public ApplicationValidationErrorsException()
        { }

        public ApplicationValidationErrorsException(string message)
            : base(message)
        { }

        public ApplicationValidationErrorsException(string codigo, string message)
           : base(message)
        {
            Codigo = codigo;
        }

        public ApplicationValidationErrorsException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }

    public class ApplicationValidationResult
    {
        public List<string> Errors { get; set; }

        public bool Succeded { get => !Errors.Any(); }

        public ApplicationValidationResult()
        {
            Errors = new List<string>();
        }

        public ApplicationValidationResult AddError(string error)
        {
            Errors.Add(error);
            return this;
        }

        public string GetErrors()
        {
            return string.Join("|", Errors);
        }
    }
}
