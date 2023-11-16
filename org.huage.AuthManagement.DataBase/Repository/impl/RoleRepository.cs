using org.huage.AuthManagement.DataBase.DBContext;
using org.huage.AuthManagement.DataBase.Table;

namespace org.huage.AuthManagement.DataBase.Repository.impl;

public class RoleRepository :  RepositoryBase<Role>,IRoleRepository
{
    public RoleRepository(AuthDBContext context) : base(context)
    {
    }
}