using Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadConsultTask
{
    public class Quadrant
    {
        public Quadrant(int number)
        {
            Number = number;
        }

        public int Number { get; set; }
        public List<Point> Points { get; set; } = new List<Point>();

    }
}
