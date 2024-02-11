namespace ConsoleApp4.Repositories;

using ConsoleApp4.Context;
using ConsoleApp4.Entities;

public partial class AddressRepository : Repo<AddressEntitie>
{
    public AddressRepository(LocalDataContext context) : base(context)
    {
    }

}


