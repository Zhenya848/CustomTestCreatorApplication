using System.Collections.Generic;

public record CreateTestRequest : IRequest
{
    public string TestName { get; set; }
    public bool IsPublished { get; set; }
    public int Seconds { get; set; }
    public int Minutes { get; set; }
    public int Hours { get; set; }
    public bool IsTimeLimited { get; set; }
    public IEnumerable<string> VerdictsList { get; set; }
}
