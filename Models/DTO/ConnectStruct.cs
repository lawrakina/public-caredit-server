namespace CarEdit_Server.Models.DTO
{
    public struct ConnectStruct
    {
        public RequestCode Code;
        public string Session;
        public string Info;
        public byte[] File;
    }
}
