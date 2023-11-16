using org.huage.AuthManagement.DataBase.DBContext;
using org.huage.AuthManagement.DataBase.Repository;
using org.huage.AuthManagement.DataBase.Repository.impl;

namespace org.huage.AuthManagement.BizManager.wrapper.impl;

public class RepositoryWrapper : IRepositoryWrapper
{
    
    private readonly AuthDBContext _context;

    private IRoleRepository _roleRepository;
    private IOrganizationRepository _organizationRepository;
    private IPermissionRepository _permissionRepository;
    
    public IRoleRepository Role
    {
        get { return _roleRepository ??= new RoleRepository(_context); }
    }
    
    public IOrganizationRepository Organization
    {
        get { return _organizationRepository ??= new OrganizationRepository(_context); }
    }
    
    public IPermissionRepository Permission
    {
        get { return _permissionRepository ??= new PermissionRepository(_context); }
    }
    
    
    public Task<int> SaveChangeAsync()
    {
        return _context.SaveChangesAsync();
    }
}