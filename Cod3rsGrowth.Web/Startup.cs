namespace Cod3rsGrowth.Web
{
    public class StartupWeb
    {
        public static void Registrar(IServiceCollection servicos)
        {
            servicos.AddDirectoryBrowser();
            servicos.AddControllers();
            servicos.AddEndpointsApiExplorer();
            servicos.AddSwaggerGen();
        }
    }
}