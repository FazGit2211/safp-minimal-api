using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("SafpContextDb");
//Asignar el contexto a la base de datos
builder.Services.AddSqlite<SafpContext>(connectionString);
var app = builder.Build();
//Rutas para los endpoinst
ClientRoutes.Map(app);
ProductRoutes.MapProduct(app);
ProviderRoutes.MapProvider(app);
app.Run();
