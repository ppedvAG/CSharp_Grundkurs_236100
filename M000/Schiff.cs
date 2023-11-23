using M000;

public class Schiff : Fahrzeug, IBeladbar
{
	public int Tiefgang { get; set; }

	public Fahrzeug GeladenesFahrzeug { get; set; }

	public Schiff(string name, double preis, int maxv, int tiefgang) : base(name, preis, maxv)
	{
		Tiefgang = tiefgang;
	}

	public override string Info()
	{
		return base.Info() + $" Es hat {Tiefgang} Tiefgang." + $" Es hat {GeladenesFahrzeug} geladen.";
	}

	public override void Hupen()
	{
        Console.WriteLine("Tröööööt");
    }

	public void Belade(Fahrzeug f)
	{
		if (GeladenesFahrzeug == null)
			GeladenesFahrzeug = f;
	}

	public Fahrzeug Entlade()
	{
		if (GeladenesFahrzeug != null)
		{
			Fahrzeug f = GeladenesFahrzeug;
			GeladenesFahrzeug = null;
			return f;
		}
		return null;
	}
}
