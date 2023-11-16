namespace org.huage.AuthManagement.DataBase.Table;

public class Organization : BaseTable
{
    public int Id { get; set; }

    /// <summary>
    /// 公司名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 公司注册编码，唯一
    /// </summary>
    public string OrgCode { get; set; }
    
    /// <summary>
    /// 关联一下角色和用户
    /// </summary>
    public virtual ICollection<Role> Roles { get; set; }
    public virtual ICollection<User> Users { get; set; }
}