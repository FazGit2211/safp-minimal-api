using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Agreagar el servicio para utilizar los controladores y poder inyectar los servicios
builder.Services.AddControllers();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<AuthService>();
//Asignar la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("SafpContextDb");
//Asignar el contexto a la base de datos
builder.Services.AddSqlite<SafpContext>(connectionString);
//Configurar Jwt
builder.Services.AddAuthentication(options => options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]))
});
//Agregar servicio de autorizacion
builder.Services.AddAuthorization();
var app = builder.Build();
//Utilizar directiva cors
app.UseCors();
//Utilizar la autentificacion y autorizacion
app.UseAuthentication();
app.UseAuthorization();
//Mapea las rutas para los controladores
app.MapControllers();
app.Run();
