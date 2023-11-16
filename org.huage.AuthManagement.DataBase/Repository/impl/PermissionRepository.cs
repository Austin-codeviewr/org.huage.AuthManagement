using org.huage.AuthManagement.DataBase.DBContext;
using org.huage.AuthManagement.DataBase.Table;

namespace org.huage.AuthManagement.DataBase.Repository.impl;

public class PermissionRepository:  RepositoryBase<Permission>,IPermissionRepository
{
    public PermissionRepository(AuthDBContext context) : base(context)
    {
    }
}