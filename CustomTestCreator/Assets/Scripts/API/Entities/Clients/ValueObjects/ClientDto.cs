using System;

public record ClientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public bool IsRandomTasks { get; set; }
    public bool IsInfiniteMode { get; set; }

    public TestDto[] Tests { get; set; }
}
