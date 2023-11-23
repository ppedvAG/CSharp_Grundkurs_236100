using M000;
using System.Linq.Expressions;

public class Program
{
	static void Main(string[] args)
	{
		PKW p = new PKW("VW", 20000, 250, 5);
		Console.WriteLine(p.Info());

		Fahrzeug[] fzg = new Fahrzeug[10];
		for (int i = 0; i < fzg.Length; i++)
		{
			fzg[i] = Fahrzeug.GeneriereFahrzeug($"Fahrzeug{i}");
			Console.WriteLine(fzg[i].ToString());
		}

		int pkw = 0, schiff = 0, flugzeug = 0;
		foreach (Fahrzeug f in fzg)
		{
			switch (f)
			{
				case PKW:
					pkw++;
					break;
				case Schiff:
					schiff++;
					break;
				case Flugzeug:
					flugzeug++;
					break;
			}
		}

		//fzg
		//	.GroupBy(e => e.GetType())
		//	.ToDictionary(e => e.Key, e => e.Count());

		Console.WriteLine($"Es wurden {pkw} PKWs, {schiff} Schiffe und {flugzeug} Flugzeuge produziert");
		fzg[2].Hupen();
	}

	static void TesteBelade(Fahrzeug f1, Fahrzeug f2)
	{
		if (f1 == f2)
            Console.WriteLine("Ein Fahrzeug kann sich nicht selbst laden");

        if (f1 is IBeladbar)
		{
			IBeladbar b = (IBeladbar)f1;
			b.Belade(f2);
		}
		else if (f2 is IBeladbar)
		{
			IBeladbar b = (IBeladbar) f2;
			b.Belade(f1);
		}
		else
            Console.WriteLine("Keines der beiden Fahrzeuge ist beladbar");
    }
}