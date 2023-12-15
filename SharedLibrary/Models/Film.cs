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
        //[Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Year { get; set; }
        
        public string Genre { get; set; }

        public string Fida {  get; set; }

        public ICollection<Genstand> Genstands { get; set; } = new HashSet<Genstand>();

        public Film()
        {
            
        }

        public Film(string name, int year, string genre, string fida)
        {
            Name = name;
            Year = year;
            Genre = genre;
            Fida = fida;
        }

        public Film(int id, string name, int year, string genre, string fida)
        {
            Id = id;
            Name = name;
            Year = year;
            Genre = genre;
            Fida = fida;
        }
    }
}
