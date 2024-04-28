namespace ReaderStore.Data;
using Microsoft.EntityFrameworkCore;
using ReaderStore.Models;

public class ApplicationDbContext :DbContext 
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
     public DbSet<BooksEntity> Books{get;set;}
  
}
