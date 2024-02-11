using System.Linq.Expressions;
using ConsoleApp4.Context;

namespace ConsoleApp4.Repositories;

public class Repo<TEntity> where TEntity : class

{
    private readonly LocalDataContext _context;


    public Repo(LocalDataContext context)
    {
        _context = context;
    }


    //CRUD//

    //CREATE
    public TEntity Create(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        _context.SaveChanges();
        return entity;
    }
    //Läsbar lista
    public virtual IEnumerable<TEntity> GetAll()
    {
        return _context.Set<TEntity>().ToList();
    }

    //READ
    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)

    { //Får ett felmeddelande här när jag ska föröska lägga till kategori. Error meddalande: Microsoft.Data.SqlClient.SqlException: 'Invalid column name 'CategoryName'.'
        var entity = _context.Set<TEntity>().FirstOrDefault();
        return entity!;

    }


    //UPDATE
    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        var entityToUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Entry(entityToUpdate!).CurrentValues.SetValues(entity);
        _context.SaveChanges();

        return entityToUpdate!;
    }
    //DELETE
    public virtual void Delete (Expression<Func<TEntity, bool>> expression)
    {
        var entity = _context.Set<TEntity>().FirstOrDefault(expression);
        _context.Remove(entity!);
        _context.SaveChanges();

    }

}


