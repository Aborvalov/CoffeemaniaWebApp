using CoffeemaniaWebApp.Models;

namespace CoffeemaniaWebApp.Logics
{
    public interface IDistanceCalculator
    {
        double CalculateDistance(Point point1, Point point2);
    }
}
