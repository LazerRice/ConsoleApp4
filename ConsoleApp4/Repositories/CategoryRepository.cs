namespace ConsoleApp4.Repositories;

using ConsoleApp4.Context;
using ConsoleApp4.Entities;

public class CategoryRepository : Repo<CategoryEntitie>
{
   public CategoryRepository(LocalDataContext context) : base(context)
    {
    }
}




