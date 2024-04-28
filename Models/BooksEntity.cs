using System.ComponentModel.DataAnnotations;

namespace ReaderStore.Models;

public class BooksEntity{
    public int Id { get; set; }   
    [MaxLength(100)]  
    [Required] 
    public string Title { get; set; } 

    [MaxLength(100)]
    public string Author { get; set; } 
    [MaxLength(50)]
    public string published { get; set; } 
    public string Category { get; set; } 

    public string Image{get; set;}
}