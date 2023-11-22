using M006.Data;

namespace M006;

public class Program
{
	/// <summary>
	/// Main Methode: Bestimmt den Startpunkt des Programms
	/// Muss mindestens einmal pro Projekt existieren
	/// Von hier baut sich das Programm auf
	/// </summary>
	static void Main(string[] args)
	{
		Person p = new Person(); //Erstelle ein Objekt aus dem Bauplan

		p.SetVorname("Max"); //Schreibe in diesem Objekt den neuen Vornamen hinein
        Console.WriteLine($"Vorname von p: {p.GetVorname()}"); //Greife aus diesem Objekt den derzeitigen Vornamen heraus

		p.Nachname = "Mustermann"; //Properties werden wie normale Variablen angegriffen
        Console.WriteLine($"Nachname von p: {p.Nachname}");

		p.Alter = 30; //Auto Property beschreiben
		Console.WriteLine(p.Alter); //Auto Property auslesen

        //p.Gehalt = 10000; //Nicht möglich, da private set
        Console.WriteLine($"Gehalt von p: {p.Gehalt}");

		p.Sprechen("Hallo");

		p.Laufen(Direction.Up);
		p.Laufen(Direction.Up);
		p.Laufen(Direction.Left);
		p.Laufen(Direction.Up);
		p.Laufen(Direction.Right);

		Person p2 = new Person("Max", "Mustermann"); //Direkt bei Erstellung die Werte übergeben
		Person p3 = new Person("Max", "Mustermann", 30); //Beide Konstruktoren werden ausgeführt

		//Assozation von Objekten
		//Objekte in anderen Objekten verschachteln
		//Alles in C# ist ein Objekt
		//-> Jede Variable ist ein Objekt

		int x = 5; //int Objekt
		string s = "abc"; //string Objekt
		Person p4 = new Person(); //Person Objekt

		//Realität
		Kurs k = new Kurs("C# Grundkurs", 4, new DateTime(2023, 11, 21), new DateTime(2023, 11, 24));
		Person trainer = new Person("Lukas", "Kern", 25);
		Person dw = new Person("", "", 30);
		Person cb = new Person("", "", 38);
		Person rf = new Person("", "", 18);
		Person ms = new Person("", "", 26);
		k.Trainer = trainer;
		//k.TeilnehmerHinzufuegen(dw);
		//k.TeilnehmerHinzufuegen(cb);
		//k.TeilnehmerHinzufuegen(rf);
		//k.TeilnehmerHinzufuegen(ms);
		k.TeilnehmerHinzufuegen(dw, cb, rf, ms);

		//Namespaces
		//Gruppierung von Typen (Klassen, Enums, ...) in spezifische Pakete
		//-> Jeder Typ hat ein Paket und ist dadurch kategorisiert
		//Beispiele:
		//System: Standardklassen -> Console, int, string, bool, ...
		//System.IO: Dateisystemklassen -> File, Directory, Path, ...
		//System.Net: Netzwerkklassen: IPAddress, DNS, ...
		//System.Net.Http: Netzwerke, HTTP: HttpClient, HttpResonse, HttpRequest, ...
		//System.Net.Mail: Netzwerke, Email: SmtpClient, MailAdress, ...

		//Jedes Skript sollte einen Namespace haben
		//Im Projekt sollte einen Wurzelnamespace (hier M006)
		//Von der Wurzel gehen weitere Namespaces aus
		//Mittels using können Namespaces importiert werden
		//-> Externe Pakete (Pakete in anderen Namespaces) können eingebunden werden
		//using <Namespace>.<Unternamespace>.<Unterunternamespace> ...;
    }
}