using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using ProductsInventory.Api.Data;
using ProductsInventory.Api.Mappings;
using ProductsInventory.Api.Repositories;
using ProductsInventory.Api.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});
var jwtsettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtsettings["key"]);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtsettings["Issuer"],
            ValidAudiences = [jwtsettings["Audience"]],
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    }
    );

builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));

builder.Services.AddControllers();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();