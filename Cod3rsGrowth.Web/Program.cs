using Cod3rsGrowth.Web;


var construtor = WebApplication.CreateBuilder(args);
StartupWeb.Registrar(construtor);
var app = construtor.Build();


StartupWeb.InicializarBancoDeDados(app);


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
