namespace ConsoleApp4.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using ConsoleApp4.Context;
using ConsoleApp4.Entities;
using Microsoft.EntityFrameworkCore;

public class ProductRepository : Repo<ProductEntitie>
{
    private readonly LocalDataContext _context;
    public ProductRepository(LocalDataContext context) : base(context)
    {
        _context = context;
    }

    public override ProductEntitie Get(Expression<Func<ProductEntitie, bool>> expression)
    {
        var entity = _context.Product
            .Include(i => i.Category)
            .FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<ProductEntitie> GetAll()
    {
        return _context.Product
            .Include(i => i.Category)
            .ToList();
    }
}



