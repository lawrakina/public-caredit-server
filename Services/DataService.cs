using System.Collections;
using CarEdit_Server.BusinessLogic;
using CarEdit_Server.Models;
using CarEdit_Server.Models.Files;
using CarEdit_server.PublicClasses;
using Microsoft.EntityFrameworkCore;
using File = System.IO.File;

namespace CarEdit_Server.Services
{
    public class DataService(ApplicationContext context, FileService fileService)
    {
        private readonly List<RamFile> _ramFiles = new();
        
        public async Task AddStatistics(long userId, string fileName, FileOperationType fileOperationType)
        {
            var file = await context.Files.FirstOrDefaultAsync(x => x.FileName == fileName);

            await AddStatistics(userId, file, fileOperationType);
        }

        public static async Task UpdateData(long userId, DataECU response)
        {
            using var scope = ServiceLocator.ServiceProvider.CreateScope();
            var dataManager = scope.ServiceProvider.GetRequiredService<DataService>();
            await dataManager.PrivateUpdateData(userId, response);
        }

        public static async Task<DataECU> GetLastResponseSrs(long userId)
        {
            using var scope = ServiceLocator.ServiceProvider.CreateScope();
            var dataManager = scope.ServiceProvider.GetRequiredService<DataService>();
            return await dataManager.PrivateGetLastResponseSrs(userId);
        }

        public static async Task<byte[]> GetBytesAsync(long userId)
        {
            using var scope = ServiceLocator.ServiceProvider.CreateScope();
            var dataManager = scope.ServiceProvider.GetRequiredService<DataService>();
            return await dataManager.PrivateGetBytesAsync(userId);
        }

        public static async Task UpdateData(long userId, DataECU response, byte[] openedFilebytes, int before = 0,
            int after = 0, MaskDataCellType maskType = MaskDataCellType.Default, int adressOffset = 0)
        {
            using var scope = ServiceLocator.ServiceProvider.CreateScope();
            var dataManager = scope.ServiceProvider.GetRequiredService<DataService>();
            await dataManager.PrivateUpdateData(userId, response, openedFilebytes, before = 0,
                after = 0, maskType = MaskDataCellType.Default, adressOffset = 0);
        }

        private async Task<DataECU> PrivateGetLastResponseEcu(long userId)
        {
            var item = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);
            var file = _ramFiles.FirstOrDefault(x => item != null && x.Id == item.Id)?.DataECU;

            return file;
        }

        private async Task<byte[]> PrivateGetBytesAsync(long userId)
        {
            var item = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);
            if (item != null)
            {
                var filePath = item.PathName;

                await using var fstream = File.OpenRead(filePath);
                var byteArray = new byte[fstream.Length];
                await fstream.ReadAsync(byteArray, 0, byteArray.Length);

                return byteArray;
            }

