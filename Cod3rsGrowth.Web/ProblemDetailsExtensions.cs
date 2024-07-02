using Newtonsoft.Json;
using FluentValidation;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

namespace Cod3rsGrowth.Web
{
    public static class ProblemDetailsExtensions
    {
        public static void UseProblemDetailsExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            var logger = loggerFactory.CreateLogger(Constantes.LOGGER_NOME);

            app.UseExceptionHandler(construtor =>
            {
                construtor.Run(async contexto =>
                {
                    var manipuladorDeExcecoes = contexto.Features.Get<IExceptionHandlerFeature>();
                    if (manipuladorDeExcecoes != null)
                    {
                        var excecao = manipuladorDeExcecoes.Error;
                        var detalhesDoProblema = CriarDetalhesDoProblema(contexto, excecao);

                        LogDasExcecoes(logger, excecao);

                        contexto.Response.StatusCode = detalhesDoProblema.Status.Value;
                        contexto.Response.ContentType = Constantes.CONTEXTO_TIPO_CONTEUDO;

                        var json = JsonConvert.SerializeObject(detalhesDoProblema);
                        await contexto.Response.WriteAsync(json);
                    }
                });
            });
        }

        public static IServiceCollection ConfigureProblemDetailsModelState(this IServiceCollection services)
        {
            return services.Configure<ApiBehaviorOptions>(opcoes =>
            {
                opcoes.InvalidModelStateResponseFactory = contexto =>
                {
                    var detalhesDoProblema = new ValidationProblemDetails(contexto.ModelState)
                    {
                        Title = Constantes.MODELO_TITULO,
                        Detail = Constantes.MODELO_DETALHE,
                        Instance = contexto.HttpContext.Request.Path,
                        Status = StatusCodes.Status400BadRequest
                    };

                    return new BadRequestObjectResult(detalhesDoProblema)
                    {
                        ContentTypes = { "application/problem+json", "application/problem+xml" }
                    };
                };
            });
        }

        private static ProblemDetails CriarDetalhesDoProblema(HttpContext contexto, Exception excecao)
        {
            var detalhesDoProblema = new ProblemDetails
            {
                Instance = contexto.Request.HttpContext.Request.Path
            };
            switch (excecao)
            {
                case ValidationException excecaoDeValidacao:
                    detalhesDoProblema.Title = Constantes.VALIDACAO_TITULO;
                    detalhesDoProblema.Detail = excecaoDeValidacao.StackTrace;
                    detalhesDoProblema.Type = Constantes.VALIDACAO_TIPO;
                    detalhesDoProblema.Status = StatusCodes.Status400BadRequest;
                    detalhesDoProblema.Extensions[Constantes.VALIDACAO_EXTENCOES] = excecaoDeValidacao.Errors
                        .GroupBy(e => e.PropertyName)
                        .ToDictionary(g => g.Key, g => g.First().ErrorMessage); ;
                    break;

                case SqlException excecaoDeSql:
                    detalhesDoProblema.Title = Constantes.SQL_TITULO;
                    detalhesDoProblema.Detail = excecaoDeSql.StackTrace;
                    detalhesDoProblema.Type = Constantes.SQL_TIPO;
                    detalhesDoProblema.Status = StatusCodes.Status400BadRequest;
                    detalhesDoProblema.Extensions[Constantes.SQL_EXTENCOES] = excecaoDeSql.Message;
                    break;

                default:
                    detalhesDoProblema.Title = Constantes.ERRO_INESPERADO_EXTENCOES;
                    detalhesDoProblema.Detail = excecao.Demystify().ToString();
                    detalhesDoProblema.Status = StatusCodes.Status500InternalServerError;
                    detalhesDoProblema.Extensions[Constantes.ERRO_INESPERADO_EXTENCOES] = excecao.StackTrace;
                    break;
            }
            return detalhesDoProblema;
        }

        private static void LogDasExcecoes(ILogger logger, Exception excecao)
        {
            switch (excecao)
            {
                case ValidationException validationException:
                    logger.LogWarning(Constantes.VALIDACAO_LOG, validationException.Message, string.Join(", ", validationException.Errors.Select(e => e.ErrorMessage)));
                    break;

                case SqlException sqlException:
                    logger.LogWarning(Constantes.SQL_LOG, sqlException.Message, sqlException.Number, sqlException.Procedure, sqlException.LineNumber);
                    break;

                default:
                    logger.LogError(Constantes.ERRO_INESPERADO_LOG, excecao.Message, excecao.StackTrace);
                    break;
            }
        }
    }
}
