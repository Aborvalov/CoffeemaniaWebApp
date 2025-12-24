
using CoffeemaniaWebApp.Models;

namespace CoffeemaniaWebApp.Logics
{
    public static class Helpers
    {
        public static bool IsValidCoordinate(Point point)
            => IsValidCoordinate(point.X, point.Y);
        public static bool IsValidCoordinate(double latitude, double longitude)
            => latitude >= -90 && latitude <= 90 &&
            longitude >= -180 && longitude <= 180;
    }
}
