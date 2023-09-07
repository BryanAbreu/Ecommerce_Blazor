using Ecommerce.Repository.DBcontext;
using Microsoft.EntityFrameworkCore;

using Ecommerce.Repository.Contracts;
using Ecommerce.Repository.Implementation;
using Ecommerce.Services.Contract;
using Ecommerce.Services.Implementation;
using Ecommerce.Utility;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Conexion BD
builder.Services.AddDbContext<DbEcommerceContext>(options=>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CadenaSQl"));
});

builder.Services.AddTransient(typeof(IGenericReposistory<>),typeof(GenericRepository<>));
builder.Services.AddScoped<IVentaRepository, VentaRepository>();

builder.Services.AddScoped<IcategorySevice, CategoryService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserSevice>();
builder.Services.AddScoped<IVentaService,VentaService>();

builder.Services.AddCors(opt=> 
{
    opt.AddPolicy("NewPolicy", app => 
    {
        app.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader(); 
    });
});

builder.Services.AddAutoMapper(typeof(AutommaperProfile));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
