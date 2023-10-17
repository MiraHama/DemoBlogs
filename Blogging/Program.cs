using Blogging.Data;
using Microsoft.EntityFrameworkCore;
using Blogging.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.RegisterServices();

var app = builder.Build();

app.ConfigureSwagger();
app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();
