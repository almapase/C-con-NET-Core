using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int size)
        {
            WriteLine("".PadLeft(size, '='));
        }
        public static void WriteTitle(string title)
        {
            DibujarLinea(title.Length);
            WriteLine(title);
            DibujarLinea(title.Length);
        }
    }
}