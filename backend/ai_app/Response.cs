using System;

public class Response
{
    public required string model { get; set; }
    public DateTime created_at { get; set; }
    public required string response { get; set; }
    public bool done { get; set; }
}
