// Konzol.cs — a saját színes segédosztályunk (1.0)
// Használd nyugodtan! Hogy BELÜL hogyan működik, azt a D blokkban tanuljuk.
static class Konzol
{
    public static void Cim(string szoveg)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"═══ {szoveg} ═══");
        Console.ResetColor();
    }

    public static void Siker(string szoveg)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"✔ {szoveg}");
        Console.ResetColor();
    }

    public static void Veszteseg(string szoveg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{szoveg}");
        Console.ResetColor();
    }

    public static void Hiba(string szoveg)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"X {szoveg}");
        Console.ResetColor();
    }

    public static void Dontetlen(string szoveg)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"{szoveg}");
        Console.ResetColor();
    }
}