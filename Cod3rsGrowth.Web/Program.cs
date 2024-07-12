using Cod3rsGrowth.Web;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;


var construtor = WebApplication.CreateBuilder(args);


string? stringDeConexao = construtor.Configuration.GetConnectionString("ConexaoPadrao");
if (string.IsNullOrEmpty(stringDeConexao)) throw new Exception("Sem URI do banco");

StartupWeb.Registrar(construtor.Services);
StartupInfra.Registrar(construtor.Services, stringDeConexao);
StartupService.Registrar(construtor.Services);

var app = construtor.Build();


StartupInfra.InicializarBancoDeDados(app.Services);


app.UseStaticFiles(new StaticFileOptions(){ ServeUnknownFileTypes = true });
app.UseProblemDetailsExceptionHandler(app.Services.GetRequiredService<ILoggerFactory>());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
