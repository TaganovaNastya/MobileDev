namespace cnsEnum
{
    internal class Program
    {
        public enum SingleColor { red, green, blue = 100500, White }

        public enum MultiColor { red, green, blue }

        static void Main(string[] args)
        {
            SingleColor singleColor = SingleColor.red;
            Console.WriteLine(singleColor);
            Console.WriteLine(singleColor.ToString("D"));
            singleColor = SingleColor.blue;
            Console.WriteLine(singleColor.ToString("D"));

            MultiColor multiColor = MultiColor.red;
            //multiColor != MultiColor.blue;
        }
    }
}