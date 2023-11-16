using org.huage.AuthManagement.Entity.Model;

namespace org.huage.AuthManagement.Entity.Response;

public class QueryRoleForThisOrganizationResponse
{
    public List<RoleModel> Roles { get; set; } = new List<RoleModel>();
}