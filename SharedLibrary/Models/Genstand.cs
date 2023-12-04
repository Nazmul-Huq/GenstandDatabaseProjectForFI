

using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Genstand
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
