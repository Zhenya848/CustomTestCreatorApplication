public record Error
{
    public string Code { get; set; }
    public string Message { get; set; }
    public int ErrorType { get; set; }
    public string InvalidField { get; set; } = null;
}
