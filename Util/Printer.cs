using static System.Console;

namespace CoreEscuela.Util
{
    public static class Printer
    {
        public static void DibujarLinea(int size=10)
        {
            WriteLine("".PadLeft(size, '='));
        }
        public static void WriteTitle(string title)
        {
            DibujarLinea(title.Length);
            WriteLine(title);
            DibujarLinea(title.Length);
        }

        public static void PresioneENTER()
        {
            WriteLine("Presione ENTER para continuar");
        }
    }
}