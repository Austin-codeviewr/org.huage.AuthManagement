using org.huage.AuthManagement.DataBase.DBContext;
using org.huage.AuthManagement.DataBase.Table;

namespace org.huage.AuthManagement.DataBase.Repository.impl;

public class OrganizationRepository:  RepositoryBase<Organization>,IOrganizationRepository
{
    public OrganizationRepository(AuthDBContext context) : base(context)
    {
    }
}