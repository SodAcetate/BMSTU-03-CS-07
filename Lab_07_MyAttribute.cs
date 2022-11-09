namespace library;

public class MyAttribute : Attribute
{
    public string? Comment { get; }
    public MyAttribute(string comment)
    {
        Comment = comment;
    }
}