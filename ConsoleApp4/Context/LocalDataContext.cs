using ConsoleApp4.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp4.Context;

public class LocalDataContext : DbContext
{
    public LocalDataContext(DbContextOptions<LocalDataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntitie> Addresses {  get; set; }

    public DbSet<CategoryEntitie> Categories { get; set; }

    public DbSet<CustomerEntitie> Customer { get; set; }

    public DbSet<ProductEntitie> Product { get; set; }

    public DbSet<RoleEntitie> Role { get; set; }

}
