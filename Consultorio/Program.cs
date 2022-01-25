
using Consultorio.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();

#region DbContext
builder.Services.AddDbContext<ConsultorioContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServerConnection")
));
#endregion

#region Adding services/interfaces
//builder.Services.AddScoped<IEmailService, EmailService>();
#endregion

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

app.UseAuthorization();
app.UseCors(x => x.AllowAnyMethod()
                  .AllowAnyOrigin()
                  .AllowAnyHeader());

app.MapControllers();

app.Run();
