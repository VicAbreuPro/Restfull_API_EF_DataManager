using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "AllowOrigin";

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c => c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_M3", Description = "XTREME API", Version = "v5" }));

// Add CORS Policy
builder.Services.AddCors(c =>
{
    c.AddPolicy(name: MyAllowSpecificOrigins, options => { options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_M3");
        //c.RoutePrefix = string.Empty;
    });
}


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_M5");
    c.RoutePrefix = string.Empty;
});

// Enable CORS
app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();