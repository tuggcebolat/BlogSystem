using System.ComponentModel.DataAnnotations;

namespace App.Percistence
{
    public class Category
    {
        
        public int CategoryId{ get; set; }
        public string? CategoryName{ get; set; }
        public string? CategoryDescription { get; set; }
        public List<CategoryPost> PostCategories { get; set; }
    }
    
}
