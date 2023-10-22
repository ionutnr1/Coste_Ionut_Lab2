using System.ComponentModel.DataAnnotations;

namespace Coste_Ionut_Lab2.Models.Authors
{
    public class Authors
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public ICollection<Book> Books { get;  set; }
    }
}
