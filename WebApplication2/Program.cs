using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)

    // Support calling this API using tokens issued from Authority1
    .AddJwtBearer("MaualTokenValidation", options =>
    {
        options.Audience = "https://localhost:7143/";

        options.Authority = "https://demo.duendesoftware.com/";

        // For demo-purposes we disable issuer and audience validation 
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidateIssuer = false;

        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("qwertyuiopasdfghjklzxcvbnm123456"));
    })

    // Support calling this API using tokens issued from Authority2
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
    {
        options.Audience = "some other audience";

        options.Authority = "https://samples.auth0.com/";

        // For demo-purposes we disable issuer and audience validation 
        options.TokenValidationParameters.ValidateAudience = false;
    });

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
