using Anfx.Auth.ApiService;
using Anfx.Auth.ApiService.Infrastructure;
using Anfx.Auth.Application;
using Anfx.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;



// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(configuration);
builder.AddWebServices();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();

// Configuración de JWT
var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var secretKey = jwtSettings["SecretKey"];
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey ?? ""))
    };
});
// Configuración de CORS para microservicio
builder.Services.AddCors(options =>
{
    var allowedOrigins = builder.Environment.IsDevelopment()
        ? new[] { "http://localhost:4200" }
        : new[] { "http://localhost:4200", "https://dev.anfexi.com" };

    options.AddPolicy("AllowAngular",
        policy =>
        {
            policy.WithOrigins(allowedOrigins)
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();

    //app.MapScalarApiReference(options =>
    //{
    //    options.WithTitle("Yggdrasil API Documentation");
    //    options.WithTheme(ScalarTheme.Saturn);
    //    options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    //    options.HideSearch = true;// Habilita/Deshabilita el buscador (Ctrl+K)
    //    options.ShowSidebar = true; // Muestra u oculta la barra lateral
    //    options.DarkMode = true;
    //});
}

#if (!UseAspire)
app.UseHealthChecks("/health");
#endif
app.UseExceptionHandler(options => { });

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAngular");
app.UseAuthentication();
app.UseAuthorization();

app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options.WithTitle("API Services Auth");
    options.WithTheme(ScalarTheme.DeepSpace);
    options.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    options.HideSearch = true;// Habilita/Deshabilita el buscador (Ctrl+K)
    options.ShowSidebar = true; // Muestra u oculta la barra lateral
    options.DarkMode = false;
});
app.UseRouting();

app.Map("/", () => Results.Redirect("/scalar"));

#if (UseAspire)
app.MapDefaultEndpoints();
#endif

app.MapEndpoints();

app.MapControllers();

app.Run();
