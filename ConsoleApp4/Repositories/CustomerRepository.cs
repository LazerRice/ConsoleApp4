namespace ConsoleApp4.Repositories;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ConsoleApp4.Context;
using ConsoleApp4.Entities;
using Microsoft.EntityFrameworkCore;

public class CustomerRepository : Repo<CustomerEntitie>
{
    private readonly LocalDataContext _context;
    public CustomerRepository(LocalDataContext context) : base(context)
    {
        _context = context;
    }

    public override CustomerEntitie Get(Expression<Func<CustomerEntitie, bool>> expression)
    {
        var entitie = _context.Customer
            .Include(i => i.Address)
            .Include(i => i.Role)
            .FirstOrDefault(expression);

        return entitie!;
    }

    public override IEnumerable<CustomerEntitie> GetAll()
    {
        return _context.Customer
            .Include(i => i.Address)
            .Include(i => i.Role)
            .ToList();
    }
}


