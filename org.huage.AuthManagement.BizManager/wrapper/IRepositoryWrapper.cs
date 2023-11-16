using org.huage.AuthManagement.DataBase.Repository;

namespace org.huage.AuthManagement.BizManager.wrapper;

public interface IRepositoryWrapper
{
    IRoleRepository Role { get; }
    IOrganizationRepository Organization { get; }
    IPermissionRepository Permission { get; }
    Task<int> SaveChangeAsync();
}