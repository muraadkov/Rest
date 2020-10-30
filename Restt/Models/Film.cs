using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restt.Models
{
    public class Film
    {
        public long Id { get; set; }
        public long GenreType { get; set; }
        public string Name { get; set; }
        public DateTime DateOfStart { get; set; }
        public DateTime DateOfFinish { get; set; }
        public int Actual { get; set; }

    }
}
