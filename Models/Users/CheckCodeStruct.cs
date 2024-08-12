using CarEdit_Server.Models.DTO;

namespace CarEdit_Server.Models.Users;

public class CheckCodeStruct
{
    public long userId { get; set; }
    public RequestCode requestCode { get; set; }
}