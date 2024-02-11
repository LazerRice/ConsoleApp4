using System.ComponentModel.DataAnnotations;

namespace ConsoleApp4.Entities;

public class CustomerEntitie
{
    [Key]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;


    public int RoleId { get; set; }

    public RoleEntitie Role { get; set; } = null!;

    
    public int AddressId { get; set; }

    public AddressEntitie Address { get; set; } = null!;
}
