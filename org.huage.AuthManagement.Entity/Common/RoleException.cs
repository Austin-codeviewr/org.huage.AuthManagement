namespace org.huage.AuthManagement.Entity.Common;

public class RoleException : Exception
{
    public int ErrorCode { get; set; }
    
    public RoleException()
    {
    }

    public RoleException(string? message) : base(message)
    {
    }

    public RoleException(int errorCode)
    {
        ErrorCode = errorCode;
    }

    public RoleException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}