using FluentValidation;
using MediatR;

namespace Application.Behaviors
{
    /// <summary>
    /// establece  la configuracion para interceder en los request y los reponse de los pipeline
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public class ValidatonBeahavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator> _validators;

        /// <summary>
        /// Constructor, inyeccion de validaciones
        /// </summary>
        /// <param name="validators"></param>
        public ValidatonBeahavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        /// <summary>
        /// creacion de regla general para hacer validaciones, aca aplicamos L por que usamos a Excepcion  que es padre de Valdiation Excepcion sin llamarlo
        /// </summary>
        /// <param name="request"></param>
        /// <param name="next"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validators.Select(s => s.ValidateAsync(context, cancellationToken)));
                var failures = validationResults.SelectMany(p => p.Errors).Where(t => t != null).ToList();
                if (failures.Count() > 0)
                {
                    throw new Exceptions.ValidationException(failures);
                }
            }
            return await next();
        }


    }

}
