using Telegram.Bot.Types.ReplyMarkups;

namespace TelegramBot.Commands;

public static class Commands
{
    public interface ICommandDictionary
    {
        string HelloMessage { get; }
        string SendEnterCode { get; }
        string GoToGroup { get; }
        string DownloadExe { get; }
        string GenerateInputCode { get; }
        string Buy1Resources { get; }
        string Buy10Resources { get; }
        string Buy1Month { get; }
        string Buy1Year { get; }
        string GetErrorPreCheckout { get; }
        string SuccessfulPayment { get; }
        string ErrorContactSupport { get; }
        string GetMyId { get; }
        string ResentThisCodeToAdmin { get; }
        string UserInfo { get; }
        string IncorrectKeyMessage { get; }
        string KeySaleWelcome { get; }
        string KeySaleActivateText { get; }
        InlineKeyboardButton KeySaleActivate { get; }
        string KeySaleCanselText { get; }
        InlineKeyboardButton KeySaleCansel { get; }
        string KeySaleActivateSuccessfully { get; }
        string TariffAlreadyActivated { get; }
        string ShowMenu { get; }
    }

    public static class Dictionary
    {
        public class Ru : ICommandDictionary
        {
            public string SendEnterCode => "Одноразовый код входа в программу заканчивается в:";
            public string GoToGroup => "В оффициальную группу";
            public string DownloadExe => "Загрузить программу CarEdit";
            public string UserInfo => "Информация о пользователе";
            public string IncorrectKeyMessage => "Ключ содержит ошибки";
            public string KeySaleWelcome => "Ключ  живой, можно активировать";
            public string KeySaleActivateText => "Активировать ключ";
            public InlineKeyboardButton KeySaleActivate => InlineKeyboardButton.WithCallbackData(KeySaleActivateText);
            public string KeySaleCanselText => "Отказаться от активации";
            public InlineKeyboardButton KeySaleCansel => InlineKeyboardButton.WithCallbackData(KeySaleCanselText);
            public string KeySaleActivateSuccessfully => "Ключ успешно активирован, вы получили: ";
            public string TariffAlreadyActivated => "У вас уже такой тариф, активация ключа продлит подписку";
            public string ShowMenu => "CarEdit открыть меню для навигации";

            public string HelloMessage =>
                "Добро пожаловать в CarEdit! Мы рады видеть вас среди наших клиентов.\n\n" +
                "Чтобы начать пользоваться нашей программой, скачайте её по следующей ссылке: https://api.caredit.online/care/publish.htm \n\n" +
                "Если у вас возникнут вопросы или пожелания, присоединяйтесь к нашей группе в Telegram, где вы сможете пообщаться с другими пользователями и получить советы: https://t.me/CarEdit_reader \n\n" +
                "Для получения технической поддержки, пожалуйста, свяжитесь с нашей службой поддержки по следующей ссылке: https://t.me/CarEdit_reader/10730 \n\n" +
                "Если у вас есть любые вопросы, не стесняйтесь обращаться к нам. Мы всегда готовы помочь!\n\n" +
                "С уважением,\nКоманда CarEdit";

            public string GenerateInputCode => "Получить одноразовый код входа";
            public string Buy1Resources => "Купить 1 файл";
            public string Buy10Resources => "Купить 10 файлов";
            public string Buy1Month => "Купить доступ 1 месяц";
            public string Buy1Year => "Купить доступ 1 год";
            public string GetErrorPreCheckout => "Ошибка обработки предварительного платежа";
            public string SuccessfulPayment => "Успешный платеж, купленный тариф и файлы доступны в вашем аккаунте";
            public string ErrorContactSupport => "Ваши средства в сохранности, произошла ошибка.Свяжитесь с техподдержкой";
            public string GetMyId => "Я оплатил через партнера";
            public string ResentThisCodeToAdmin => "Отправьте этот код администратору: https://t.me/lawrakina";
        }

        public class En : ICommandDictionary
        {
            public string SendEnterCode => "The one-time login code expires in:";
            public string GoToGroup => "To Community group";
            public string DownloadExe => "Download exe file";
            public string UserInfo => "User information";
            public string IncorrectKeyMessage => "Error key";
            public string KeySaleWelcome => "The key is alive, it can be activated";
            public string KeySaleActivateText => "Activate key";
            public InlineKeyboardButton KeySaleActivate => InlineKeyboardButton.WithCallbackData(KeySaleActivateText);
            public string KeySaleCanselText => "Activate cansel";
            public InlineKeyboardButton KeySaleCansel => InlineKeyboardButton.WithCallbackData(KeySaleCanselText);
            public string KeySaleActivateSuccessfully => "The key has been successfully activated, you have received: ";
            public string TariffAlreadyActivated => "You already have this tariff, activating the key will extend the subscription";
            public string ShowMenu => "CarEdit show menu for navigation";

            public string HelloMessage =>
                "Welcome to our service! We are delighted to have you among our clients.\n\n" +
                "To start using our program, please download it from the following link: https://api.caredit.online/care/publish.htm \n\n" +
                "If you have any questions or suggestions, join our Telegram group where you can chat with other users and get advice: https://t.me/CarEdit_reader \n\n" +
                "For technical support, please contact our support service through the following link: https://t.me/CarEdit_reader/10730 \n\n" +
                "If you have any questions, feel free to reach out to us. We are always here to help!\n\n" +
                "Best regards,\nSupport Team CarEdit";

            public string GenerateInputCode => "Generate a one-time login code";
            public string Buy1Resources => "Buy 1 File";
            public string Buy10Resources => "Buy 10 files";
            public string Buy1Month => "Buy 1 month access";
            public string Buy1Year => "Buy 1 year access";
            public string GetErrorPreCheckout => "Error pre checkout";

            public string SuccessfulPayment =>
                "Successful payment, purchased tariff and files are available in your account";

            public string ErrorContactSupport => "Your funds are safe, an error occurred. Contact support";
            public string GetMyId => "I paid through a partner";
            public string ResentThisCodeToAdmin => "Send this code to the administrator: https://t.me/lawrakina";
        }
    }
}