using ConsoleApp4.Context;
using ConsoleApp4.Entities;
using ConsoleApp4.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp4.Tests.Repositories;

public class RoleRepository_Tests
{
    private readonly LocalDataContext _context = new(new DbContextOptionsBuilder<LocalDataContext>()
        .UseInMemoryDatabase($"{Guid.NewGuid()}")
        .Options );

    [Fact]
    public async Task CreateAsync_Should_Add_One_RoleEnitite_To_Database_And_Return_Updated_RoleEnitite()
    {
        // Arrange
        var roleRepossitory = new RoleRepository(_context);
        var roleEntite = new RoleEntitie { RoleName = "Tester" };
        // Act
        var result = await roleRepossitory.CreateAsync( roleEntite );
        // Assert
        Assert.NotNull( result );
        Assert.Equal(1, result.Id);
    }

    [Fact]

    public async Task CreateAsync_ShouldNotSaveRecprdToDatabase_ReturnNull()
    {
        //Arrange
        var roleRepository = new RoleRepository(_context);
        var roleEntite = new RoleEntitie();


        //Act
        var resultat = await roleRepository.CreateAsync( roleEntite );

        //Assert
        Assert.Null( resultat );
    }
}
