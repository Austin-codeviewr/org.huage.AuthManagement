using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using org.huage.AuthManagement.BizManager.Redis;
using org.huage.AuthManagement.BizManager.wrapper;
using org.huage.AuthManagement.DataBase.Table;
using org.huage.AuthManagement.Entity.Common;
using org.huage.AuthManagement.Entity.Managers;
using org.huage.AuthManagement.Entity.Model;
using org.huage.AuthManagement.Entity.Request;
using org.huage.AuthManagement.Entity.Response;

namespace org.huage.AuthManagement.BizManager.Manager;

//组织管理
public class OrganizationManager : IOrganizationManager
{
    private readonly IRepositoryWrapper _wrapper;
    private readonly IRedisManager _redisManager;
    private readonly ILogger<OrganizationManager> _logger;
    private readonly IMapper _mapper;
    private readonly IRoleManager _roleManager;

    public OrganizationManager(IRepositoryWrapper wrapper, IRedisManager redisManager, ILogger<OrganizationManager> logger, IMapper mapper, IRoleManager roleManager)
    {
        _wrapper = wrapper;
        _redisManager = redisManager;
        _logger = logger;
        _mapper = mapper;
        _roleManager = roleManager;
    }

    /// <summary>
   /// 组织设置拥有的角色
   /// </summary>
   /// <param name="ids">角色id</param>
    public async Task SetRoles(List<int> ids)
    {
        //参数校验
        if (!ids.Any())
        {
            _logger.LogError("");
        }
        //查询该组织
    }

    /// <summary>
    /// 查询该组织拥有的角色
    /// </summary>
    /// <returns></returns>
    public async Task<QueryRoleForThisOrganizationResponse> QueryRoleForThisOrganizationAsync(int id)
    {
        if (id ==0)
            throw new OrganizationException("请输入正确的参数");
        
        
        var response = new QueryRoleForThisOrganizationResponse();
        //查询公用角色以及私有角色owner为该公司的
        try
        {
            //所有的共有角色
            var sharedRoles = await _wrapper.Role.FindAll()
                .Where(_ => _.IsCommon == true )
                .OrderByDescending(_ => _.UpdateTime).ToListAsync();
            //查询
            
            if (sharedRoles.Any())
            {
                var roleModels = _mapper.Map<List<RoleModel>>(sharedRoles);
                response.Roles = roleModels;
                return response;
            }

            return response;
        }
        catch (Exception e)
        {
            _logger.LogError($"QueryRoleForThisOrganization error:{e.Message}");
            throw;
        }
    }

    /// <summary>
    /// 新增组织的时候允许同步添加公共角色
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public async Task<AddOrganizationResponse> AddOrganizationAsync(AddOrganizationRequest request)
    {
        //参数校验
        if (!IsValidOrgCode(request.OrganizationModel.OrgCode) 
                  || string.IsNullOrEmpty(request.OrganizationModel.Name))
        {
            throw new OrganizationException("请确认输入合法的参数");
        }
        
        var response = new AddOrganizationResponse();
        //删除缓存：
        await _redisManager.DelKey(RedisKeyGenerator.AllRolesRedisKey());
        
        //插入数据库
        var organization = _mapper.Map<Organization>(request);
        _wrapper.Organization.Create(organization);
        await _wrapper.SaveChangeAsync();
        
        await _redisManager.DelKey(RedisKeyGenerator.AllRolesRedisKey());

        return response;
    }
    
    
    /// <summary>
    /// 判断传进来的营业执照是否有效
    /// </summary>
    /// <param name="orgCode"></param>
    /// <returns></returns>
    private bool IsValidOrgCode(string orgCode)
    {
        return true;
    }
}