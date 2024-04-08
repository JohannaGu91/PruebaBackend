using ApiModAmin.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Local",
          builder =>
          {
              builder.WithOrigins("*")
              .AllowAnyHeader()
              .AllowAnyMethod();
          });
});

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
logger.Info("Starting the Host");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("Local");

app.Run();
