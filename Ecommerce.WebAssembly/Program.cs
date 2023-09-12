using Ecommerce.WebAssembly;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using Blazored.LocalStorage;
using Blazored.Toast;
using Ecommerce.WebAssembly.Services.Contracts;
using Ecommerce.WebAssembly.Services.Implementation;
using Ecommerce.DTO;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5257/api/") });
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddBlazoredToast();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISalesService, SalesService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>(); 



await builder.Build().RunAsync();

