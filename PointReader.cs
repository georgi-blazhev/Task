using Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeadConsultTask
{
    public class PointReader
    {
        public string FileDestination { get; set; }
        public PointReader(string fileDestination)
        {
            FileDestination = fileDestination;
        }
        public List<Point> GetAllPoints()
        {
            string[] lines = System.IO.File.ReadAllLines(FileDestination);

            List<Point> points = new List<Point>();

            if (lines.Length == 0)
            {
                Console.WriteLine("Empty file!");
            }

            foreach (var line in lines)
            {
                var result = Regex.Matches(line, @"-?\d+");

                if (result.Count != 3)
                {
                    throw new FormatException("Invalid format!");
                }

                points.Add(new Point(int.Parse(result[1].Value),int.Parse(result[2].Value)));
            }
            return points;
        }
    }
}
