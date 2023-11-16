using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using org.huage.AuthManagement.BizManager.Redis;
using org.huage.AuthManagement.BizManager.wrapper;
using org.huage.AuthManagement.DataBase.Table;
using org.huage.AuthManagement.Entity.Managers;
using org.huage.AuthManagement.Entity.Model;
using org.huage.AuthManagement.Entity.Request;
using org.huage.AuthManagement.Entity.Response;

namespace org.huage.AuthManagement.BizManager.Manager;

public class RoleManager : IRoleManager
{
    private readonly IRepositoryWrapper _wrapper;
    private readonly IRedisManager _redisManager;
    private readonly ILogger<RoleManager> _logger;
    private readonly IMapper _mapper;

    public RoleManager(IRedisManager redisManager, ILogger<RoleManager> logger, IMapper mapper, IRepositoryWrapper wrapper)
    {
        _redisManager = redisManager;
        _logger = logger;
        _mapper = mapper;
        _wrapper = wrapper;
    }

    /// <summary>
    /// 查询所有的角色
    /// </summary>
    /// <returns></returns>
    public async Task<QueryAllRolesResponse> QueryAllRolesAsync(QueryAllRolesRequest request)
    {
        var response = new QueryAllRolesResponse();
        
        try
        {
            var allSchedulers = await _redisManager.HGetAllValue<RoleModel>(RedisKeyGenerator.AllRolesRedisKey());
            if (allSchedulers.Any())
            {
                response.RoleModels = allSchedulers;
                return response;
            }

            //查询数据库
            var schedulers = _wrapper.Role.FindAll().Where(_ => _.IsDeleted == false).ToList();
            var data = _mapper.Map<List<RoleModel>>(schedulers);
            response.RoleModels = data;
            var schedulersDic = schedulers.ToDictionary(_ => _.Id);

            await schedulersDic.ParallelForEachAsync(async scheduler =>
            {
                var redisKey = RedisKeyGenerator.AllRolesRedisKey();
                try
                {
                    foreach (var s in schedulers)
                    {
                        await _redisManager.HashSet(redisKey, scheduler.Key.ToString(),
                            JsonConvert.SerializeObject(scheduler.Value));
                    }
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                }
            });
        }
        catch (Exception e)
        {
            _logger.LogError($"QueryAllRolesAsync error: {e.Message}");
            throw;
        }

        return response;

    }
    
    
    
}