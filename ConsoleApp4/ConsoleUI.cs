using ConsoleApp4.Services;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ConsoleApp4;

public class ConsoleUI
{
    private readonly ProductServices _productServices;
    private readonly CustomerServices _customerServices;

    public ConsoleUI(ProductServices productServices, CustomerServices customerService)
    {
        _productServices = productServices;
        _customerServices = customerService;
    }
            //Products//
    public void CreateProduct_UI()
    {
        Console.Clear();
        Console.WriteLine("----ADD PRODUCT----");

        Console.Write("Product Title:");
        var title = Console.ReadLine()!;

        Console.Write("Product Price:");
        var price = decimal.Parse(Console.ReadLine()!);

        Console.Write("Product Category:");
        var categoryName = Console.ReadLine()!;

        var result = _productServices.CreateProduct(title, price, categoryName);
        if (result != null)
        {
            Console.Clear() ;
            Console.WriteLine("Product was created.");
            Console.ReadKey();
        }

    }
    public void GetProducts_UI()
    {
        Console.Clear();

        var products = _productServices.GetProduct();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName}({product.Price}SEK)");
        }
        Console.ReadKey() ;
    }
    public void UpdateProdcut_UI()
    {
        Console.Clear();
        Console.Write("Enter Product Id:");
        var id = int.Parse( Console.ReadLine()!);

        var product = _productServices.GetProductById(id);
        if (product!= null)
        {
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName}({product.Price}SEK)");
            Console.WriteLine();

            Console.Write("Add New Product");
            product.Title = Console.ReadLine()!;
            
            var newProduct = _productServices.UpdateProduct(product);
            Console.WriteLine($"{product.Title} - {product.Category.CategoryName}({product.Price}SEK)");
        }
        else
        {
            Console.WriteLine("No product found");
        }

        Console.ReadKey();
    }
    public void DeleteProdcut_UI()
    {
        Console.Clear();
        Console.Write("Enter Product Id:");
        var id = int.Parse(Console.ReadLine()!);

        var product = _productServices.GetProductById(id);
        if (product != null)
        {
            _productServices.DeleteProduct(product.Id);
            Console.WriteLine("Product was successfully deleted");
        }

        else
        {
            Console.WriteLine("No product found");
        }

        Console.ReadKey();

    }


    //Customer/ /
    public void CreateCustomer_UI()
    {
        Console.Clear();
        Console.WriteLine("----ADD CUSTOMER----");

        Console.Write("First Name:");
        var fistName = Console.ReadLine()!;

        Console.Write("Last Name:");
        var lastName = (Console.ReadLine()!);

        Console.Write("Email:");
        var email = Console.ReadLine()!;

        Console.Write("Street Name:");
        var streetName = Console.ReadLine()!;

        Console.Write("Postal Code:");
        var postalCode = Console.ReadLine()!;

        Console.Write("City:");
        var city = Console.ReadLine()!;

        Console.Write("Role Name:");
        var roleName = Console.ReadLine()!;

        var result = _customerServices.CreateCustomer(fistName, lastName, email, roleName, streetName, postalCode, city);
        if (result != null)
        {
            Console.Clear();
            Console.WriteLine("Customer was added.");
            Console.ReadKey();
        }

    }
    public void GetCustomer_UI()
    {
        Console.Clear();

        var customers = _customerServices.GetCustomer();
        foreach (var customer in customers)
        {
            Console.WriteLine($"{customer.FirstName} {customer.LastName}({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}({customer.Address.City})");

        }
        Console.ReadKey();
    }
    public void UpdateCustomer_UI()
    {
        Console.Clear();
        Console.Write("Enter Coustomer Id:");
        var email = Console.ReadLine()!;

        var customer = _customerServices.GetCustomerByEmail(email);
        if (customer!= null)
        {
            Console.WriteLine();
            Console.WriteLine($"{customer.FirstName} {customer.LastName}({customer.Role.RoleName})");
            Console.WriteLine($"{customer.Address.StreetName}, {customer.Address.PostalCode}({customer.Address.City})");
            Console.WriteLine();


            Console.Write("Add Last Name");
            customer.LastName = Console.ReadLine()!;
            
            var newCustomer = _customerServices.UpdateCustomer(customer);
            Console.WriteLine();
            Console.WriteLine($"{newCustomer.FirstName} {newCustomer.LastName}({newCustomer.Role.RoleName})");
            Console.WriteLine($"{newCustomer.Address.StreetName}, {newCustomer.Address.PostalCode}({newCustomer.Address.City})");
            Console.WriteLine();

        }
        else
        {
            Console.WriteLine("No product found");
        }

        Console.ReadKey();
    }
    public void DeleteCoustmer_UI()
    {
        Console.Clear();
        Console.Write("Enter Customer Email: ");
        var email = Console.ReadLine();

        var customer = _customerServices.GetCustomerByEmail(email);
        if (customer!= null) 
        {
            _productServices.DeleteProduct(customer.Id);
            Console.WriteLine("Customer was deleted");
        }

        else
        {

            Console.WriteLine("No customer found");
        }
        Console.ReadKey();

    }
    


}
