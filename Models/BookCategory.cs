namespace Coste_Ionut_Lab2.Models
{
    public class BookCategory
    {
        public int ID { get; set; } 
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
