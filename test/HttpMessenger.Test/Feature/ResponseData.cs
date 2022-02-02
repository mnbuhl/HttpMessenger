namespace HttpMessenger.Test.Feature;

// Response data format from reqres.in

public class Response
{
    public Data? Data { get; set; }
    public Support? Support { get; set; }
}
    
public class Data
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Year { get; set; }
    public string? Color { get; set; }
    public string? Pantone_Value { get; set; }
}

public class Support
{
    public string? Url { get; set; }
    public string? Text { get; set; }
}