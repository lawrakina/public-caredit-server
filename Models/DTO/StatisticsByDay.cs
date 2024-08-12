namespace CarEdit_Server.Models.DTO;

public class StatisticsByDay
{
    public DateTime Date { get; set; }
    public List<OperationCount> Operations { get; set; }
}