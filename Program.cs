using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("SafpContextDb");
//Asignar el contexto a la base de datos
builder.Services.AddSqlite<SafpContext>(connectionString);
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

ClientRoutes.Map(app);

app.Run();
