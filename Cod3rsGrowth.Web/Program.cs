using Cod3rsGrowth.Web;
using Cod3rsGrowth.Infra;
using Cod3rsGrowth.Service;


var construtor = WebApplication.CreateBuilder(args);

StartupWeb.Registrar(construtor.Services);
StartupInfra.Registrar(construtor.Services);
StartupService.Registrar(construtor.Services);

var app = construtor.Build();


StartupInfra.InicializarBancoDeDados(app.Services);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
