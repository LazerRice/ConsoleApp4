namespace ConsoleApp4.Repositories;

using System.Diagnostics;
using ConsoleApp4.Context;
using ConsoleApp4.Entities;


public class RoleRepository : Repo<RoleEntitie>
{
    private readonly LocalDataContext _context;
    public RoleRepository(LocalDataContext context) : base(context)
    {
        _context = context; 
    }

    

    public async Task<RoleEntitie> CreateAsync(RoleEntitie roleEntitie)
    {
        try
        {
            _context.Role.Add(roleEntitie);
            await _context.SaveChangesAsync();

            return roleEntitie;
        }
        catch (Exception ex) { Debug.WriteLine(ex.Message); }

        return null!;
    }
}



