namespace cnsOOPRectangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyRectangle r = new();
            Console.WriteLine(r.GetArea());

            MyRectangle r2 = new(2, 3);
            Console.WriteLine(r2.GetArea());

            Class1 z;
        }
    }
}