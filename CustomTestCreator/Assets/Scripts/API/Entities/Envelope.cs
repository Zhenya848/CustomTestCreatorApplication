using System;

public record Envelope<T>
{
    public T Result { get; set; }
    public Error[] ResponseErrors { get; set; }

    public DateTime? Time { get; set; }
}