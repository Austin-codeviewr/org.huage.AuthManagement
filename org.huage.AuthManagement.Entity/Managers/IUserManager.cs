using org.huage.AuthManagement.Entity.Request;

namespace org.huage.AuthManagement.Entity.Managers;

public interface IUserManager
{
    void AddUser(AddUserRequest request);
    void UpdateUser(UpdateUserRequest request);
    void DeleteBatchUser(List<int> ids);
    void QueryAllUsers();
    void QueryUserByCondition(QueryUserByConditionRequest request);
}