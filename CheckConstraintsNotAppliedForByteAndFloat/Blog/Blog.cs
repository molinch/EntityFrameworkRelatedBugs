using System.ComponentModel.DataAnnotations;

namespace Blog;

public class Post
{
    public int Id { get; set; }
    public PostType PostType { get; set; }

    [Range(0, 47)]
    public int SomeIntFieldWithRange { get; set; }

    [Range(0, 47)]
    public byte SomeByteFieldWithRange { get; set; }

    [Range(0, 47)]
    public float SomeFloatFieldWithRange { get; set; }
}

public enum PostType
{
    Food,
    Health,
    Travel
}