using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Catalog.API.Application.Contracts;
using Service.Catalog.API.Application.Services;
using Service.Catalog.API.Infrustructure.Persistence;
using System.Reflection;


var builder = WebApplication.CreateBuilder(args);

//? Register Service
  builder.Services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy",
                builder => builder
                 .WithOrigins("http://localhost:3000")
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());
        });

// Register IProductService
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddHttpContextAccessor();
IMvcBuilder configurationController = builder.Services.AddControllers();
configurationController.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = Context =>
    {
        var errors = Context.ModelState.Values.Where(state => state.Errors.Count != 0).Select(state => state.Errors.Select(p => new { errormessage = p.ErrorMessage }));
        return new BadRequestObjectResult(errors);
    };
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddDbContextPool<SqlServerApplicationDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB"));
}, poolSize: 16);

builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseStaticFiles();

app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();


