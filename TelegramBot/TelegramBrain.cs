using CarEdit_Server.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using TelegramBot.Commands;
using CarEdit_Server.Localize;
using CarEdit_server.PublicClasses;

namespace CarEdit_Server.TelegramBot
{
    public class TelegramBrain(IServiceScopeFactory serviceScopeFactory, ILogger<TelegramBrain> logger)
    {
        private ITelegramBotClient _botClient;
        private ReceiverOptions _receiverOptions;
        private MessageSender _sender;

        public async Task Start(WorkModeType workModeType)
        {
            Console.WriteLine($"{typeof(TelegramBrain)} Start...");
            _botClient = workModeType switch
            {
                WorkModeType.DevLawr => new TelegramBotClient("6610254677:AAGYAMsRotqlR5RHxe6pUyckTAlw8uMULm0"),
                WorkModeType.Release => new TelegramBotClient("6936131054:AAHvRs_1-i5d5Mgkq7r4RQuwGMA7CKdzwcE"),
                _ => _botClient
            };

            _receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new[] //https://core.telegram.org/bots/api#update
                {
                    UpdateType.Message,
                    UpdateType.CallbackQuery,
                    UpdateType.PreCheckoutQuery,
                },
                ThrowPendingUpdates = true,
            };

            using var cts = new CancellationTokenSource();

            _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token);

            var me = await _botClient.GetMeAsync(cancellationToken: cts.Token);

            using var scope = serviceScopeFactory.CreateScope();
            var invoiceManager = scope.ServiceProvider.GetRequiredService<InvoiceService>();
            var userTariffManager = scope.ServiceProvider.GetRequiredService<UserTariffService>();
            var keySalesManager = scope.ServiceProvider.GetRequiredService<KeySalesService>();
            var timeCodeManager = scope.ServiceProvider.GetRequiredService<TimeCodeService>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserService>();

            _sender = new MessageSender(_botClient, me, invoiceManager, userTariffManager, keySalesManager, timeCodeManager, userManager);
        
