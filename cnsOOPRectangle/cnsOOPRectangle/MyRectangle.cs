namespace cnsOOPRectangle
{
    internal class MyRectangle
    {
        private int length;
        private int width;

        public MyRectangle()
        {
            length = 1;
            width = 2;
        }

        public MyRectangle(int length, int width)
        {
            this.length = length;
            this.width = width;
        }

        internal int GetArea()
        {
            return 123;
        }
    }
}