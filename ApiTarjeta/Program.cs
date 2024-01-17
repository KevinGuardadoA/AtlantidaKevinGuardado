/**
 * Kevin Fabricio Guardado Alberto
 * Api Tarjeta
 */
using ApiTarjeta;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);


var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
