using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class ValidationExceptions : Exception
    {
        ValidationExceptions() : base("Se ha producido uno o más errores de validación")
        {
            Errors = new List<string>();

        }
        public List<string> Errors { get;}
        public ValidationExceptions(IEnumerable<ValidationFailure> failures): this()
        {
            foreach (var item in failures)
            {
                Errors.Add(item.ErrorMessage);
            }
        }
    }
}
