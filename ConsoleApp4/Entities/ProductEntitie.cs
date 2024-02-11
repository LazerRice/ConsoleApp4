using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp4.Entities;

public class ProductEntitie
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public CategoryEntitie Category { get; set; } = null!;
}
