using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    /// <summary>
    /// Creamos validaciones Personalizadadas heredando de Exception, aca aplicammos principio O  por que  extendemos a excepcion sin modificarlo
    /// </summary>
    public class ValidationException:Exception
    {
        public List<string> errors { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public ValidationException() : base("se han producido 1 o mas errores de validacion")
        {
            errors = new List<string>();
        }
        
        /// <summary>
        /// construyo metodo que recibe lista de failures
        /// </summary>
        /// <param name="failures"></param>
        public ValidationException(IEnumerable<ValidationFailure> failures):this()
        {
         foreach(var failure in failures)
            {
                errors.Add(failure.ErrorMessage);
            } 
            
        }
    }
}
