using DevIO.Api.Controllers;
using DevIO.Business.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DevIO.Api.V1.Controllers
{
    [ApiVersion("1.0", Deprecated = true)]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class TesteController : MainController
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(INotificador notificador,
                               IUser appUser,
                               ILogger<TesteController> logger) : base(notificador, appUser)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Valor()
        {

            throw new System.Exception("Erro");
            _logger.LogTrace("Log de Trace");
            _logger.LogDebug("Log de Debug");
            _logger.LogInformation("Log de informação");
            _logger.LogWarning("Log de Aviso");
            _logger.LogError("Log de erro");
            _logger.LogCritical("log de Problema Critico");

            return "Sou a V2";
        }
    }
}
