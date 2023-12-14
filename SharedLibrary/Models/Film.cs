using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }
        
        public string Genre { get; set; }

        public string Fida {  get; set; }

        public ICollection<Genstand> Genstands { get; set; } = new HashSet<Genstand>();

    }
}
