using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Dtos
{
    public class GenstandDto
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string PhotoReference { get; set; }
        public DateOnly DateOfGenstand { get; set; }
        public double Size { get; set; }
        public string Placement { get; set; }
        public string Condition { get; set; }
        public bool Loan { get; set; }    
        public int FilmId { get; set; }
    }
}
