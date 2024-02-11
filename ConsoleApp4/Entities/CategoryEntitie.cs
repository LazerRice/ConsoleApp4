using System.ComponentModel.DataAnnotations;

namespace ConsoleApp4.Entities;

public class CategoryEntitie
{
    [Key]
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;
}
