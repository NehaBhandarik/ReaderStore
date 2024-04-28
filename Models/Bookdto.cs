using System.ComponentModel.DataAnnotations;

namespace ReaderStore.Models;


    public class Bookdto
    {
    [Required,MaxLength(100)]
    public string Title { get; set; } 
    [Required,MaxLength(100)]
    public string Author { get; set; } 
    public string published { get; set; } 
    public string Category { get; set; } 

    public IFormFile ? Image{get; set;} 
    }
