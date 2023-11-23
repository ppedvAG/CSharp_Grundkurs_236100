using System.Collections;

namespace M011;

internal class Program
{
	static void Main(string[] args)
	{
		//Generisches Typargument (Generic)
		//Ist ein Typ, der in der Unterliegenden Klasse überall eingesetzt wird, wo er angegeben ist
		//Bei einer generischen Klasse/Methode muss ein Typ angegeben werden, innerhalb der spitzen Klammern (<Typ>)
		//Wird als T bezeichnet

		List<int> list = new List<int>(); //Hier werden alle Vorkommnisse von T durch int ersetzt
		list.Add(123); //T wird zu int

		List<string> strings = new List<string>();
		strings.Add("123"); //T wird zu string

		//Liste kann verwendet werden wie ein Array
		foreach (int i in list)
            Console.WriteLine(i);

		Console.WriteLine(list[0]);


		//Dictionary
		//Liste von Schlüssel- und Wert Paaren
		//Schlüssel müssen eindeutig sein
		Dictionary<string, int> einwohnerzahlen = new(); //Target-typed New: Ergänzt den Typen von Links
		einwohnerzahlen.Add("Wien", 2_000_000);
		einwohnerzahlen.Add("Berlin", 3_650_000);
		einwohnerzahlen.Add("Paris", 2_160_000);
		//einwohnerzahlen.Add("Paris", 2_160_000); //Nicht möglich

		if (einwohnerzahlen.ContainsKey("Wien")) //Prüfen, ob ein Key bereits existiert
            Console.WriteLine("Key Wien existiert bereits");

		//var: Ergänzt den Typen anhand der vorhandenen Informationen
		//var -> KeyValuePair<string, int>
		//var -> Strg + . -> Voller Typ erzeugen
		foreach (KeyValuePair<string, int> x in einwohnerzahlen)
		{
            Console.WriteLine($"Die Stadt {x.Key} hat {x.Value} Einwohner."); //In x befindet sich der Key und der Value getrennt
        }

		Console.WriteLine(einwohnerzahlen["Wien"]); //Den Value anhand eines Keys entnehmen
    }
}