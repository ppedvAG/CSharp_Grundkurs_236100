#region	Arrays
//Array: Variable, die mehrere Werte halten kann
int[] zahlen; //Mit [] nach dem Typen, eine Array Variable anlegen
zahlen = new int[10]; //Erstelle ein neues Array mit 10 Stellen
zahlen[2] = 5; //Das Array mit denselben Klammern angreifen ("an der Stelle")
Console.WriteLine(zahlen[2]); //Index von 0-Länge (hier 0-9)

int[] zahlenDirekt = new int[] { 1, 2, 3, 4, 5 }; //Hier die Standardwerte festlegen (Index 0-4)
int[] zahlenDirektKurz = new[] { 1, 2, 3, 4, 5 };
int[] zahlenDirektNochKuerze = { 1, 2, 3, 4, 5 };

Console.WriteLine(zahlen.Length); //Die Länge des Arrays (hier 10)
Console.WriteLine(zahlen.Contains(5)); //Ist 5 im Array enthalten (true)

//Mehrdimensionale Arrays
int[,] zahlen2D = new int[3, 3]; //Matrix (3x3)
zahlen2D[1, 1] = 10;
Console.WriteLine(zahlen2D[1, 1]);

Console.WriteLine(zahlen2D.Rank); //Anzahl Dimensionen
Console.WriteLine(zahlen2D.GetLength(0)); //Länge der nullten Dimension (3)
Console.WriteLine(zahlen2D.GetLength(1)); //Länge der ersten Dimension (3)
#endregion

#region Bedingungen
int z1 = 5;
int z2 = 8;

if (z1 == z2)
{
    Console.WriteLine("z1 und z2 sind gleich");
}
else
{
    Console.WriteLine("z1 und z2 sind nicht gleich");
}

if (z1 < z2)
{
    Console.WriteLine("z1 ist kleiner als z2");
}
else if (z1 > z2)
{
	Console.WriteLine("z1 ist größer als z2");
}
else
{
    Console.WriteLine("z1 ist gleich z2");
}

//XOR (^): Die eine Bedingung aber nicht die andere Bedingung -> Eine von beiden aber nicht beide
if (z1 == z2 ^ zahlen.Contains(5))
{
    Console.WriteLine("z1 gleich z2 ODER zahlen enthält 5 ABER nicht beide");
}

//Not (!): Bedingung invertieren
if (!(z1 == z2))
{
    Console.WriteLine("nicht z1 gleich z2");
}

if (!zahlen.Contains(5))
{
    Console.WriteLine("zahlen enthält keine 5");
}

if (zahlen.Contains(5) == false)
{
	Console.WriteLine("zahlen enthält keine 5");
}

if (zahlen.Contains(5) == false)
	Console.WriteLine("zahlen enthält keine 5"); //Einzeilige if's können ohne Klammern geschrieben werden

//Ternary Operator (Fragezeichen Operator): if und else Kompakt machen
//Muss immer ein Ergebnis haben
if (zahlen.Contains(5))
    Console.WriteLine("zahlen enthält 5");
else
    Console.WriteLine("zahlen enthält nicht 5");

//Funktioniert nicht
//zahlen.Contains(5) ? Console.WriteLine("zahlen enthält 5") : Console.WriteLine("zahlen enthält nicht 5");

Console.WriteLine(
	zahlen.Contains(5) ? //Bedingung (if)
	"zahlen enthält 5" : //Falls true
	"zahlen enthält nicht 5"); //Doppelpunkt, else

Console.WriteLine($"zahlen enthält {(zahlen.Contains(5) ? "" : "nicht ")}5");
#endregion