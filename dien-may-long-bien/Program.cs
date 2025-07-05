using DienMayLongBien.Configurations;
using DienMayLongBien.Domain.Shared;
using DienMayLongBien.Middlewares;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.LoadEnv();
builder.Services.AddJwt(builder.Configuration);
builder.Services.AddPostgres(builder.Configuration);

builder.Services.AddScoped<AuthMiddleware>();
builder.Services.AddScoped<CurrentUser>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapScalarApiReference();
}

// Add authentication middleware
app.UseMiddleware<AuthMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

await app.RunAsync().ConfigureAwait(false);
