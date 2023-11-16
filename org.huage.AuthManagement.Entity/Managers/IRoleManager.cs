using org.huage.AuthManagement.Entity.Request;
using org.huage.AuthManagement.Entity.Response;

namespace org.huage.AuthManagement.Entity.Managers;

public interface IRoleManager
{
    Task<QueryAllRolesResponse> QueryAllRolesAsync(QueryAllRolesRequest request);
}