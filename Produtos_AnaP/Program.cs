using Microsoft.EntityFrameworkCore;
using OrcamentoApi;
using OrcamentoApi.Data;
using OrcamentoApi.Service;


var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<RabbitMqConfiguration>(builder.Configuration.GetSection("RabbitMqConfiguration"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<OrcamentoService, OrcamentoService>();
builder.Services.AddDbContext<OrcamentoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OrcamentoApi")));
builder.Services.AddHostedService<ProcessMessageConsumer>();


builder.Services.AddSwaggerGen(c =>
{
    c.ResolveConflictingActions(x => x.First());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();