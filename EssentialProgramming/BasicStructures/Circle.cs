namespace BasicStructures
{
    public class Circle
    {
        private const double PI = 3.142;
        private double radius;
        public Circle(double _radius)
        {
            radius = _radius;
        }
        
        double CalculateArea()
        {
            return PI*radius*radius;
        }

        public override string ToString()
        {
           // return "Circle radius: " + radius;
           return $"Radius {radius}, Area: {CalculateArea()}";
        }
    }
}