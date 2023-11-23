using static System.Net.Mime.MediaTypeNames;

namespace M009;

public class Program
{
	static void Main(string[] args)
	{
		#region Polymorphismus
		//Polymorphismus: Typkompatibilität
		//Welche Typen passen mit welchen anderen Typen zusammen?
		//Alle Variablen haben einen Typen, dieser bestimmt welche Objekte damit kompatibel sind
		//Ein Typ ist immer kompatibel mit Objekten von seinem eigenen Typen oder Untertypen

		//Quiz
		//Mensch und Katze: Nein
		//Fahrzeug und Lebewesen: Nein
		//Fahrzeug und PKW: Ja
		//object und Lebewesen: Ja
		object o = new Mensch(); //Eine object Variable kann alles halten
		//o = new Lebewesen();
		o = 123;
		o = false;
		o = new object();
		#endregion

		#region Typen
		//Jedes Objekt hat einen Typen
		//Typen können über 2 verschiedene Wege erlangt werden

		//GetType()
		Type gt = o.GetType(); //Generiert ein Type Objekt, welches sehr viele Informationen enthält (-> Reflection)

		//typeof
		Type t = typeof(Katze); //Generiert ein Type Objekt, anhand eines Typennamens
								//typeof(o) //Nicht möglich
		#endregion

		#region Typvergleiche
		//Typvergleich
		//Typen hinter einer Variable herausfinden
		//2 verschiedene Typvergleiche

		//Exakter Typvergleich
		Lebewesen lw = new Katze();
		if (lw.GetType() == typeof(Katze)) //Ist der Typ des Objekts hinter lw gleich dem Typen der sich aus der Katze Klasse ergibt?
		{
			//true
		}

		if (lw.GetType() == typeof(Lebewesen)) //Ist der Typ des Objekts hinter lw gleich dem Typen der sich aus der Lebewesen Klasse ergibt?
		{
			//false
		}

		//Vererbungshiearchietypvergleich
		if (lw is Katze) //Ist der Typ von dem Objekt hinter lw kompatibel mit Katze?
		{
			//true
		}

		if (lw is Lebewesen) //Ist der Typ von dem Objekt hinter lw kompatibel mit Lebewesen?
		{
			//true
		}

		if (lw is object) //Ist das Objekt hinter lw kompatibel mit object?
		{
			//immer true
		}
		#endregion

		#region Anwendungsbeispiele
		//Test(new Lebewesen());
		Test(new Mensch());
		Test(new Katze());

		Test(123);
		Test(false);
		Test(new int[10]);

		//Variable namens Zoo anlegen, soll beliebig viele Lebewesen halten können
		Lebewesen[] zoo = new Lebewesen[3];
		zoo[0] = new Katze();
		zoo[1] = new Mensch();
		zoo[2] = new Tiger();

		//Informationen über Lebewesen ausgeben
		foreach (Lebewesen l in zoo)
		{
			if (l is Katze) //Achtung: Diese Abfrage ist auch für Tiger gültig
			{
				if (l is Tiger)
					Console.WriteLine("Dieses Tier ist ein Tiger");
				else
					Console.WriteLine("Diese Tier ist eine Katze");
			}

			if (l is Mensch)
			{
				Mensch mensch = (Mensch) l; //Hier die l Variable zu einem Menschen casten, nachdem durch die if bereits klar ist, das es sich hier um einen Menschen handelt
				mensch.Sprechen("Hallo");
            }

			//Jedes Lebewesen muss die Bewegen Methode implementieren -> diese kann auf Lebewesen aufgerufen werden
			l.Bewegen(5);
		}
		#endregion
	}

	/// <summary>
	/// Bei dem Methodenparameter kann ein Lebewesen oder eine Unterklasse von Lebewesen übergeben werden
	/// </summary>
	static void Test(Lebewesen lw) { }

	/// <summary>
	/// Bei dem Methodenparameter kann ein Object oder eine Unterklasse von Object übergeben werden
	/// </summary>
	static void Test(object o) { }

	/// <summary>
	/// Hier kann ein Lebewesen oder eine Unterklasse von Lebewesen zurückgegeben werden
	/// </summary>
	static Lebewesen GetLebewesen()
	{
		//return new Lebewesen();
		//return new Katze();
		return new Mensch();
	}
	
	/// <summary>
	/// Hier kann ein Object oder eine Unterklasse von Object zurückgegeben werden
	/// </summary>
	static object GetObject()
	{
		//return new object();
		//return 123;
		//return false;
		//return 4.5;
		//return new Lebewesen();
		return new int[10];
	}
}

/// <summary>
/// abstract: Definiert diese Klasse als Strukturklasse
/// -> Es gibt kein Lebewesen auf dieser Welt, dass keine Spezifische Bezeichnung hat
/// Effekte von Abstract: Die Klasse kann selbst nicht mehr instanziert werden (mit new)
/// Abstrakte Methoden und Properties können definiert werden, diese müssen dann in den Unterklassen implementiert werden
/// </summary>
public abstract class Lebewesen
{
	//Dieses Property wird in den Unterklassen erzwungen
	public abstract string Name { get; set; }

	//Diese Methode wird in den Unterklassen erzwungen
	public abstract void Bewegen(int distanz);
}

public class Mensch : Lebewesen
{
	public override string Name { get; set; }

	public override void Bewegen(int distanz)
	{
        Console.WriteLine($"Der Mensch bewegt sich um {distanz}m");
    }

	public void Sprechen(string text)
	{
        Console.WriteLine("Mensch sagt: " + text);
    }
}

public class Katze : Lebewesen
{
	public override string Name { get; set; }

	public override void Bewegen(int distanz)
	{
		Console.WriteLine($"Die Katze bewegt sich um {distanz}m");
	}
}

public class Tiger : Katze { }