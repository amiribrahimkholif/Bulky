using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Categry Name")]
        public string Name { get; set; }
        [Range(0, 100 ,ErrorMessage = "Display Order must be between 0 and 100.")]
        [DisplayName("Display Order")]
        public int DisplayOrder { get; set; }
    }
}
