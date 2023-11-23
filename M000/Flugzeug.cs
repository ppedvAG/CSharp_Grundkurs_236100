public class Flugzeug : Fahrzeug
{
	public int MaxAltitude { get; set; }

	public Flugzeug(string name, double preis, int maxv, int alt) : base(name, preis, maxv)
	{
		MaxAltitude = alt;
	}

	public override string Info()
	{
		return base.Info() + $" Es hat eine maximale Flughöhe von {MaxAltitude}m.";
	}

	public override void Hupen()
	{
        Console.WriteLine("...");
    }
}