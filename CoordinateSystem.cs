using Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadConsultTask
{
    public class CoordinateSystem
    {
        public List<Quadrant> Quadrants { get; set; } = new List<Quadrant>();

        public CoordinateSystem(List<Point> points)
        {
            Quadrant first = new(1);
            Quadrant second = new(2);
            Quadrant third = new(3);
            Quadrant fourth = new(4);

            Quadrants.Add(first);
            Quadrants.Add(second);
            Quadrants.Add(third);
            Quadrants.Add(fourth);

            foreach (var point in points)
            {
                Quadrant quadrant = DetermineQuadrant(point, Quadrants);
                AddToQuadrant(point, quadrant);
            }
        }

        private void AddToQuadrant(Point point, Quadrant quadrant)
        {
            quadrant.Points.Add(point);
        }

        private Quadrant DetermineQuadrant(Point point, List<Quadrant> quadrants)
        {
            if (point.X > 0 && point.Y > 0)
            {
                return quadrants.Where(q => q.Number == 1).FirstOrDefault();
            }
            else if (point.X < 0 && point.Y > 0)
            {
                return quadrants.Where(q => q.Number == 2).FirstOrDefault();
            }
            else if (point.X < 0 && point.Y < 0)
            {
                return quadrants.Where(q => q.Number == 3).FirstOrDefault();
            }

            return quadrants.Where(q => q.Number == 4).FirstOrDefault();
        }

        public Dictionary<int, Point> FindFarthestPoints(Dictionary<int, Point> farthestPointsFromAllQuadrants)
        {
            double maxDistance = 0;

            for (int i = 1; i <= farthestPointsFromAllQuadrants.Count; i++)
            {
                if (maxDistance < farthestPointsFromAllQuadrants[i].Distance)
                {
                    maxDistance = farthestPointsFromAllQuadrants[i].Distance;
                }
            }

            return farthestPointsFromAllQuadrants.Where(p => p.Value.Distance == maxDistance).ToDictionary(p => p.Key, p => p.Value);
        }

        public Dictionary<int, Point> GetFarthestPointsForAllQuadrants()
        {
            Dictionary<int, Point> largestPointsInQuadrant = new();

            foreach (var quadrant in Quadrants)
            {
                double largestDistance = 0;

                foreach (var point in quadrant.Points)
                {
                    point.Distance =
                        Math.Sqrt(
                            Math.Pow(
                                point.Y - 0, 2)
                            + Math.Pow(point.X - 0, 2));

                    if (point.Distance > largestDistance)
                    {
                        largestDistance = point.Distance;

                        var result = quadrant.Points.Where(p => p.Distance == largestDistance).FirstOrDefault();

                        if (result == null)
                        {
                            throw new ArgumentException("Empty point");
                        }

                        largestPointsInQuadrant.Add(quadrant.Number, result);
                    }                
                }
            }
            return largestPointsInQuadrant;
        }
    }
}
