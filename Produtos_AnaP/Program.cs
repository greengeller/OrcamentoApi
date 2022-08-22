using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using OrcamentoApi;
using OrcamentoApi.Domain.Interfaces;
using OrcamentoApi.Infra.SQL.Context;
using OrcamentoApi.Infra.SQL.Repository;
using OrcamentoApi.Service;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddScoped<IOrcamentoService, OrcamentoService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddScoped<IVendedorService, VendedorService>();
builder.Services.AddScoped<IOrcamentoRepository, OrcamentoRepository>();
builder.Services.AddScoped<IProdutoRepository, ProdutoRepository>();
builder.Services.AddScoped<IVendedorRepository, VendedorRepository>();


builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfiguration"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Add services to the container.
builder.Services.AddSwaggerGen();


builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>()
               .AddScoped<IUrlHelper>(x => x.GetRequiredService<IUrlHelperFactory>()
               .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext));

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(b => b.MigrationsAssembly("OrcamentoApi")).UseSqlServer(builder.Configuration.GetConnectionString("OrcamentoApi")));

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
    //quando usamos o Swagger, por padrão, todas as ações exigirão um token JWT.
    c.OperationFilter<SecurityRequirementsOperationFilter>();
});

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