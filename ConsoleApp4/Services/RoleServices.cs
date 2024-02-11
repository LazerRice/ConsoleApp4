using ConsoleApp4.Entities;
using ConsoleApp4.Repositories;

namespace ConsoleApp4.Services;

public class RoleServices
{
    private readonly RoleRepository _roleRepository;

    public RoleServices(RoleRepository roleRepository)
    {
        _roleRepository = roleRepository;


    }

    public RoleEntitie CreateRole(string roleName)
    {
        var roleEntitie = _roleRepository.Get(x => x.RoleName == roleName);
        roleEntitie ??= _roleRepository.Create(new RoleEntitie { RoleName = roleName });

        return roleEntitie;

    }

    public RoleEntitie GetRoleByRoleName(string roleName)
    {
        var roleEntite = _roleRepository.Get(x => x.RoleName == roleName);
        return roleEntite;
    }

    public RoleEntitie GetRoleById(int id)
    {
        var roleEntite = _roleRepository.Get(x => x.Id == id);
        return roleEntite;
    }

    public IEnumerable<RoleEntitie> GetRole()
    {
        var role = _roleRepository.GetAll();
        return role;
    }

    public RoleEntitie UpdateRole(RoleEntitie roleEntitie)
    {
        var updatedRoleEntite = _roleRepository.Update(x => x.Id == roleEntitie.Id, roleEntitie);
        return updatedRoleEntite;
    }

    public void DeleteRole(int id)
    {
        _roleRepository.Delete(x => x.Id == id);
    }
}
