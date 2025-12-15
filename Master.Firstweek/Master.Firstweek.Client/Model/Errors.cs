using System.Runtime.InteropServices.JavaScript;

namespace Master.Firstweek.Client.Model;
public class ErrorDetail
{
    public string Source { get; set; }
    public string ReasonCode { get; set; }
    public string Description { get; set; }
    public bool Recoverable { get; set; }
    public string Details { get; set; }
}

public class Errors
{
    public List<ErrorDetail> Error { get; set; }
}

public class ErrorResponse
{
    public Errors Errors { get; set; }
}