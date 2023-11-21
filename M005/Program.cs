internal class Program
{
	private static void Main(string[] args)
	{
		//Funktionen
		//Code auslagern, der wiederverwendet werden kann

		//Aufbau:
		//<Modifier> <Rückgabetyp> <Name>(<Par1>, <Par2>, ...) { <Body> }

		//Rückgabetyp
		//Typ des Ergebnisses der Funktion
		//Generell void, kann aber ein beliebiger Typ sein
		//void: Kein Ergebnis -> Die Funktion kann nicht in eine Variable geschrieben
		Console.WriteLine(); //void
							 //string s = Console.ReadLine(); //string

		//Name
		//Über den Namen kann die Funktion ausgeführt werden
		//Sollte groß geschrieben sein, CamelCase
		//Können Underscores und Umlaute enthalten, sollten diese aber nicht enthalten

		//Parameterliste
		//Gibt die Werte an, die die Funktion bei Aufruf verlangt
		//Form: <Typ> <Name>, ...

		//Funktionsaufruf über Name
		PrintAddiere(3, 5); //Funktion verlangt 2 Parameter
		PrintAddiere(7, 2); //Funktion verlangt 2 Parameter
		PrintAddiere(10, 42); //Funktion verlangt 2 Parameter
		PrintAddiere(62, 4); //Funktion verlangt 2 Parameter

		int summe = Addiere(4, 7); //Diese Funktion gibt über den Rückgabetyp int eine Zahl zurück
		Console.WriteLine($"Die Summe ist {summe}");

		Addiere(3, 3); //Hier wird die int Funktion ausgewählt
		Addiere(3, 3.0); //Hier wird die double Funktion ausgewählt

        Console.WriteLine(); //18 Overloads, mit verschiedenen Parametern (bool, char, double, string, ...)

		//Spezielle Parameter
		//params: Beliebig viele Parameter
		Summiere(4, 5);
		Summiere(5, 7, 9);
		Summiere(1, 2, 3, 4, 5, 6, 7, 8);
		Summiere(1);
		Summiere();

		int[] zahlen = { 1, 2, 3 };
		Summiere(zahlen);

		//Optionale Parameter: Parameter vorbelegen, die Überschrieben werden können, aber nicht müssen
		AddiereOderSubtrahiere(5, 9); //Hier wird der Standardwert (true) genommen
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9, false); //Hier wird der Standardwert überschrieben
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);
		AddiereOderSubtrahiere(5, 9);

		//out
		//Spezieller Parameter, der mehrere Rückgabewerte ermöglicht
		int diff;
		int sum = AddiereUndSubtrahiere(4, 8, out diff); //Über out <Name> den out Parameter mit einer Variable verbinden

		//int.Parse("abc"); //Absturz
		//TryParse: Versucht zu Parsen und gibt einen Boolean zurück
		//Der Boolean beschreibt, ob das Parsen funktioniert hat. Über den out Parameter kommt das Ergebnis heraus
		int result = 1;
		bool b = int.TryParse("123", out result);
		if (b)
		{
            Console.WriteLine($"Parsen hat funktioniert: {result}");
        }
		else
		{
            Console.WriteLine($"Parsen hat nicht funktioniert");
        }
        Console.WriteLine(result); //Die result Variable ist hier unten sichtbar, egal ob das Parsen funktioniert hat oder nicht
    }

	static void PrintAddiere(int a, int b)
	{
		Console.WriteLine($"{a} + {b} = {a + b}");
	}

	static int Addiere(int a, int b)
	{
		return a + b; //return: Gib ein Ergebnis zurück
	}

	static double Addiere(double a, double b)
	{
		return a + b; //Überladung: Funktion mit demselben Namen, aber unterschiedlichen Parametern definieren
	}

	static int Summiere(params int[] a)
	{
		return a.Sum();
	}

	static int AddiereOderSubtrahiere(int x, int y, bool add = true) //Parametern einen Wert zuweisen, um diese optional zu machen
	{
		if (add)
			return x + y;
		return x - y;
	}

	static int AddiereUndSubtrahiere(int x, int y, out int diff)
	{
		//return new int[]{ x + y, x - y };
		//return (x + y, x - y);

		diff = x - y; //Ergebnis Subtraktion
		return x + y; //Ergebnis Addition
	}

	static void Test(int x) //Return in void Funktion
	{
		if (x == 0)
			return; //Beende die Funktion
        Console.WriteLine(4 / x);
    }

	static void PrintWochentag(DayOfWeek d) //Bestimmte Werte erzwingen als Enum Funktionsparametertyp
	{
        Console.WriteLine(d);
    }
}