            return Array.Empty<byte>();
        }

        private async Task PrivateUpdateData(long userId, DataECU response)
        {
            var userFile = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);
            if (userFile != null)
            {
                var item = _ramFiles.FirstOrDefault(x => x.Id == userFile.Id)?.DataECU;
                if (item == null)
                {
                    var newFile = new RamFile { Id = userFile.Id, DataECU = response };
                    _ramFiles.Add(newFile);
                    item = response;
                }

                item.VIN = response.VIN;
                item.ECU = response.ECU;
                item.Id = response.Id;
                item.PIN = response.PIN;
                item.Message = response.Message;

                item.Odometr = response.Odometr;

                item.DPF = response.DPF;
                item.ADBLUE = response.ADBLUE;
                item.EGR = response.EGR;
                item.IMMO = response.IMMO;
                item.LAMBDA = response.LAMBDA;
                item.AutoRun = response.AutoRun;
                item.EVAP = response.EVAP;
                item.VSA = response.VSA;
                item.TVA = response.TVA;
                item.SL = response.SL;
                item.BitConfig = response.BitConfig;

                await AddStatistics(userId, userFile, FileOperationType.Modify);

                await context.SaveChangesAsync();
            }
        }

        private async Task PrivateUpdateData(long userId, DataECU response, byte[] openedFilebytes, int before = 0,
            int after = 0, MaskDataCellType maskType = MaskDataCellType.Default, int adressOffset = 0)
        {
            if (response.BindingData != null)
            {
                for (var i = 0; i < response.BindingData.Length; i++)
                {
                    if (response.BindingData[i].Selected && response.BindingData[i].MaskType == maskType)
                    {
                        if (response.CheckDataOnBitMask(dataIndex: i, out var errorCell, out var bitMask))
                        {
                            errorCell.ClearBitDataWithOffset(bitMask);
                        }
                        else
                        {
                            response.BindingData[i].ClearData();

                            foreach (var extraAdress in response.BindingData[i].ExtraAdresses)
                            {
                                openedFilebytes[extraAdress] = 0x000;
                            }
                        }

                        //before errors
                        for (long j = response.BindingData[i].Adress + adressOffset;
                             j > response.BindingData[i].Adress + adressOffset - before + 1;
                             j--)
                        {
                            openedFilebytes[j] = 0x000;
                        }

                        //after errors
                        for (long j = response.BindingData[i].Adress + adressOffset;
                             j < response.BindingData[i].Adress + adressOffset + after;
                             j++)
                        {
                            openedFilebytes[j] = 0x000;
                        }

                        if (response.BindingData[i].DependentErrors != null &&
                            response.BindingData[i].DependentErrors.Count > 0)
                        {
                            var errors = response.BindingData[i].DependentErrors;
                            foreach (var error in errors)
                            {
                                switch (error.DependentErrorType)
                                {
                                    case DependentErrorType.x00:
                                        openedFilebytes[error.address] = 0x00;
                                        break;
                                    case DependentErrorType.x0000:
                                        openedFilebytes[error.address + 0] = 0x00;
                                        openedFilebytes[error.address + 1] = 0x00;
                                        break;
                                    case DependentErrorType.x00000000:
                                        openedFilebytes[error.address + 0] = 0x00;
                                        openedFilebytes[error.address + 1] = 0x00;
                                        openedFilebytes[error.address + 2] = 0x00;
                                        openedFilebytes[error.address + 3] = 0x00;
                                        break;
                                    case DependentErrorType.x0000000000000000:
                                        openedFilebytes[error.address + 0] = 0x00;
                                        openedFilebytes[error.address + 1] = 0x00;
                                        openedFilebytes[error.address + 2] = 0x00;
                                        openedFilebytes[error.address + 3] = 0x00;
                                        openedFilebytes[error.address + 4] = 0x00;
                                        openedFilebytes[error.address + 5] = 0x00;
                                        openedFilebytes[error.address + 6] = 0x00;
                                        openedFilebytes[error.address + 7] = 0x00;
                                        break;
                                    case DependentErrorType.x00000000000000000000:
                                        openedFilebytes[error.address + 0] = 0x00;
                                        openedFilebytes[error.address + 1] = 0x00;
                                        openedFilebytes[error.address + 2] = 0x00;
                                        openedFilebytes[error.address + 3] = 0x00;
                                        openedFilebytes[error.address + 4] = 0x00;
                                        openedFilebytes[error.address + 5] = 0x00;
                                        openedFilebytes[error.address + 6] = 0x00;
                                        openedFilebytes[error.address + 7] = 0x00;
                                        openedFilebytes[error.address + 8] = 0x00;
                                        openedFilebytes[error.address + 9] = 0x00;
                                        break;

                                    case DependentErrorType.xFF:
                                        openedFilebytes[error.address] = 0xFF;
                                        break;
                                    case DependentErrorType.xFFFF:
                                        openedFilebytes[error.address] = 0xff;
                                        openedFilebytes[error.address + 1] = 0xff;
                                        break;
                                    case DependentErrorType.xFFFFFFFF:
                                        openedFilebytes[error.address] = 0xff;
                                        openedFilebytes[error.address + 1] = 0xff;
                                        openedFilebytes[error.address + 2] = 0xff;
                                        openedFilebytes[error.address + 3] = 0xff;
                                        break;
                                }
                            }
                        }
                    }
                }

                foreach (var cell in response.BindingData)
                {
                    switch (cell.ClearType)
                    {
                        case MaskDataCellClearType.OnlyBit:
                            break;
                        default:
                            openedFilebytes[cell.Adress] = (byte)cell.Data;
                            break;
                    }
                }
            }

            if (response.BitConfig != null)
            {
                var bitConfig = response.BitConfig;
                var bitArray = new BitArray(bitConfig.BitArray);
                var bytes = new byte[bitArray.Length / 8 + (bitArray.Length % 8 == 0 ? 0 : 1)];
                bitArray.CopyTo(bytes, 0);
                Array.Reverse(bytes);
                var bitConfigBytes = new byte[bytes.Length];
                bytes.CopyTo(bitConfigBytes, 0);
                for (var i = 0; i < bitConfigBytes.Length; i++)
                {
                    openedFilebytes[bitConfig.Address + i] = bitConfigBytes[i];
                }
            }

            await UpdateData(userId, response);
            await fileService.UpdateFile(userId, openedFilebytes);
        }

        private async Task<DataECU> PrivateGetLastResponseSrs(long userId)
        {
            var item = await context.Files.FirstOrDefaultAsync(x => x.UserId == userId);
            var file = _ramFiles.FirstOrDefault(x => item != null && x.Id == item.Id)?.DataECU;
            var srs = file;
            return srs;
        }

        private async Task AddStatistics(long userId, CeFile ceFile, FileOperationType fileOperationType)
        {
            var itemStat = new FileStatistic()
            {
                UploadDataTime = DateTime.Now,
                UserId = userId,
                OrigFileName = ceFile.OrigFileName,
                FileName = ceFile.FileName,
                OperationType = fileOperationType,
                PluginName = ceFile.PluginName
            };

            context.FileStatistics.Add(itemStat);
            await context.SaveChangesAsync();
        }
    }
}