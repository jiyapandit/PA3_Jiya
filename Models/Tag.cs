//using System.ComponentModel.DataAnnotations;

//namespace PA3_jiya.Models;

//public class Tag
//{
//    public int Id { get; set; }

//    [Required]
//    public string Name { get; set; } = string.Empty;

//    // ✅ Fix: EF Core requires a parameterless constructor
//    public Tag() { }

//    public Tag(int id, string name)
//    {
//        Id = id;
//        Name = name;
//    }
//}

using System.ComponentModel.DataAnnotations;

namespace PA3_jiya.Models;

public class Tag
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    public Tag() { }  // ✅ Leave only this
}
