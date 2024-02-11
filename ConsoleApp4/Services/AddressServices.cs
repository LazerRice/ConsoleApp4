using ConsoleApp4.Entities;
using ConsoleApp4.Repositories;

namespace ConsoleApp4.Services;

public class AddressServices
{
    private readonly AddressRepository _addressRepository;

    public AddressServices(AddressRepository addressRepository)
    {
        _addressRepository = addressRepository;
    }

    public AddressEntitie CreateAddress(string streetName, string postalCode, string city)
    {
        var addressEntite = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        addressEntite ??= _addressRepository.Create(new AddressEntitie { StreetName = streetName, PostalCode = postalCode, City = city });
        return addressEntite;

    }
    
    public AddressEntitie GetAddress (string streetName, string postalCode, string city)
    {
        var addressEntite = _addressRepository.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
        return addressEntite;
    }

    public AddressEntitie GetAddressById(int id)
    {
        var addressEntite = _addressRepository.Get(x => x.Id == id);
        return addressEntite;
    }

    public IEnumerable<AddressEntitie> GetAddress()
    {
        var addressEntite = _addressRepository.GetAll();
        return addressEntite;
    }

    public AddressEntitie UpdatedAddress(AddressEntitie addressEntitie)
    {
        var updatedAddressEntitee = _addressRepository.Update(x => x.Id == addressEntitie.Id, addressEntitie);
        return updatedAddressEntitee;
    }

    public void DeleteAddress(int id)
    {
        _addressRepository.Delete(x => x.Id == id);
    }
}

   
