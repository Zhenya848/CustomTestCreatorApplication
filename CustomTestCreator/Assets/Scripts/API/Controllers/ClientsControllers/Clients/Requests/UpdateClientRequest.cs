[System.Serializable]
public record UpdateClientRequest : IRequest
{
    public string Name { get; set; }
    public bool IsRandomTasks { get; set; }
    public bool IsInfiniteMode { get; set; }
}
