using Cod3rsGrowth.Web;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;
using Microsoft.Extensions.FileProviders;


var construtor = WebApplication.CreateBuilder(args);

string chaveDeConexao = construtor.Environment.EnvironmentName == "Test" ? "ConexaoTeste" : "ConexaoPadrao";
string? stringDeConexao = construtor.Configuration.GetConnectionString(chaveDeConexao);
if (string.IsNullOrEmpty(stringDeConexao)) throw new Exception("Sem URI do banco");

StartupWeb.Registrar(construtor.Services);
StartupInfra.Registrar(construtor.Services, stringDeConexao);
StartupService.Registrar(construtor.Services);

var app = construtor.Build();

if (chaveDeConexao == "ConexaoTeste") {
    StartupInfra.ApagarBancoDeDados(app.Services);
}
StartupInfra.InicializarBancoDeDados(app.Services);

app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(app.Environment.ContentRootPath, "wwwroot")),
    EnableDirectoryBrowsing = true
});
app.UseStaticFiles(new StaticFileOptions() { ServeUnknownFileTypes = true });
app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
