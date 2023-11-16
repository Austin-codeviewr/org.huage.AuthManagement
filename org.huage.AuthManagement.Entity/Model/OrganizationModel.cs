using org.huage.AuthManagement.Entity.Common;

namespace org.huage.AuthManagement.Entity.Model;

public class OrganizationModel : BaseFiled
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
}