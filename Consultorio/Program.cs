using Consultorio.Services.EmailService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();
builder.Services.AddControllers();

#region Adding services/interfaces
builder.Services.AddScoped<IEmailService, EmailService>();
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
