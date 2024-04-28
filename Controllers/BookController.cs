using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ReaderStore.Models;
using ReaderStore.Data;

namespace Amazon.Controllers;

public class BookController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly IWebHostEnvironment environment;

    public BookController(ApplicationDbContext db, IWebHostEnvironment environment) 
    {
      _db = db;  
      this.environment = environment;
    }

   public IActionResult Home()
    {
        var books = _db.Books.ToList();
        return View(books);
    }
    public IActionResult Index()
    {
        var books = _db.Books.ToList();
        return View(books);
    }

    public IActionResult Create()
    {
        return View();
    }
[HttpPost]
public IActionResult Create(Bookdto bookdto)
{
    if(bookdto.Image == null)
    {
        ModelState.AddModelError("ImageFile","The image file is required");
    }

    if (!ModelState.IsValid)
    {
        return View(bookdto);
    }
     //save image

    string newfileName = DateTime.Now.ToString("yyyMMddHHmmssfff");
    newfileName += Path.GetExtension(bookdto.Image!.FileName);

    string imageFullPath = environment.WebRootPath + "/books/" + newfileName;
    using (var stream = System.IO.File.Create(imageFullPath))      
    {
        bookdto.Image.CopyTo(stream);
    }

    //saving in database
    BooksEntity booksEntity = new BooksEntity()
    {
        Title = bookdto.Title,
        Author = bookdto.Author,
        published = bookdto.published,
        Category = bookdto.Category,
        Image = newfileName,
    };

    _db.Books.Add(booksEntity);
    _db.SaveChanges();
    return RedirectToAction("Index");  
}

public IActionResult Edit(int id)
{
    var product = _db.Books.Find(id);
    if(product == null)
    {
        return RedirectToAction("Index", "BooK");

    }
    var bookdto = new Bookdto()
    {
         Title = product.Author,
        Author = product.Author,
        published = product.published,
        Category = product.Category,
    
    };
    ViewData["BookId"] = product.Id;
    ViewData["ImageFileName"] = product.Image;
    return View(bookdto);
}

[HttpPost]
public IActionResult Edit(int id, Bookdto bookdto)
{
    var product = _db.Books.Find(id);
    if(product == null)
    {
        return RedirectToAction("Index", "BooK");

    }
    if(!ModelState.IsValid)
    {
        ViewData["BookId"] = product.Id;
     ViewData["ImageFileName"] = product.Image;
        return View(bookdto);
    }
    //save image

    string newfileName = product.Image;
    if(bookdto.Image!= null)
    {
    newfileName= DateTime.Now.ToString("yyyMMddHHmmssfff");
    newfileName += Path.GetExtension(bookdto.Image!.FileName);
    
    string imageFullPath = environment.WebRootPath + "/books/" + newfileName;
    using (var stream = System.IO.File.Create(imageFullPath))      
    {
        bookdto.Image.CopyTo(stream);
    }
    //deete old image

    string oldImagepath = environment.WebRootPath + "/books/" + product.Image;
    System.IO.File.Delete(oldImagepath);
}

//update the books

product.Title = bookdto.Title;
product.Author = bookdto.Author;
product.Category = bookdto.Category;
product.published = bookdto.published;
product.Image = newfileName;

_db.SaveChanges();
return RedirectToAction("Index", "BooK");
}
public IActionResult Delete(int id)
{
    var product = _db.Books.Find(id);
    if(product == null)
    {
      return RedirectToAction("Index", "BooK");  
    }
    string imageFullPath = environment.WebRootPath + "/books/" + product.Image;
    System.IO.File.Delete(imageFullPath);
    
    _db.Books.Remove(product);
    _db.SaveChanges();
    return RedirectToAction("Index", "BooK");
    
}

}