namespace Cod3rsGrowth.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadeController : ControllerBase
    {
        private readonly IServiceProvider _serviceProvider;

        public HabilidadeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        [HttpPost("resetarBanco")]
        public IActionResult ResetDatabase()
        {
            try
            {
                StartupInfra.ResetarEBancoAplicarMigracoes(_serviceProvider);
                return Ok("Banco de dados resetado com sucesso.");
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao resetar o banco de dados.");
            }
        }
    }
}