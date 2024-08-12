namespace CarEdit_Server.Models.DTO
{
    public enum RequestCode
    {
        Success = 200,
        SuccessAlready = 208,
        Unauthorized = 401,
        PaymentRequired = 402,
        NotFoundCode = 404,
        AlreadyActivated = 419,
        Error = 500,
        TimeOut = 504,
        UserNotFound,
        Disconect,
    }
}