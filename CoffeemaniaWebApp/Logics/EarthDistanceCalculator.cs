using CoffeemaniaWebApp.Models;

namespace CoffeemaniaWebApp.Logics
{
    public class EarthDistanceCalculator : IDistanceCalculator
    {
        private const double earthRadiusKm = 6371.0;
        private const double degToRad = Math.PI / 180.0;
        
        public double CalculateDistance(Point point1, Point point2)
        {
            var dX = (point2.X - point1.X) * degToRad;
            var dY = (point2.Y - point1.Y) * degToRad;

            var x1 = (point1.X) * degToRad;
            var x2 = (point2.X) * degToRad;

            var a = Math.Sin(dX / 2) * Math.Sin(dX / 2) +
                    Math.Sin(dY / 2) * Math.Sin(dY / 2) *
                    Math.Cos(x1) * Math.Cos(x2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return c * earthRadiusKm;
        }
    }
}
