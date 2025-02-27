using _2Core.Extensions;
using _3Infra.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.PostgreSQL.ColumnWriters;


Log.Logger = new LoggerConfiguration()
    // .MinimumLevel.Debug()
    .WriteTo.Console()
    .WriteTo.File("log_.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.File("lot_warning_.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning, rollingInterval: RollingInterval.Day) // Log only errors
    .WriteTo.File("lot_errors_.txt", restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Error, rollingInterval: RollingInterval.Day) // Log only errors
    .CreateLogger();



var builder = WebApplication.CreateBuilder(args);

var db_sql_str = builder.Configuration["ConnectionStrings:DefaultConnection"];
var db_post_str = builder.Configuration["ConnectionStrings:PostgreSQLConnection"];

Console.WriteLine($"db_sql_str  => {db_sql_str}");
Console.WriteLine($"db_post_str => {db_post_str}");

var columnWriters = new Dictionary<string, ColumnWriterBase>
{
    { "timestamp", new TimestampColumnWriter() },
    { "level", new LevelColumnWriter() },
    { "message", new RenderedMessageColumnWriter() },
    { "exception", new ExceptionColumnWriter() },
    { "properties", new LogEventSerializedColumnWriter() }
};

Log.Logger = new LoggerConfiguration().WriteTo.PostgreSQL(db_post_str, "logs2", columnWriters, needAutoCreateTable: true).CreateLogger();
    
// Add services to the container.
builder.Host.UseSerilog(); 
builder.Services.AddControllers();
builder.Services.AddCors();
builder.Services.AddCors(o => o.AddPolicy("Default", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader()
           .WithExposedHeaders("Content-Disposition");
}));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddInfraDependencyInjection(builder.Configuration);
builder.Services.AddCoreDependencyInjection();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging(); 
app.UseCors("Default");
app.UseHttpsRedirection();

// app.UseDefaultFiles();
// app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();


// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
