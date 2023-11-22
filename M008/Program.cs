namespace M008;

public class Program
{
	static void Main(string[] args)
	{
		//Vererbung
		//Ermöglicht das Definieren von einer Hierarchie von Klassen
		//Oberklassen geben ihre Member an ihre Unterklassen weiter
		//Grund: Polymorphismus

		Mensch m = new Mensch("Max", "Deutsch");
		m.Name = "Max"; //Mensch hat Name geerbt
		m.GetHashCode(); //GetHashCode kommt von Object, weil Object die Oberklasse von allen Klassen ist
		
		//virtual
		m.Bewegen(10); //Mensch bewegt sich um 10m

		Katze k = new Katze("Nein");
		k.Bewegen(20); //Lebewesen bewegt sich um 20m
	}
}

/// <summary>
/// Lebewesen ist die Oberklasse, und gibt alle Member von sich selbst nach unten weiter
/// </summary>
public class Lebewesen
{
	public string Name { get; set; } //Name wird an die Unterklassen weitergegeben

	public Lebewesen(string name) //Konstruktor wird nach unten erzwungen
	{
		Name = name;
	}

	/// <summary>
	/// virtual: Methode kann überschrieben werden, muss aber nicht
	/// Wenn die Methode nicht überschrieben wurde, wird die Basisimplementation ausgeführt
	/// </summary>
	public virtual void Bewegen(int distanz)
	{
        Console.WriteLine($"Lebewesen bewegt sich um {distanz}m");
    }
}

/// <summary>
/// Mit : <Klasse> eine Vererbungshierarchie herstellen
/// Hier: Mensch erbt von Lebewesen, Mensch ist ein Lebewesen
/// </summary>
public class Mensch : Lebewesen
{
	public string Sprache { get; set; }

	/// <summary>
	/// Strg + . -> Generate Constructor
	/// </summary>
	public Mensch(string name, string sprache) : base(name) //Mittels base eine Verkettung herstellen
	{
		Sprache = sprache; //Hier können extra Felder einfach hinzugefügt werden
	}

	/// <summary>
	/// Mittels override kann eine Virtuelle Methode überschrieben werden
	/// override tippen -> Abstand um Vorschläge zu bekommen
	/// </summary>
	public override void Bewegen(int distanz)
	{
        Console.WriteLine($"Mensch bewegt sich um {distanz}m");
    }
}

/// <summary>
/// sealed: Diese Klasse kann nicht weitervererbt werden
/// </summary>
public sealed class Katze : Lebewesen //Katze ist auch ein Lebewesen
{
	public Katze(string name) : base(name)
	{

	}
}