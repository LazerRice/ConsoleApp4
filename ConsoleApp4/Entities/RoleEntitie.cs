using System.ComponentModel.DataAnnotations;

namespace ConsoleApp4.Entities;

public class RoleEntitie
{
    [Key]
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;
}
