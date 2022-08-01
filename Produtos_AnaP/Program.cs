using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrcamentoApi;
using OrcamentoApi.Data;
using OrcamentoApi.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfiguration"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "OrcamentoApi",
                Version = "v1",
                Description = "A REST API",
                TermsOfService = new Uri("https://lmgtfy.com/?q=i+like+pie")
            });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            Implicit = new OpenApiOAuthFlow
            {
                Scopes = new Dictionary<string, string>
                {
                    { "openid", "Open Id" }
                },
                AuthorizationUrl = new Uri("https://dev-yukhr2qd.us.auth0.com/" + "authorize?audience=" + "https://localhost:7020/Orcamento")
            }
        }
    });
});
builder.Services.AddSwaggerGen(c =>
{
    //quando usamos o Swagger, por padr�o, todas as a��es exigir�o um token JWT.
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

builder.Services.AddScoped<OrcamentoService, OrcamentoService>();
builder.Services.AddDbContext<OrcamentoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrcamentoApi")));

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
               .AddScoped<IUrlHelper>(x => x.GetRequiredService<IUrlHelperFactory>()
               .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));

builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(x => x.First());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrcamentoApi");
        c.OAuthClientId(builder.Configuration["Auth0:ClientId"]);
    });
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();