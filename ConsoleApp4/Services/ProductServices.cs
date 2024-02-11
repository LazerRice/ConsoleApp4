using ConsoleApp4.Entities;
using ConsoleApp4.Repositories;

namespace ConsoleApp4.Services;

public class ProductServices
{
    private readonly ProductRepository _productRepository;
    private readonly CategoryServices _categoryServices;

    public ProductServices(ProductRepository productRepository, CategoryServices categoryServices)
    {
        _productRepository = productRepository;
        _categoryServices = categoryServices;
    }

    //Har hittade jag ett fel när jag skulle försöka lägga till en ny kategori. Felsökte och tillslut hittade jag felet. Hde lagt "new ProductEntitie" på fel rad. Så programmet visste inte vad som skulle skapas.
    // Vad ett fel kan göra. Har får lite erfarenhet när det gäller att felsöka så detta fel har gjort att jag har suttigt fast i 2 dagar. Tillslut så!
    public ProductEntitie CreateProduct(string title, decimal price, string categoryName)
    {
        var categoryEntite = _categoryServices.CreateCategory(categoryName);

        var productEntitet = new ProductEntitie
        {
            Title = title,
            Price = price,
            CategoryId = (_categoryServices.CreateCategory(categoryName)).Id

         };

        productEntitet = _productRepository.Create(productEntitet);
        return productEntitet;

       

    }

    public ProductEntitie GetProductById(int id)
    {
        var productEntite = _productRepository.Get(x => x.Id == id);
        return productEntite;
    }

    public IEnumerable<ProductEntitie> GetProduct()
    {
        var product = _productRepository.GetAll();
        return product;
    }

    public ProductEntitie UpdateProduct(ProductEntitie productEntitie)
    {
        var updatedProductEntite = _productRepository.Update(x => x.Id == productEntitie.Id, productEntitie);
        return updatedProductEntite;
    }

    public void DeleteProduct(int id)
    {
        _productRepository.Delete(x => x.Id == id);
    }
}
