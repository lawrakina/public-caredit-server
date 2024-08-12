using CarEdit_Server.Models;
using CarEdit_Server.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarEdit_Server.Controllers;

public class MenuController(ApplicationContext context, MenuService menuService) : Controller
{
    [HttpGet]
    public async Task Get()
    {
        var session = Request.Headers[Constants.Session];

        if (!string.IsNullOrWhiteSpace(session))
        {
            var menuString = await menuService.GenerateXmlFromPluginsAsync();
            Response.ContentType = "application/json";
            await Response.WriteAsync(menuString);
        }
    }
}