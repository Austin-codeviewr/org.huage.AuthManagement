using org.huage.AuthManagement.Entity.Model;

namespace org.huage.AuthManagement.Entity.Request;

public class AddOrganizationRequest
{
    public OrganizationModel OrganizationModel { get; set; }
    
    public List<RoleModel> RoleModels { get; set; }
}