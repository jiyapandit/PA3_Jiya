//using System.ComponentModel.DataAnnotations;

//namespace PA3_jiya.Models;

//public class Quote
//{
//    public int Id { get; set; }

//    [Required]
//    public string Text { get; set; } = string.Empty;

//    public string? Author { get; set; }
//    public int Likes { get; set; } = 0;

//    // ✅ Fix: EF Core requires a parameterless constructor
//    public List<Tag> Tags { get; set; } = new();

//    public Quote() { }  // Required for EF Core

//    public Quote(int id, string text, string? author = null, int likes = 0, List<Tag>? tags = null)
//    {
//        Id = id;
//        Text = text;
//        Author = author;
//        Likes = likes;
//        Tags = tags ?? new List<Tag>();
//    }
//}

using System.ComponentModel.DataAnnotations;

namespace PA3_jiya.Models;

public class Quote
{
    public int Id { get; set; }

    [Required]
    public string Text { get; set; } = string.Empty;

    public string? Author { get; set; }
    public int Likes { get; set; } = 0;

    public List<Tag> Tags { get; set; } = new();

    public Quote() { }  // ✅ Leave only this
}
