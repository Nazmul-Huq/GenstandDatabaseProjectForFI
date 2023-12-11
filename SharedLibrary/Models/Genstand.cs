using System.ComponentModel.DataAnnotations;

namespace SharedLibrary.Models
{
    public class Genstand
    {
        public int Id { get; set; }
        //[Required]
        public string Name { get; set; } //= string.Empty;
        //[Required]
        public string Description { get; set; } //= string.Empty;

        public string Provenance { get; set; }

        public string Accenssion { get; set; }

        public string PhotoReference { get; set; }

        public DateOnly DateOfGenstand { get; set; }

        public double Size { get; set; }

        public string Placement { get; set; }

        public string Presavation { get; set; }

        public string Condition { get; set; }

        public bool Loan { get; set; }

        //public string Category { get; set; }

       // public String Film { get; set; }

       //public string Location { get; set; }

    }
}
