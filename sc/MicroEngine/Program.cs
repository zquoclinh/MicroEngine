using MicroEngine.Framework.Configuration;
using MicroEngine.Startup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.ConfigureServicesBase(builder.Configuration);
builder.ConfigureServices(builder.Configuration);
builder.WebHost.UseUrls(builder.Configuration["Kestrel:Endpoints"]);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
