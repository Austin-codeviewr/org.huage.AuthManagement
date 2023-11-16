namespace org.huage.AuthManagement.Entity.Model;

public class RoleModel
{
    /// <summary>
    /// 是否为公共角色
    /// </summary>
    public bool IsCommon { get; set; }

    /// <summary>
    /// 目前只支持单个公司私有，后期可以改成
    /// </summary>
    /// <returns></returns>
    //public int Owner;
}