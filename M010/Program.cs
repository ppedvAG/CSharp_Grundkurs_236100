namespace M010;

public class Program
{
	static void Main(string[] args)
	{
		//Interfaces
		//Funktionieren wie Abstrakte Klassen
		//-> haben nur Definitionen, die von den Unterklassen implementiert werden müssen
		//Können nicht erstellt werden

		//Unterschiede zur Abstrakten Klasse:
		//Es können mehrere Interfaces vererbt werden
		//"Sanfte Vererbung" -> Ein Interface fügt nur Funktionen hinzu, eine Klasse gibt eine Hierarchie vor

		//Interfaces werden hauptsächlich verwendet für Polymorphismus
		//-> Typkompatibilität
		//Schiff und Garage können beladen werden, haben aber sonst keine Gemeinsamkeiten

		IAufladbar aufladbar = new Smartphone();
		aufladbar = new EAuto();

		if (aufladbar.GetType() == typeof(EAuto))
		{
            Console.WriteLine("Ist ein EAuto");
        }

		object o = new EAuto();
		//Interfaces können nicht mit GetType() == typeof abgefragt werden, da das Objekt hinter der Variable nie ein Interface sein kann
		if (o.GetType() == typeof(IAufladbar))
			Console.WriteLine("Ist ein Aufladbares Objekt");

		//Mithilfe von is kann geprüft werden, ob ein Objekt ein bestimmtes Interface hat
		if (o is IAufladbar)
			Console.WriteLine("Ist ein Aufladbares Objekt");

		//IEnumerable
		//IEnumerable ist das Basisinterface, dass auf allen Listentypen in C# angebracht ist
		IEnumerable<int> x = new int[10];
		IEnumerable<int> y = new List<int>();
		IEnumerable<int> z = new Stack<int>();
		IEnumerable<int> a = new Queue<int>();
		IEnumerable<char> b = "Das ist ein Text"; //Ein String ist eine Liste von Zeichen (char), ein char hat immer eine Zahl darunter

		//IEnumerable ermöglicht auch das gesamte Linq-System
	}

	/// <summary>
	/// Hier soll ein Parameter existieren, der Smartphones und EAutos nehmen kann
	/// object ist zu offen
	/// Lösung: Interface
	/// </summary>
	static void StromAufladen(IAufladbar aufladbar)
	{
		aufladbar.Aufladen(30);
	}

	static void ListeVerarbeiten<T>(IEnumerable<T> x)
	{

	}
}

public class Elektrogeraet { }

public class Monitor : Elektrogeraet { }

public class Mixer : Elektrogeraet { }

/// <summary>
/// Diese Klasse muss jetzt alle Inhalte des Interfaces implementieren
/// </summary>
public class Smartphone : Elektrogeraet, IAufladbar
{
	private int akkustand;

	public int Akkustand
	{
		get => akkustand;
		set
		{
			if (value >= 0 && value <= 100)
				akkustand = value;
		}
	}

	public string Akkuzustand()
	{
		return $"Derzeitiger Akkustand: {Akkustand}";
	}

	public void Aufladen(int anzahl)
	{
		Akkustand += anzahl;
		if (Akkustand > 100)
			Akkustand = 100;
	}

	public void DauerBisVoll()
	{
        Console.WriteLine($"Dauer bis voll geladen: {(100.0 - Akkustand) / 10} Stunden");
    }
}

public class EAuto : IAufladbar
{
	public int Akkustand { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

	public string Akkuzustand() => throw new NotImplementedException();

	public void Aufladen(int anzahl) => throw new NotImplementedException();

	public void DauerBisVoll() => throw new NotImplementedException();
}

/// <summary>
/// Dieses Interface soll beliebigen Klassen die Möglichkeit geben, aufgeladen zu werden
/// </summary>
public interface IAufladbar
{
	int Akkustand { get; set; }

	void DauerBisVoll();

	void Aufladen(int anzahl);

	string Akkuzustand();
}