using System.Diagnostics;

namespace M012;

internal class Program
{
	static void Main(string[] args)
	{
		#region Einfaches Linq
		//Linq
		//Collections verarbeiten mittels Funktionen (z.B. Where, OrderBy, Sum, Average, ...)
		List<int> list = Enumerable.Range(1, 20).ToList();

        //Erweiterungsmethode
        //Würfel mit Pfeil
        //Alle Linq Funktionen sind Erweiterungsmethoden
        Console.WriteLine(list.Sum());
        Console.WriteLine(list.Average());
        Console.WriteLine(list.Min());
        Console.WriteLine(list.Max());

        Console.WriteLine(list.First()); //Wenn bei First kein Element gefunden wird, wirft es eine Exception
		Console.WriteLine(list.FirstOrDefault()); //Wenn bei First kein Element gefunden wird, kommt der Standardwert des Typens zurück

		Console.WriteLine(list.Last());
		Console.WriteLine(list.LastOrDefault());

        //Console.WriteLine(list.First(e => e % 50 == 0));
        Console.WriteLine(list.FirstOrDefault(e => e % 50 == 0));
		//e: Derzeitiges Element, da Linq eine Schleife über die Liste macht
		//Hier wird anhand der Bedingung das Erste Element gesucht, welches der Bedingung entspricht
		#endregion

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		#region Linq mit Objektliste
		//IEnumerable
		//IEnumerable ist eine Anleitung zum Erstellen der fertigen Liste
		Enumerable.Range(0, 1_000_000_000); //Nur eine Anleitung: 1ms
		//Enumerable.Range(0, 1_000_000_000).ToList(); //Komplette Iteration der Anleitung -> Alle Elemente werden erzeugt -> 4GB RAM

		//Finde alle VWs
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW);

		//Finde alle VWs die mindestens 200km/h fahren können
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW).Where(e => e.MaxV > 200); //2 Schleifen -> 12 Durchgänge, 4 Durchgänge
		fahrzeuge.Where(e => e.Marke == FahrzeugMarke.VW && e.MaxV > 200);

		fahrzeuge.OrderBy(e => e.Marke); //Hier kommt eine neue Liste heraus, originale Liste bleibt unverändert
		fahrzeuge.OrderBy(e => e.Marke).ThenBy(e => e.MaxV); //Mit ThenBy sekundäre, tertiäre, ... Sortierung machen
		fahrzeuge.OrderByDescending(e => e.Marke).ThenByDescending(e => e.MaxV);

		//Können alle unsere Fahrzeuge schneller als 200km/h fahren?
		fahrzeuge.All(e => e.MaxV > 200); //Ergebnis bool

		//Kann mindestens eines unserer Fahrzeuge schneller als 200km/h fahren?
		fahrzeuge.Any(e => e.MaxV > 200); //Ergebnis bool

		fahrzeuge.Any(); //Prüfen, ob die Liste Elemente enthält

		//Zählt die Elemente anhand einer Bedigung
		//Wieviele BMWs haben wir?
		fahrzeuge.Count(e => e.Marke == FahrzeugMarke.BMW); //Ergebnis int

		//Die Durchschnittsgeschwindigkeit aller Fahrzeuge
		fahrzeuge.Average(e => e.MaxV); //Nimm MaxV und errechne einen Durchschnitt
		fahrzeuge.Sum(e => e.MaxV);

		fahrzeuge.Min(e => e.MaxV); //Die kleinste Geschwindigkeit (int)
		fahrzeuge.MinBy(e => e.MaxV); //Das Fahrzeug mit der kleinsten Geschwindigkeit (Fahrzeug)

		fahrzeuge.Max(e => e.MaxV);
		fahrzeuge.MaxBy(e => e.MaxV);

		//Select
		//Liste transformieren

		//Zwei Anwendungsfälle
		//1. Fall (80% aller Fälle): Einzelnes Feld aus der Liste entnehmen
		fahrzeuge.Select(e => e.Marke); //Liste mit Marken entnommen
		fahrzeuge.Select(e => e.MaxV); //Liste mit Geschwindigkeiten entnommen

		//2. Fall (20% aller Fälle): Liste transformieren

		//Alle Dateien in dem gegebenen Ordner ohne Pfad und Erweiterung auslesen
		string[] files = Directory.GetFiles(@"C:\Windows"); //Liste aller Dateien
		List<string> dateinamen = new();
		foreach (string pfad in files)
			dateinamen.Add(Path.GetFileNameWithoutExtension(pfad));

		//Jedes Element des Arrays in die neue Form konvertieren
		List<string> dateinamen2 = 
			Directory.GetFiles(@"C:\Windows")
			.Select(e => Path.GetFileNameWithoutExtension(e))
			.ToList();

        Console.WriteLine(dateinamen.SequenceEqual(dateinamen2));
		#endregion

		#region Erweiterungsmethoden
		//Mit Erweiterungsmethoden können an beliebige Typen in C# Methoden angehängt werden, ohne den Source Code zu verändert
		int x = 834729;
		x.Quersumme();
		Console.WriteLine(23572937.Quersumme());

		//Eigene Linq Methode
		//Eine Liste Randomizen
		fahrzeuge.Shuffle();
        #endregion
    }
}

[DebuggerDisplay("Marke: {Marke}, MaxV: {MaxV}")]
public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}
}

public enum FahrzeugMarke { Audi, BMW, VW }