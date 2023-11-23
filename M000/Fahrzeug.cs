public abstract class Fahrzeug
{
	public string Name { get; set; }

	public int MaxV { get; set; }

	public int AktV { get; set; }

	public double Preis { get; set; }

	public bool MotorAn { get; set; }

	public virtual string Info()
	{
		return $"{Name} kostet {Preis}...";
	}

	public abstract void Hupen();

	public override string ToString()
	{
		return $"{GetType().Name}: {Name}";
	}

	public static Fahrzeug GeneriereFahrzeug(string name)
	{
		Random r = new Random();
		int x = r.Next(0, 3);
		switch (x)
		{
			case 0: return new PKW(name, 20000, 250, 5);
			case 1: return new Schiff(name, 20_000_000, 40, 15);
			default: return new Flugzeug(name, 20_000_000, 1000, 10_000);
		}
	}

	public static Fahrzeug GeneriereFahrzeug2(string name) => Random.Shared.Next(0, 3) switch
	{
		0 => new PKW(name, 20000, 250, 5),
		1 => new Schiff(name, 20_000_000, 40, 15),
		_ => new Flugzeug(name, 20_000_000, 1000, 10_000)
	};

	public Fahrzeug(string name, double preis, int maxv)
	{
		Name = name;
		MaxV = maxv;
		Preis = preis;

		MotorAn = false;
		AktV = 0;
	}
}