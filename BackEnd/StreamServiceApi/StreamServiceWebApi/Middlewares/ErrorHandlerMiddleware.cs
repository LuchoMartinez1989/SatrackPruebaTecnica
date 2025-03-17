using Application.Wrappers;
using System.Net;
using System.Text.Json;

namespace WebApi.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// controlamos los errores de manera mas detallada
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new Response<string>() { Succeded = false, Message = exception?.Message + "\n" + exception?.InnerException };

                switch (exception)
                {
                    case Application.Exceptions.ApiException e: //errores personalizados y controlads
                        // Custom application error API
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case Application.Exceptions.ValidationException e:
                        // Custom application error Validation
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Errors = e.errors;
                        break;
                    case KeyNotFoundException e:  // NO ENCONTRO EL  ENDPOINT 
                        // Not fount error
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        // Unhandled error
                        break;
                }
                var result = JsonSerializer.Serialize(responseModel);
                await response.WriteAsync(result);
            }
        }

    }
}
