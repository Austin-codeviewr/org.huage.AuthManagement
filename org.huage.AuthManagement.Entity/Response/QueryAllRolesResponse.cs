using org.huage.AuthManagement.Entity.Model;

namespace org.huage.AuthManagement.Entity.Response;

public class QueryAllRolesResponse
{
    public List<RoleModel> RoleModels { get; set; } = new List<RoleModel>();
}