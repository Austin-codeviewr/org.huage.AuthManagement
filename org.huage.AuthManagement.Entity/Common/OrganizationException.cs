namespace org.huage.AuthManagement.Entity.Common;

public class OrganizationException : Exception
{
    
    public int ErrorCode { get; set; }
    
    public OrganizationException()
    {
    }

    public OrganizationException(string? message) : base(message)
    {
    }

    public OrganizationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    public OrganizationException(int errorCode)
    {
        ErrorCode = errorCode;
    }
}