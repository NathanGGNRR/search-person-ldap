using Diiage.Directory.Core.Exceptions;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Diiage.Directory.Web.Infrastructure
{
    /// <summary>
    /// Middleware de gestion des exceptions de l'API.
    /// </summary>
    public class ExceptionHandlingMiddleware
    {
        private readonly JsonSerializerOptions _jsonSettings = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        /// Initialise une nouvealle instance de la classe <see cref="ExceptionHandlingMiddleware"/>
        /// </summary>
        /// <param name="next">Middleware suivant dans le pipeline.</param>
        /// <param name="loggerFactory">Logger factory.</param>
        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionHandlingMiddleware>();
        }

        /// <summary>
        /// Méthode d'exécution du middleware.
        /// </summary>
        /// <param name="context">Contexte HTTP</param>
        /// <returns>Tache asynchrone.</returns>
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (BusinessException ex)
            {
                var clientException = new ClientException
                {
                    CorrelationId = Guid.NewGuid(),
                    Title = ex.Message,
                    Data = ex.Data
                };

                await WriteClientException(context, ex.Type == ErrorType.Forbidden ? 403 : 400, clientException);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                var exceptionResponsePayload = new ClientException
                {
                    CorrelationId = Guid.NewGuid(),
                    Title = "TechnicalError"
                };

                _logger.LogError(ex, $"Technical exception: {exceptionResponsePayload.CorrelationId}");

                await WriteClientException(context, 500, exceptionResponsePayload);
            }
        }

        private Task WriteClientException(HttpContext context, int statusCode, ClientException clientException)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(JsonSerializer.Serialize(clientException, _jsonSettings));
        }
    }
}
