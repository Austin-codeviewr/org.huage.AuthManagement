namespace org.huage.AuthManagement.DataBase.Table;

public class OrganizationRole : BaseTable
{
    public int Id { get; set; }
    /// <summary>
    /// 组织id
    /// </summary>
    public int OrganizationId { get; set; }
    
    /// <summary>
    /// 角色id
    /// </summary>
    public int RoleId { get; set; }
}