using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        
        [Required(ErrorMessage = "Enter category's name")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Fill the description")]
        public string Description { get; set; }
        public string IcoName { get; set; }

        
        public virtual ICollection<Book> Books { get; set; }
    }
}