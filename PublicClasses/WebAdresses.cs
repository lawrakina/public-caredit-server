namespace CarEdit_server.PublicClasses
{
    public class WebAdresses
    {
        public static string UserAnalytics = "/useranalytics";
        public static string Server = "https://api.caredit.online";
        public static string CreateSession = "/createsession/";
        public static string CheckCode = "/api/checkcode/";
        public static string CheckSession = "/api/checksession/";
        public static string GetUserInfo = "/api/getuserinfo";

        public static string PublicInfo = "/api/publicinfo";

        public static string VersionClient = "/versionclient";

        //public static string DownloadExeFile = "http://maraschuk-001-site1.etempurl.com/care/publish.htm";
        public static string DownloadExeFile = "https://api.caredit.online/care/publish.htm";
        public static string GotoGroup = "https://t.me/CarEdit_reader";
        public static string UploadFolder = "\\uploads";

        public static string UrlConnect = "/api/connect";

        public static string GetFilesStatistic = "/api/filesstatistic";

        public static string SetFileFromHistory => "/api/setfilefromhistory";
        public static string TryDownloadLastFile => "/api/trydownloadfile";
        public static string GetPluginsMenu => "/api/getmenu";

        //ECU
        public static string UrlEcuUpload = "/api/ecuupload";
        public static string UrlEcuChange = "/api/ecuchange";
    }
}