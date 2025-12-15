namespace Master.Firstweek.WebApp.Data;

public class RequestResponseLog : EntityBase<RequestResponseLog>
{
    public string Request { get; set; }
    
    public string Response { get; set; }
    
    public string Error { get; set; }
}