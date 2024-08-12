using CarEdit_Server.Services;
using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Payments;
using Telegram.Bot.Types.ReplyMarkups;
using TelegramBot.Commands;

namespace CarEdit_Server.TelegramBot;

public class MessageSender(
    ITelegramBotClient botClient,
    User me,
    InvoiceService invoiceService,
    UserTariffService userTariffService,
    KeySalesService keySalesService,
    TimeCodeService timeCodeService,
    UserService userService)
{
    public async Task SeyHello(Commands.ICommandDictionary dictionary, Chat chat, User user)
    {
        await botClient.SendTextMessageAsync(chat.Id, dictionary.HelloMessage);
    }

    public async Task SendEnterCode(Commands.ICommandDictionary dictionary, Chat chat, User user)
    {
        var item = await timeCodeService.GenerateCode(user);

        if (item.corrently)
        {
            await botClient.SendTextMessageAsync(chat.Id, $"{dictionary.SendEnterCode} {item.endTime}");
            await botClient.SendTextMessageAsync(chat.Id, $"{item.code}");
        }
        else
        {
            await botClient.SendTextMessageAsync(chat.Id,
                $"Your Id could not be determined, check your privacy settings (Username, phone needed)\r\n" +
                $"Не удалось определить ваш Id, проверьте настройки приватности (Требуется \"Имя пользователя\" и Телефон)");
        }
    }

    public async Task SetStartMenu(Commands.ICommandDictionary dictionary, Chat chat, User user)
    {
        var row1 = new[]
        {
            new KeyboardButton(dictionary.GenerateInputCode),
            new KeyboardButton(dictionary.UserInfo),
        };
        var row2 = new[]
        {
            new KeyboardButton(dictionary.GoToGroup),
            new KeyboardButton(dictionary.DownloadExe),
        };
        var row3 = new[]
        {
            new KeyboardButton(dictionary.Buy1Resources),
            new KeyboardButton(dictionary.Buy10Resources),
        };
        var row4 = new[]
        {
            new KeyboardButton(dictionary.Buy1Month),
            new KeyboardButton(dictionary.Buy1Year),
        };
        var row5 = new[]
        {
            new KeyboardButton(dictionary.GetMyId),
        };

        var keyboard = new ReplyKeyboardMarkup(new[] { row1, row2, row3, row4, row5 });

        await botClient.SendTextMessageAsync(chat.Id, dictionary.ShowMenu, replyMarkup: keyboard);
    }

    public async Task SendUserInfo(Commands.ICommandDictionary dictionary, Chat chat, User user)
    {
        try
        {
            var userInfo = await userService.GetClientInfoByTelegramUser(user.Id);
            var messageInfo = $"Info: {user.Id}\r\n" +
                              $"User: {userInfo.UserName} {userInfo.FirstName} {userInfo.LastName}\r\n" +
                              $"Language: {userInfo.LanguageCode}\r\n" +
                              $"Tariff: {userInfo.Tariff}\r\n" +
                              $"Days: {userInfo.Days}\r\n" +
                              $"Number of files for today: {userInfo.OperationCount}\r\n" +
                              $"Extra files: {userInfo.ExtraFiles}";
            await botClient.SendTextMessageAsync(chat.Id, messageInfo);
        }
        catch (Exception e)
        {
            await botClient.SendTextMessageAsync(chat.Id, $"User id: {user.Id}");
        }
    }

    public async Task CreateInvoice(Chat chat, User user, int fileCount, int time)
    {
        var item = await invoiceService.CreateInvoice(chat, user,
            await invoiceService.GetProduct(file: fileCount, time: time));
        await botClient.SendInvoiceAsync(item.chat_id, item.title, item.description, item.payload,
            invoiceService.ProviderToken, item.currency,
            JsonConvert.DeserializeObject<List<LabeledPrice>>(item.prices));
    }

    public async Task CheckKeySale(Commands.ICommandDictionary dictionary, string message, Chat chat, User user,
        int listMessageId)
    {
        var keyInfo = await keySalesService.CreateKeyInvoiceAsync(dictionary, user, message, listMessageId:listMessageId);

        switch (keyInfo.Status)
        {
            case KeyInfoType.Incorrect:
                await botClient.SendTextMessageAsync(chat.Id, dictionary.IncorrectKeyMessage);
                break;
            case KeyInfoType.TariffAlreadyActivated:
                await SendOffer($"{keyInfo.Message}");
                break;
            case KeyInfoType.Live:
                await SendOffer($"{keyInfo.Message}");
                break;
        }

        return;

        async Task SendOffer(string infoByKey)
        {
            var inlineKeyboard = new InlineKeyboardMarkup(new[]
            {
                new[]
                {
                    dictionary.KeySaleActivate,
                    dictionary.KeySaleCansel
                },
            });
            await botClient.SendTextMessageAsync(
                chat.Id,
                $"{infoByKey}",
                replyMarkup: inlineKeyboard);
        }
    }

    public async Task<Message> GeyTariffInfo(Commands.ICommandDictionary dictionary, Chat chat, User user)
    {
        var tariffs = await userTariffService.GetUserTariffsAsync(telegramId: user.Id);
        var files = await userTariffService.GetUserFilesAsync(telegramId: user.Id);
        var message = "Your active tariffs:\r\n\r\n";
        for (var index = 0; index < tariffs.Count; index++)
        {
            var tariff = tariffs[index];
            message += $"{index + 1}) {tariff.Name}\r\n" +
                       $"- Category: {tariff.Category}, days to end: {tariff.Days}\r\n" +
                       $"- {tariff.Description}\r\n\r\n";
        }

        message += $"Extra files count: {files}";

        return await botClient.SendTextMessageAsync(chat.Id, message);
    }
}