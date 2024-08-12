using System.ComponentModel.DataAnnotations;
using CarEdit_Server.Models.DTO;

namespace CarEdit_Server.Models.Users;

public class AuthError
{
    [Key] public long Id { get; set; }
    public string UserId { get; set; }
    public User? User { get; set; }
    public DateTime DateTime { get; set; }
    public RequestCode Result { get; set; }
    public string Message { get; set; }

    public AuthError(string userId, DateTime dateTime, RequestCode result, string message)
    {
        UserId = userId;
        DateTime = dateTime;
        Result = result;
        Message = message;
    }

    public override string ToString()
    {
        return $"UserId:{UserId}, DateTime:{DateTime}, Result:{Result}, Message:{Message}";
    }
}