            Console.WriteLine($"{typeof(TelegramBrain)} Started!");
        }

        private async Task UpdateHandler(ITelegramBotClient botClient, Update update,
            CancellationToken cancellationToken)
        {
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var invoiceManager = scope.ServiceProvider.GetRequiredService<InvoiceService>();
                var userTariffManager = scope.ServiceProvider.GetRequiredService<UserTariffService>();
                var keySalesManager = scope.ServiceProvider.GetRequiredService<KeySalesService>();

                try
                {
                    switch (update.Type)
                    {
                        case UpdateType.Message:
                        {
                            var message = update.Message;
                            var user = message.From;
                            var chat = message.Chat;

                            Commands.ICommandDictionary dictionary = user.LanguageCode switch
                            {
                                "ru" => new Commands.Dictionary.Ru(),
                                _ => new Commands.Dictionary.En()
                            };

                            Console.WriteLine($"{user.Id}: {chat.Id}: {message.Text}");
                            
                            if (message.Type == MessageType.Text)
                            {
                                if (message.Text == "/start")
                                {
                                    await _sender.SeyHello(dictionary, chat, user);
                                    await _sender.SendEnterCode(dictionary, chat, user);
                                    await _sender.SetStartMenu(dictionary, chat, user);
                                    return;
                                }

                                if (message.Text == dictionary.GoToGroup)
                                {
                                    await botClient.SendTextMessageAsync(chat.Id, $"{WebAdresses.GotoGroup}");
                                    break;
                                }

                                if (message.Text == dictionary.DownloadExe)
                                {
                                    await botClient.SendTextMessageAsync(chat.Id, $"{WebAdresses.DownloadExeFile}");
                                    break;
                                }

                                if (message.Text == dictionary.UserInfo)
                                {
                                    await _sender.SendUserInfo(dictionary, chat, user);
                                    break;
                                }

                                if (message.Text == dictionary.GenerateInputCode)
                                {
                                    await _sender.SendEnterCode(dictionary, chat, user);
                                    break;
                                }

                                if (message.Text == dictionary.Buy1Resources)
                                {
                                    await _sender.CreateInvoice(chat, user, 1, -1);
                                    break;
                                }

                                if (message.Text == dictionary.Buy10Resources)
                                {
                                    await _sender.CreateInvoice(chat, user, 10, -1);
                                    break;
                                }

                                if (message.Text == dictionary.Buy1Month)
                                {
                                    await _sender.CreateInvoice(chat, user, 10, 30);
                                    break;
                                }

                                if (message.Text == dictionary.Buy1Year)
                                {
                                    await _sender.CreateInvoice(chat, user, 10, 365);
                                    break;
                                }

                                if (message.Text == dictionary.GetMyId)
                                {
                                    await botClient.SendTextMessageAsync(chat.Id, $"{dictionary.ResentThisCodeToAdmin}");
                                    await botClient.SendTextMessageAsync(chat.Id, $"{user.Id}");
                                    break;
                                }

                                if (message.Text is { Length: > 64 } && message.Text.StartsWith("KEY:"))
                                {
                                    var listMessage = await _sender.GeyTariffInfo(dictionary, chat, user);
                                    await _sender.CheckKeySale(dictionary, message.Text, chat, user,
                                        listMessageId: listMessage.MessageId);
                                }
                            }

                            if (message.Type == MessageType.SuccessfulPayment)
                            {
                                var statePayment = await invoiceManager.CompletePayment(user, message.SuccessfulPayment);
                                if (statePayment)
                                {
                                    await userTariffManager.SetUserTariff(user.Id, message.SuccessfulPayment.InvoicePayload);
                                    await botClient.SendTextMessageAsync(chat.Id, dictionary.SuccessfulPayment);
                                }
                                else
                                {
                                    await botClient.SendTextMessageAsync(chat.Id, dictionary.ErrorContactSupport);
                                }
                            }

                            break;
                        }
                        case UpdateType.PreCheckoutQuery:
                        {
                            var query = update.PreCheckoutQuery;
                            Commands.ICommandDictionary dictionary = query.From.LanguageCode switch
                            {
                                "ru" => new Commands.Dictionary.Ru(),
                                _ => new Commands.Dictionary.En()
                            };
                            var available = await invoiceManager.PreCheckout(query);
                            if (available)
                            {
                                await _botClient.AnswerPreCheckoutQueryAsync(query.Id, cancellationToken);
                            }
                            else
                            {
                                await _botClient.AnswerPreCheckoutQueryAsync(query.Id, dictionary.GetErrorPreCheckout,
                                    cancellationToken);
                            }

                            return;
                        }

                        case UpdateType.CallbackQuery:
                        {
                            var callbackQuery = update.CallbackQuery;

                            var user = callbackQuery.From;
                            Commands.ICommandDictionary dictionary = user.LanguageCode switch
                            {
                                "ru" => new Commands.Dictionary.Ru(),
                                _ => new Commands.Dictionary.En()
                            };
                            var chat = callbackQuery.Message.Chat;

                            if (callbackQuery.Data == dictionary.KeySaleActivateText)
                            {
                                var activateInvoiceStruct = await keySalesManager.ActivateInvoiceAsync(user.Id);
                                if (activateInvoiceStruct.Status)
                                {
                                    var message =
                                        await Localization.LocalizeString(user.LanguageCode, activateInvoiceStruct.Message);
                                    if (activateInvoiceStruct.DependMessageId != null)
                                        await _botClient.DeleteMessageAsync(chat.Id, (int)activateInvoiceStruct.DependMessageId,
                                            cancellationToken: cancellationToken);
                                    await _botClient.DeleteMessageAsync(chat.Id, callbackQuery.Message.MessageId,
                                        cancellationToken: cancellationToken);
                                    await _botClient.SendTextMessageAsync(chat.Id, $"{message}\r\n" +
                                                                               $"{dictionary.KeySaleActivateSuccessfully}\r\n" +
                                                                               $"{activateInvoiceStruct.LotTitle}",
                                        cancellationToken: cancellationToken);
                                    await _sender.GeyTariffInfo(dictionary, chat, user);
                                }
                            }

                            if (callbackQuery.Data == dictionary.KeySaleCanselText)
                            {
                                await keySalesManager.CloseInvoiceAsync(user.Id);
                                await _botClient.DeleteMessageAsync(chat.Id, callbackQuery.Message.MessageId,
                                    cancellationToken: cancellationToken);
                                await _botClient.SendTextMessageAsync(chat.Id, dictionary.KeySaleCanselText,
                                    cancellationToken: cancellationToken);
                            }

                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "Error handling update");
                }
            }
        }

        private Task ErrorHandler(ITelegramBotClient botClient, Exception error,
            CancellationToken cancellationToken)
        {
            var ErrorMessage = error switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => error.ToString()
            };

            logger.LogError(ErrorMessage);
            return Task.CompletedTask;
        }
    }
}
