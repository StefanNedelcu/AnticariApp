using AnticariApp.Utils.Enums;

namespace AnticariApp.Application.Authentication;

public class LoginResponse
{
    public long UserId { get; set; }
    
    public UserRoles Role { get; set; }
}
