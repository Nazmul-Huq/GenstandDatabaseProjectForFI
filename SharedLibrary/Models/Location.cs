using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary.Models
{
    public class Location
    {


        public int Id { get; set; }

        //[Required]
        public string Address { get; set; } //= string.Empty;




        public ICollection<Genstand> Genstands { get; set; } = new HashSet<Genstand>();

    }
}
