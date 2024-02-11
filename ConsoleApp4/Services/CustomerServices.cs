using ConsoleApp4.Entities;
using ConsoleApp4.Repositories;

namespace ConsoleApp4.Services;

public class CustomerServices
{
    private readonly CustomerRepository _customerRepository;
    private readonly AddressServices _addressServices;
    private readonly RoleServices _roleServices;
public CustomerServices(CustomerRepository customerRepository, AddressServices addressServices, RoleServices roleServices)
    {
        _customerRepository = customerRepository;
        _addressServices = addressServices;
        _roleServices = roleServices;
    }

    public CustomerEntitie CreateCustomer(string firstName, string lastName, string email, string roleName, string streetName, string postalCode, string city)
    {
        var roleEntite = _roleServices.CreateRole(roleName);
        var addressEntite = _addressServices.CreateAddress(streetName, postalCode, city);

        var customerEntite = new CustomerEntitie
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            RoleId = roleEntite.Id,
            AddressId = addressEntite.Id

        };

        customerEntite = _customerRepository.Create(customerEntite);

        return customerEntite;
    }
   
    public CustomerEntitie GetCustomerByEmail(string email)
    {
        var customerEntite = _customerRepository.Get(x => x.Email == email);
        return customerEntite;
    }

    public IEnumerable<CustomerEntitie> GetCustomer()
    {
        var customer = _customerRepository.GetAll();
        return customer;
    }

    public CustomerEntitie UpdateCustomer(CustomerEntitie roleEntitie)
    {
        var updatedCustomerEntite = _customerRepository.Update(x => x.Id == roleEntitie.Id, roleEntitie);
        return updatedCustomerEntite;
    }

    public void DeleteCustomer(int id)
    {
        _customerRepository.Delete(x => x.Id == id);
    }
}
