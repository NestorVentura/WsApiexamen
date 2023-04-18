using Microsoft.EntityFrameworkCore;
using WsApiexamen.Repositorios;
using WsApiexamen.Servicios;

var builder = WebApplication.CreateBuilder(args);

var asembly = typeof(AplicationContext).Assembly.GetName().Name;
builder.Services.AddDbContext<AplicationContext>(p => p.UseSqlServer("Server=localhost;Database=BDiExamen;Integrated Security=true;MultipleActiveResultSets=true", o => o.MigrationsAssembly(asembly)));


// Add services to the container.
builder.Services.AddScoped<IExamenServicio, ExamenServicio>();
builder.Services.AddScoped<IExamenRepositorio, ExamenRepositorio>();


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
