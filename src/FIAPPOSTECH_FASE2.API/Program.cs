using FIAPPOSTECH_FASE2.API.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureEntityFramework();
builder.Services.ConfigureSwagger(builder);
builder.Services.ConfigureJWT(builder);

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
