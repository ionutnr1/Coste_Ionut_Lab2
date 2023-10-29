//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Coste_Ionut_Lab2.Data;
//using System.Xml.Linq;

//namespace Coste_Ionut_Lab2.Models
//{
//    public class BookCategoriesPageModel:PageModel
//    {
//        public List<AssignedCategoryData> AssignedCategoryDataList;
//        public void PopulateAssignedCategoryData (Coste_Ionut_Lab2Context context, Book book)
//        {
//            var allCategories = context.Category;
//            var bookCategories = new HashSet<int>(book BookCategories.Select(c => c.CategoryID)); 
//            AssignedCategoryDataList = new List<AssignedCategoryData>();
//            foreach (var cat in allCategories)
//            {
//                AssignedCategoryDataList.Add(new AssignedCategoryData)
//                {
//                    CategoryID = cat.ID, 
//                        Name = cat.CategoryName, 
//                        Assigned = bookCategories.Contains(cat.ID)
//                )};
//            }
//        }
//        public void UpdateBookCategories(Coste_Ionut_Lab2Context context, string[] selectedCategories, Book bookToUpdate)
//        {
//            if (selectedCategories == null)
//            {
//                bookToUpdate.BookCategories = new List<BookCategory>();
//                return;
//            }
//            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
//            var bookCategories =  new HashSet<int>(bookToUpdate.BookCategories.Select(c => c.Category.ID));
//            foreach (var item in context.Category)
//            {
//                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
//                {
//                    if (!bookCategories.Contains(cat.ID))
//                    {
//                        bookToUpdate.BookCategories.Add(new BookCategory
//                        {
//                            BookID = bookToUpdate.ID,
//                            CategoryID = cat.ID
//                        });
//                    }
//                }
//                else
//                {
//                    if (bookCategories.Contains(cat.ID))
//                    {
//                        BookCategory courseToRemove
//                            = bookToUpdate
//                                .BookCategories
//                                    .SingleOrDefault(i => i.CategoryID == cat.ID);
//                        context.Remove(courseToRemove);
//                    }
//                }
//            }
//        }
//    }
//}

//using Microsoft.AspNetCore.Mvc.RazorPages;
//using Coste_Ionut_Lab2.Data;
//using Coste_Ionut_Lab2.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace Coste_Ionut_Lab2.Models
//{
//    public class BookCategoriesPageModel : PageModel
//    {
//        public List<AssignedCategoryData> AssignedCategoryDataList;

//        // To protect from overposting attacks, enable the specific properties you want to bind to.
//        // For more details, see https://aka.ms/RazorPagesCRUD.
//        public async Task<IActionResult> OnPostAsync(int? id, string[]
//selectedCategories)
//        {
//            if (id == null || _context.Book == null)
//            {
//                return NotFound();
//            }
//            //se va include Author conform cu sarcina de la lab 2
//            var bookToUpdate = await _context.Book
//            .Include(i => i.Publisher)
//            .Include(i => i.BookCategories)
//            .ThenInclude(i => i.Category)
//            .FirstOrDefaultAsync(s => s.ID == id);
//            if (bookToUpdate == null)
//            {
//                return NotFound();
//            }
//            //se va modifica AuthorID conform cu sarcina de la lab 2
//            if (await TryUpdateModelAsync<Book>(
//            bookToUpdate,
//            "Book",
//            i => i.Title, i => i.Author,
//            i => i.Price, i => i.PublishingDate, i => i.PublisherID))
//            {
//                UpdateBookCategories(_context, selectedCategories, bookToUpdate);
//                await _context.SaveChangesAsync();
//                return RedirectToPage("./Index");
//            }
//            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
//            //este editata
//            UpdateBookCategories(_context, selectedCategories, bookToUpdate);
//            PopulateAssignedCategoryData(_context, bookToUpdate);
//            return Page();
//        }
//        public void PopulateAssignedCategoryData(Coste_Ionut_Lab2Context context,
//        Book book)
//        {
//            var allCategories = context.Category;
//            var bookCategories = new HashSet<int>(
//            book.BookCategories.Select(c => c.CategoryID)); //
//            AssignedCategoryDataList = new List<AssignedCategoryData>();
//            foreach (var cat in allCategories)
//            {
//                AssignedCategoryDataList.Add(new AssignedCategoryData
//                {
//                    CategoryID = cat.ID,
//                    Name = cat.CategoryName,
//                    Assigned = bookCategories.Contains(cat.ID)
//                });
//            }
//        }
//        public void UpdateBookCategories(Coste_Ionut_Lab2Context context,
//        string[] selectedCategories, Book bookToUpdate)
//        {
//            if (selectedCategories == null)
//            {
//                bookToUpdate.BookCategories = new List<BookCategory>();
//                return;
//            }
//            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
//            var bookCategories = new HashSet<int>
//            (bookToUpdate.BookCategories.Select(c => c.Category.ID));
//            foreach (var cat in context.Category)
//            {
//                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
//                {
//                    if (!bookCategories.Contains(cat.ID))
//                    {
//                        bookToUpdate.BookCategories.Add(
//                        new BookCategory
//                        {
//                            BookID = bookToUpdate.ID,
//                            CategoryID = cat.ID
//                        });
//                    }
//                }
//                else
//                {
//                    if (bookCategories.Contains(cat.ID))
//                    {
//                        BookCategory courseToRemove
//                        = bookToUpdate
//                        .BookCategories
//                        .SingleOrDefault(i => i.CategoryID == cat.ID);
//                        context.Remove(courseToRemove);
//                    }
//                }
//            }
//        }
//    }
//}

using Coste_Ionut_Lab2.Data;
using Coste_Ionut_Lab2.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class BookCategoriesPageModel : PageModel
{
    public List<AssignedCategoryData> AssignedCategoryDataList;
    public void PopulateAssignedCategoryData(Coste_Ionut_Lab2Context context,
    Book book)
    {
        var allCategories = context.Category;
        var bookCategories = new HashSet<int>(
        book.BookCategories.Select(c => c.CategoryID)); //
        AssignedCategoryDataList = new List<AssignedCategoryData>();
        foreach (var cat in allCategories)
        {
            AssignedCategoryDataList.Add(new AssignedCategoryData
            {
                CategoryID = cat.ID,
                Name = cat.CategoryName,
                Assigned = bookCategories.Contains(cat.ID)
            });
        }
    }
    public void UpdateBookCategories(Coste_Ionut_Lab2Context context,
    string[] selectedCategories, Book bookToUpdate)
    {
        if (selectedCategories == null)
        {
            bookToUpdate.BookCategories = new List<BookCategory>();
            return;
        }
        var selectedCategoriesHS = new HashSet<string>(selectedCategories);
        var bookCategories = new HashSet<int>
        (bookToUpdate.BookCategories.Select(c => c.Category.ID));
        foreach (var cat in context.Category)
        {
            if (selectedCategoriesHS.Contains(cat.ID.ToString()))
            {
                if (!bookCategories.Contains(cat.ID))
                {
                    bookToUpdate.BookCategories.Add(
                    new BookCategory
                    {
                        BookID = bookToUpdate.ID,
                        CategoryID = cat.ID
                    });
                }
            }
            else
            {
                if (bookCategories.Contains(cat.ID))
                {
                    BookCategory courseToRemove
                    = bookToUpdate
                    .BookCategories
                    .SingleOrDefault(i => i.CategoryID == cat.ID);
                    context.Remove(courseToRemove);
                }
            }
        }
    }
}