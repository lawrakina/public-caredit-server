using CarEdit_Server.Models;
using CarEdit_Server.Models.DTO;
using CarEdit_Server.Models.Users;
using CarEdit_Server.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarEdit_Server.Controllers;

public class UserController(ApplicationContext context, UserService userService) : Controller
{
    [HttpPost]
    public async Task GetInfo()
    {
        var session = Request.Headers[Constants.Session].ToString();
        try
        {
            var user = await userService.GetUser(session);
            var response = await userService.GetClientInfo(user.Id);
            await Response.WriteAsync(JsonConvert.SerializeObject(response));
        }
        catch (Exception e)
        {
            var errorResponse = new AuthError(session, DateTime.Now, RequestCode.Error, "Auth error");
            await Response.WriteAsync(JsonConvert.SerializeObject(errorResponse));
        }
    }
}