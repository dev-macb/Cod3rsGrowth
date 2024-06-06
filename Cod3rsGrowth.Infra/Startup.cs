using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Infra
{
    public class Startup
    {
        public static void RegistrarServicos(IServiceCollection servicos)
        {
            servicos.AddScoped(provider => ContextoConexao.CriarConexao("ConexaoPadrao"));
        }
    }
}