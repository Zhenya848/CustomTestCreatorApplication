using System;
using System.Collections.Generic;

public record TestDto
{
    public Guid Id { get; set; }
    public Guid ClientId { get; set; }

    public string TestName { get; set; }
    public bool IsPublished { get; set; }

    public LimitTimeDto LimitTime { get; set; }
    public bool IsTimeLimited { get; set; }

    public IEnumerable<string> Verdicts { get; set; }

    public TaskDto[] Tasks { get; set; }
}
