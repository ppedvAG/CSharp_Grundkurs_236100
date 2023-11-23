public class PKW : Fahrzeug
{ 
	public int AnzSitze { get; set; }

	public PKW(string name, double preis, int maxv, int sitze) : base(name, preis, maxv)
	{
		AnzSitze = sitze;
	}

	public override string Info()
	{
		return base.Info() + $" Es hat {AnzSitze} Sitze.";
	}

	public override void Hupen()
	{
        Console.WriteLine("Huuuuuup");
    }
}
