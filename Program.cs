global using Microsoft.EntityFrameworkCore;
using webapiexercise.Services;
using webapiexercise;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("TareasConnection"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// crea una nueva instancia a nivel controlador y clase
builder.Services.AddScoped<ICategoriaServices,CategoriaServices>();
builder.Services.AddScoped<ITareasService,TareaServices>();
// builder.Services.AddScoped<IHelloWorldServices>(parameter=> new HelloWorldService());
// addsingleton crea una unica instancia de esa dependecia a nivel de toda la api no recomendada ya que se guarda en memoria
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseCors() seguridad de quien puede usarla y no usarla

app.UseAuthorization();
// aqui van los custom middleware
// app.UseWelcomePage();
// termina custom middleware
//app.UseTimemiddleware();
app.MapControllers();

app.Run();
