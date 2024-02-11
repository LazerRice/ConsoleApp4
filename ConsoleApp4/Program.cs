using ConsoleApp4;
using ConsoleApp4.Context;
using ConsoleApp4.Repositories;
using ConsoleApp4.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateDefaultBuilder().ConfigureServices(services =>
{

    services.AddDbContext<LocalDataContext>(x => x.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\ESS\Datalagring\ConsoleApp4\database.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True"));

    services.AddScoped<AddressRepository>();
    services.AddScoped<CategoryRepository>();
    services.AddScoped<RoleRepository>();
    services.AddScoped<ProductRepository>();
    services.AddScoped<CustomerRepository>();

    services.AddScoped<AddressServices>();
    services.AddScoped<CategoryServices>();
    services.AddScoped<RoleServices>();
    services.AddScoped<ProductServices>();
    services.AddScoped<CustomerServices>();

    services.AddSingleton<ConsoleUI>();

}).Build();

var consoleUI = builder.Services.GetRequiredService<ConsoleUI>();


//CRUD//
consoleUI.CreateProduct_UI();
//consoleUI.GetProducts_UI();
//consoleUI.UpdateProdcut_UI();
//consoleUI.DeleteProdcut_UI();

//consoleUI.CreateCustomer_UI();
//consoleUI.GetCustomers_UI();
//consoleUI.UpdateCustomer_UI();




