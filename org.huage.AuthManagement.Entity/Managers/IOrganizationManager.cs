using org.huage.AuthManagement.Entity.Request;
using org.huage.AuthManagement.Entity.Response;

namespace org.huage.AuthManagement.Entity.Managers;

public interface IOrganizationManager
{
    Task<QueryRoleForThisOrganizationResponse> QueryRoleForThisOrganizationAsync(int id);

    Task<AddOrganizationResponse> AddOrganizationAsync(AddOrganizationRequest request);
}