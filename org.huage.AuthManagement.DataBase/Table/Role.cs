namespace org.huage.AuthManagement.DataBase.Table;

public class Role : BaseTable
{
    public int Id { get; set; }
    
    /// <summary>
    /// 角色名称
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// 该角色是否公用
    /// </summary>
    public bool IsCommon { get; set; }

    /// <summary>
    /// 目前只支持单个公司私有，后期可以改成
    /// </summary>
    /// <returns></returns>
    //public int Owner;
    
    
    /// <summary>
    /// 关联权限
    /// </summary>
    public virtual ICollection<Permission> Permissions { get; set; }
}