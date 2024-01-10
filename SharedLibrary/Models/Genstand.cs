using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Genstand
    {
        public int Id { get; set; }
        //[Required] // We can marked as required so form validate this automatisk
        public string Name { get; set; }
        //[Required]
        public string Description { get; set; }

        public string PhotoReference { get; set; }

        public DateOnly DateOfGenstand { get; set; }

        public double Size { get; set; }

        public string Placement { get; set; }

        public string Condition { get; set; }

        public bool Loan { get; set; }

        public Category Category { get; set; }

        public Film Film { get; set; }

        public Location Location { get; set; }

    }
}
