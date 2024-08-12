using System.Text;
using CarEdit_server.Extentions;
using CarEdit_Server.Services;
using CarEdit_Server.Models;
using CarEdit_Server.Models.DTO;
using CarEdit_Server.Models.Users;
using CarEdit_server.PublicClasses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VoltApi.BusinessLogic;
using VoltApi.Extentions;

namespace CarEdit_Server.Controllers;

public class EcuController(
    UserService userService,
    CarEdit_Server.Services.FileService fileService,
    UserResourcesManager userResourcesManager,
    UserAccessService userAccessService) : Controller
{
    [HttpPost]
    public async Task EcuUploadFile()
    {
        var session = Request.Headers[Constants.Session];
        try
        {
            var user = await userService.GetUser(session);
            var pluginName = Request.Headers[nameof(EcuTypes)].ToString();

            IFormFileCollection files = Request.Form.Files;
            var uploadPath = $"{Directory.GetCurrentDirectory()}{WebAdresses.UploadFolder}";
            Directory.CreateDirectory(uploadPath);
            uploadPath = $"{uploadPath}\\{pluginName}";
            Directory.CreateDirectory(uploadPath);

            if (files.Count == 1)
            {
                var now = DateTime.Now;
                var time =
                    $"{now.Year}{now.Month:d2}{now.Day:d2}{now.Hour:d2}{now.Minute:d2}{now.Second:d2}"
                        .Replace(",", "")
                        .Replace(":", "")
                        .Replace(" ", "");

                var name = files[0].FileName.CleanString();

                var origFileName = $"{pluginName}\\orig_{time}_{name}";
                var origFullPath = $"{uploadPath}\\orig_{time}_{name}";
                var fileName = $"{pluginName}\\{time}_{name}";
                var fullPath = $"{uploadPath}\\{time}_{name}";

                await using var origFileStream = new FileStream(origFullPath, FileMode.Create);
                await files[0].CopyToAsync(origFileStream);
                origFileStream.Close();

                await using var fileStream = new FileStream(fullPath, FileMode.Create);
                await files[0].CopyToAsync(fileStream);
                fileStream.Close();

                await fileService.SetOrigFile(user.Id, fileName, origFileName, fullPath, origFullPath, pluginName);
                await userResourcesManager.SetFileForUpdateUserResources(user.Id, fileName, pluginName);

                var ecu = await LogicEcu.CheckECUAsync(user.Id, pluginName, fullPath);

                var jsonResponse = JsonConvert.SerializeObject(ecu);
                await Response.WriteAsync(jsonResponse);
            }
        }
        catch (Exception e)
        {
            await Response.WriteAsync(
                JsonConvert.SerializeObject(new AuthError(session, DateTime.Now, RequestCode.Error, "Auth error")));
        }
    }

    [HttpPost]
    public async Task EcuChange()
    {
        var session = Request.Headers[Constants.Session];
        try
        {
            var user = await userService.GetUser(session);
            var ecuType = Request.Headers[nameof(EcuTypes)].ToString();

            var reqString = Encoding.Unicode.GetString(Request.Body.ReadAllBytes());
            var dataEcu = JsonConvert.DeserializeObject<DataECU>(reqString);

            var ecu = await LogicEcu.Progress(user.Id, ecuType, dataEcu);
            var fileName = await fileService.GetFileName(user.Id);
            await userResourcesManager.UpdateOperationForUserResources(user.Id, fileName);

            await Response.WriteAsync(JsonConvert.SerializeObject(ecu));
        }
        catch (Exception e)
        {
            await Response.WriteAsync(
                JsonConvert.SerializeObject(new AuthError(session, DateTime.Now, RequestCode.Error, "Auth error")));
        }
    }

    [HttpPost]
    public async Task SetFileFromHistory()
    {
        var session = Request.Headers[Constants.Session];
        try
        {
            var user = await userService.GetUser(session);
            var pluginName = Request.Headers[nameof(EcuTypes)].ToString();
            var fileName = Request.Headers[Constants.FileName].ToString();

            // Split the fileName into folder and actual fileName
            var lastSlashIndex = fileName.LastIndexOf("\\", StringComparison.Ordinal);
            var folder = fileName.Substring(0, lastSlashIndex);
            var actualFileName = fileName.Substring(lastSlashIndex + 1);

            // Remove 'orig_' prefix from actualFileName
            if (actualFileName.StartsWith("orig_"))
            {
                actualFileName = actualFileName.Substring(5);
            }

            var oldPath =
                $"{Directory.GetCurrentDirectory()}{WebAdresses.UploadFolder}\\{folder}\\orig_{actualFileName}";
            var newPath =
                $"{Directory.GetCurrentDirectory()}{WebAdresses.UploadFolder}\\{folder}\\{actualFileName}";

            // Copy old file to new file
            System.IO.File.Copy(oldPath, newPath, true);

            var access = await userAccessService.CheckAccessHistoryFileAsync(user.Id, fileName);

            if (access == RequestCode.Success)
            {
                // Update the file name in the database
                await fileService.SetFileFromHistory(user.Id, newPath, $"{folder}\\{actualFileName}", pluginName);
                await userResourcesManager.SetFileForUpdateUserResources(user.Id, $"{folder}\\{actualFileName}",
                    pluginName,
                    operationCount: 0);
                var ecu = await LogicEcu.CheckECUAsync(user.Id, pluginName, newPath);
                var jsonResponse = JsonConvert.SerializeObject(ecu);
                await Response.WriteAsync(jsonResponse);
            }
            else
            {
                await Response.WriteAsync(
                    JsonConvert.SerializeObject(new AuthError(session, DateTime.Now, access, "Auth error")));
            }
        }
        catch (Exception e)
        {
            await Response.WriteAsync(
                JsonConvert.SerializeObject(new AuthError(session, DateTime.Now, RequestCode.Error, "Auth error")));
        }
    }

    [HttpPost]
    public async Task TryDownloadFile()
    {
        ConnectStruct response;

        try
        {
            var session = Request.Headers[Constants.Session];
            var user = await userService.GetUser(session);

            var accessTariffResources = await userResourcesManager.CheckUserResourcesFromTariffs(user.Id);
            var accessFileResources = await userResourcesManager.CheckUserResourcesFromFiles(user.Id);
            var accessPlugin = await userAccessService.CheckUserAccessToPluginCategory(user.Id);
            var accessAlreadyGranted = await userAccessService.CheckAccessAlreadyGranted(user.Id);

            if ((accessTariffResources && accessPlugin) || accessAlreadyGranted || accessFileResources)
            {
                var path = await fileService.GetPath(user.Id);
                var fileContent = await System.IO.File.ReadAllBytesAsync(path);
                var downloadName = await fileService.GetFileName(user.Id);

                if (!accessAlreadyGranted)
                {
                    await userResourcesManager.UpdateUserResources(user.Id);
                }

                var message = accessTariffResources ? $"1 file spend" : $"1 extra file spend";
                response = new ConnectStruct
                {
                    Code = accessAlreadyGranted ? RequestCode.SuccessAlready : RequestCode.Success,
                    File = fileContent,
                    Info = message
                };
            }
            else
            {
                response = new ConnectStruct { Code = RequestCode.PaymentRequired };
            }
        }
        catch
        {
            response = new ConnectStruct { Code = RequestCode.Error };
        }

        Response.ContentType = "application/json";
        await Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}