using Atfal360.Context;
using Atfal360.Implementation.Repositories;
using Atfal360.Implementation.Services;
using Atfal360.Interface.Repositories;
using Atfal360.Interface.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ITiflRepository, TiflRepository>();
builder.Services.AddScoped<ITiflService, TiflService>();
builder.Services.AddScoped<IMuqamiRepository, MuqamiRepository>();
builder.Services.AddScoped<IMuqamiService, MuqamiService>();
builder.Services.AddScoped<IDilaRepository, DilaRepository>();
builder.Services.AddScoped<IDilaService, DilaService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IRegionRepository, RegionRepository>();
builder.Services.AddScoped<IRegionService, RegionService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connectionString = builder.Configuration.GetConnectionString("Atfal360ConnectionString");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));



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
