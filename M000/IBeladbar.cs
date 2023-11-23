namespace M000;

public interface IBeladbar
{
	Fahrzeug GeladenesFahrzeug { get; set; }

	void Belade(Fahrzeug f);

	Fahrzeug Entlade();
}
