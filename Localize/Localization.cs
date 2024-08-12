namespace CarEdit_Server.Localize;

public static class Localization
{
    public const string CREATE_FULL_TARIFF = $"The full access tariff has been applied to";
    public const string ADD_DAYS_TO_FULL_TARIFF_CURRENT_DAYS = $"Added days to the Full tariff";
    public const string ADD_DAYS_TO_YOU_TARIFF_CURRENT_DAYS = $"Added days to your tariff, now there are days";
    public const string ADD_FULL_TARIFF_FROM_TARIFF_CURRENT_DAYS = $"Your full tariff has been recalculated and now there are days";
    public const string ADD_NEW_TARIFF = $"A new tariff has been added";
    public const string CREATE_FULL_TARIFF_WITH_CULC_ALL_TARIFFS_CURRENT_DAYS = $"The Full tariff has been added, all your old tariffs have been recalculated and now the days";
    public const string ADD_FILES_WITH_TIME = $"Added files with no time limit";

    public static async Task<string> LocalizeString(string languageCode, string message)
    {
        // await using var db = new ApplicationContext();
        // var words = message.Split(' ');
        // var word = db.Localizations.FirstOrDefault(x => x.LanguageCode == languageCode && words.Contains(x.Word));
        // message.Repl
        await Task.Delay(0);
        return message;
    }
}