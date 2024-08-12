namespace CarEdit_Server.Models.DTO;

public class UserStatistics
{
    public long UserId { get; set; }
    public string UserName { get; set; }
    public List<StatisticsByDay> StatisticsByDay { get; set; }
}