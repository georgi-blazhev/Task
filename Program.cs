using LeadConsultTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Config
{
    class Program
    {
        static void Main(string[] args)
        {
            PointReader reader = new PointReader(@"C:\Users\User\source\repos\LeadConsultTask\Coordinates.txt");

            try
            {
                List<Point> allPoints = reader.GetAllPoints();
                CoordinateSystem system = new CoordinateSystem(allPoints);

                var points = system.GetFarthestPointsForAllQuadrants();

                var result = system.FindFarthestPoints(points);

                PrintFarthestNumbers(result);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }           
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void PrintFarthestNumbers(Dictionary<int,Point> result)
        {
            foreach (var point in result)
            {
                Console.WriteLine($"Point({point.Value.X},{point.Value.Y}) from quadrant #{point.Key}");
            }
        }

        
    }
}
