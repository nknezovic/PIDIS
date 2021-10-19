using System;

namespace BasicStructures
{
    class Program
    {
        static int Main(string[] args)
        {
            var i = 6;
            var c = 'c';
            var f = 3.6f;
            var d = 6.3m;
            var s = "lab 1";

            Console.WriteLine(i);
            Console.WriteLine(c);
            Console.WriteLine(f);
            Console.WriteLine(d);
            Console.WriteLine(s);

            //Console.WriteLine("\nEnter circle radius: ");
            //var circle = new Circle(Convert.ToDouble(Console.ReadLine()));
            //Console.WriteLine(circle.ToString());

            Console.WriteLine("\nEnter circle radius: ");
            var stringRadius = Console.ReadLine();
            var isParseSucc = double.TryParse(stringRadius, out var radius);
            if(!isParseSucc){
                Console.WriteLine("User please behave!");
                return 1;
            }
            
            var circle = new Circle(radius);
            Console.WriteLine(circle);
            return 0;
        }
    }
}
