using ConsoleApp4.Entities;
using ConsoleApp4.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ConsoleApp4.Services;

public class CategoryServices
{
    private readonly CategoryRepository _categoryRepository;
    

    public CategoryServices(CategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }


    //CRUD//

    //CREATE
    public CategoryEntitie CreateCategory(string categoryName)
    {
        var categoryEntitie = _categoryRepository.Get(x => x.CategoryName == categoryName);
        categoryEntitie ??= _categoryRepository.Create(new CategoryEntitie { CategoryName = categoryName });

        return categoryEntitie;

    }

    public CategoryEntitie GetCategoryByCategoryName(string categoryName)
    {
        var categoryEntite = _categoryRepository.Get(x => x.CategoryName == categoryName);
        return categoryEntite;
    }

    public CategoryEntitie GetCategoryById(int id)
    {
        var categoryEntite = _categoryRepository.Get(x => x.Id == id);
        return categoryEntite;
    }

    public IEnumerable<CategoryEntitie> GetCategories() 
    {
        var categories = _categoryRepository.GetAll();
        return categories;
    }

    public CategoryEntitie UpdateCategory(CategoryEntitie categoryEntitie)
    {
        var updateCategoryEntite = _categoryRepository.Update(x => x.Id == categoryEntitie.Id, categoryEntitie);
        return updateCategoryEntite;
    }

    public void DeleteCategory(int id)
    {
        _categoryRepository.Delete(x => x.Id == id);
    }
}



