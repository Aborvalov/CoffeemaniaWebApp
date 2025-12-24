using CoffeemaniaWebApp.Models;

namespace CoffeemaniaWebApp.Logics
{
    public class PlanarDistanceCalculator : IDistanceCalculator
    {
        public double CalculateDistance(Point point1, Point point2)
            => Math.Sqrt(
                Math.Pow(point2.X - point1.X, 2) +
                Math.Pow(point2.Y - point1.Y, 2));
    }
}
