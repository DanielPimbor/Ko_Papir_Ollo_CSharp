Console.OutputEncoding = System.Text.Encoding.UTF8; // konzol class

//alapbol megadott valtozok
int tePontszam = 0;
int robotPontszam = 0;

string targy = "";

int nyertesekSzama = 0;
int vesztesekSzama = 0;

int nyertKorokSzama = 0;
int vesztesKorokSzama = 0;
int dontetlenKorokSzama = 0;


//Főmenü

char valasztas;

do
{
    Console.Clear();

    Konzol.Cim("FŐMENÜ");
    Console.WriteLine("[1] Új mérkőzés");
    Console.WriteLine("[2] Statisztika");
    Console.WriteLine("[3] Statisztika nullázása");
    Console.WriteLine("[K] Kilépés");
    Console.Write("Választás: ");

    valasztas = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (valasztas)
    {
        case '1':
            bool ujMerkozes = true;

            while (ujMerkozes)
            {
                Console.Clear();

                tePontszam = 0;
                robotPontszam = 0;
                bool menube = false;

                Console.WriteLine("Üdvözöllek a kő-papír-olló játékomban!");

                while (tePontszam < 3 && robotPontszam < 3)
                {

                    while (true)
                    {
                        Console.WriteLine("Válassz egy betűt: kő (k), papír (p), olló (o), menü (m)");
                        targy = (Console.ReadLine() ?? "").ToLower();

                        if (targy != "k" && targy != "p" && targy != "o" && targy != "m")
                        {
                            Konzol.Hiba("Hibás választás! Kérlek, válassz k, p, o vagy m betűt.");
                            continue;
                        }

                        break;
                    }

                    if (targy == "m")
                    {
                        menube = true;
                        break;
                    }

                    int gepTargy = Random.Shared.Next(1, 4);

                    if (gepTargy == 1)
                    {
                        Console.WriteLine("A gép választása: kő");
                    }
                    else if (gepTargy == 2)
                    {
                        Console.WriteLine("A gép választása: papír");
                    }
                    else
                    {
                        Console.WriteLine("A gép választása: olló");
                    }

                    if (targy == "k")
                    {
                        Console.WriteLine("A választásod: kő");
                    }
                    else if (targy == "p")
                    {
                        Console.WriteLine("A választásod: papír");
                    }
                    else
                    {

                        Console.WriteLine("A választásod: olló");
                    }
                    if (targy == "k" && gepTargy == 3 || targy == "p" && gepTargy == 1 || targy == "o" && gepTargy == 2)
                    {
                        tePontszam++;
                        Konzol.Siker("Nyertél!");
                        Console.WriteLine("Állás: te {0} – {1} gép", tePontszam, robotPontszam);
                        nyertKorokSzama++;
                    }
                    else if (targy == "k" && gepTargy == 2 || targy == "p" && gepTargy == 3 || targy == "o" && gepTargy == 1)
                    {
                        robotPontszam++;
                        Konzol.Veszteseg("Vesztettél!");
                        Console.WriteLine("Állás: te {0} – {1} gép", tePontszam, robotPontszam);
                        vesztesKorokSzama++;
                    }
                    else
                    {
                        Konzol.Dontetlen("Döntetlen!");
                        Console.WriteLine("Állás: te {0} – {1} gép", tePontszam, robotPontszam);
                        dontetlenKorokSzama++;
                    }


                    if (tePontszam == 3)
                    {
                        Konzol.Siker($"Megnyerted a mérkőzést {tePontszam}:{robotPontszam} arányban!");
                        nyertesekSzama++;
                    }
                    else if (robotPontszam == 3)
                    {
                        Konzol.Veszteseg($"Elvesztetted a mérkőzést {tePontszam}:{robotPontszam} arányban!");
                        vesztesekSzama++;
                    }
                }

                if (menube)
                {
                    ujMerkozes = false;
                }
                else
                {
                    char ujra;

                    do
                    {
                        Console.Write("Akarsz újra játszani? (i/n): ");
                        ujra = char.ToLower(Console.ReadKey().KeyChar);
                        Console.WriteLine();
                    }
                    while (ujra != 'i' && ujra != 'n');

                    if (ujra == 'n')
                    {
                        ujMerkozes = false;
                    }
                }
            }

            break;

        case '2':
            int merkozesekSzama = nyertesekSzama + vesztesekSzama;

            Console.WriteLine($"Lejátszott mérkőzések: {merkozesekSzama}");
            Console.WriteLine($"Nyert mérkőzések: {nyertesekSzama}");
            Console.WriteLine($"Vesztett mérkőzések: {vesztesekSzama}");

            if (merkozesekSzama > 0)
            {
                double gyozelmiArany = (double)nyertesekSzama / merkozesekSzama * 100;
                Console.WriteLine($"Győzelmi arány: {gyozelmiArany:F2}%");
            }

            Console.WriteLine();

            Console.WriteLine($"Nyert körök: {nyertKorokSzama}");
            Console.WriteLine($"Vesztett körök: {vesztesKorokSzama}");
            Console.WriteLine($"Döntetlen körök: {dontetlenKorokSzama}");

            Console.WriteLine();
            Console.WriteLine("Nyomj meg egy billentyűt a visszalépéshez...");
            Console.ReadKey(true);

            break;

        case '3':
            Console.Write("Biztos szeretnéd nullázni a statisztikát? (i/n): ");
            char nullaz = char.ToLower(Console.ReadKey().KeyChar);
            Console.WriteLine();
            if (nullaz == 'i')
            {
                tePontszam = 0;
                robotPontszam = 0;
                nyertesekSzama = 0;
                vesztesekSzama = 0;
                nyertKorokSzama = 0;
                vesztesKorokSzama = 0;
                dontetlenKorokSzama = 0;
                Console.WriteLine("A statisztika nullázva.");
            }
            else
            {
                Console.WriteLine("A statisztika nem lett nullázva.");
            }

            Console.WriteLine();
            Console.WriteLine("Nyomj meg egy billentyűt a visszalépéshez...");
            Console.ReadKey(true);

            break;

        case 'k':
        case 'K':
            Console.WriteLine("Viszlát!");
            break;

        default:
            Konzol.Hiba("Ismeretlen menüpont.");

            Console.WriteLine("Nyomj meg egy billentyűt a visszalépéshez...");
            Console.ReadKey(true);

            break;
    }
}
while (valasztas != 'k' && valasztas != 'K');