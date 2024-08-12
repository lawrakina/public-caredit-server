namespace CarEdit_Server.Models.DTO;

public class ClientFullInfo
{
    public string UserName { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string LanguageCode { get; set; }
    public double Days { get; set; }
    public int OperationCount { get; set; }
    public List<TariffDto>Tariff { get; set; }
    public int ExtraFiles { get; set; }
    
    public class TariffDto
    {
        public string Title { get; set; }
        public int Days { get; set; }
    }
}