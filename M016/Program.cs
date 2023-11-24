using System.Globalization;
using System.Text.Json;
using System.Xml.Serialization;
using CsvHelper;

namespace M016;

public class Program
{
	static void Main(string[] args)
	{

	}

	public void Intro()
	{
		//Path, File, Directory
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test");
		string filePath = Path.Combine(folderPath, "Test.txt"); //Diese Pfade sind nur strings, im unterliegenden Dateisystem passiert hier noch nichts

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		//Files schreiben/lesen
		//File.WriteAllText, File.ReadAllText
		//StreamWriter, StreamReader

		StreamWriter sw = new StreamWriter(filePath); //Pfad zum File
		sw.WriteLine("Test1");
		sw.WriteLine("Test2");
		sw.WriteLine("Test3"); //Die Inhalte werden in einen Buffer geschrieben
							   //sw.Flush(); //Mit Flush kann der Inhalt des Buffers in das File geschrieben werden
		sw.Close(); //Writer schließen/Resourcen freigeben
					//Wenn der Stream nicht geschlossen wird, kann das File nicht bewegt/gelöscht/... werden

		//using-Block: Schließt den unterliegenden Stream automatisch am Ende des Blocks
		//Wenn eine Klasse IDisposable hat, kann ein Using Block verwendet werden
		using (StreamWriter sw2 = new StreamWriter(filePath))
		{
			sw2.WriteLine("Test1");
			sw2.WriteLine("Test2");
			sw2.WriteLine("Test3");
		} //Hier wird automatisch Dispose() gemacht

		//using-Statement: Selbiges wie using-Block, aber wird erst am Ende der Methode geschlossen
		//using StreamWriter sw3 = new StreamWriter(filePath);
		//sw3.WriteLine("Test1");
		//sw3.WriteLine("Test2");
		//sw3.WriteLine("Test3");

		using StreamReader sr = new StreamReader(filePath);
		List<string> lines = new();
		while (!sr.EndOfStream)
			lines.Add(sr.ReadLine());
		//sr.ReadToEnd();

		File.WriteAllText(filePath, "Test1\nTest2\nTest3");
		string s = File.ReadAllText(filePath);
	}

	public void NewtonsoftJson()
	{
		//Path, File, Directory
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test");
		string filePath = Path.Combine(folderPath, "Test.txt"); //Diese Pfade sind nur strings, im unterliegenden Dateisystem passiert hier noch nichts

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		////Objekte -> JSON
		//string json = JsonConvert.SerializeObject(fahrzeuge);
		//File.WriteAllText(filePath, json);

		////JSON -> Objekten
		//string readJson = File.ReadAllText(filePath);
		//List<Fahrzeug> readFzg = JsonConvert.DeserializeObject<List<Fahrzeug>>(readJson);
	}

	public void SystemJson()
	{
		//Path, File, Directory
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test");
		string filePath = Path.Combine(folderPath, "Test.txt"); //Diese Pfade sind nur strings, im unterliegenden Dateisystem passiert hier noch nichts

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Serialisierung
		//Objekte aus dem Programm heraus bewegen
		//-> In ein Format konvertieren, welches gespeichert/gelesen werden kann


		//JSON: JavaScript Objekt Notation
		//Generell das Datei Format im Internet

		//NuGet-Packages
		//Externe Pakete, die nach Bedarf dazu installiert werden können
		//Tools -> NuGet Package Manager -> Manage NuGet Packages

		//Objekte -> JSON
		string json = JsonSerializer.Serialize(fahrzeuge);
		File.WriteAllText(filePath, json);

		//JSON -> Objekten
		string readJson = File.ReadAllText(filePath);
		List<Fahrzeug> readFzg = JsonSerializer.Deserialize<List<Fahrzeug>>(readJson);
	}

	public void XML()
	{
		//Path, File, Directory
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test");
		string filePath = Path.Combine(folderPath, "Test.txt"); //Diese Pfade sind nur strings, im unterliegenden Dateisystem passiert hier noch nichts

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Serialisierung
		//Objekte aus dem Programm heraus bewegen
		//-> In ein Format konvertieren, welches gespeichert/gelesen werden kann


		//XML: Extensible Markup Language
		//Generell das Datei Format von Industriemaschinen

		XmlSerializer xml = new XmlSerializer(fahrzeuge.GetType());
		StreamWriter sw = new StreamWriter(filePath);
		xml.Serialize(sw, fahrzeuge);
		sw.Close();

		StreamReader sr = new StreamReader(filePath);
		List<Fahrzeug> readFzg = (List<Fahrzeug>) xml.Deserialize(sr);
		sr.Close();
	}

	public void CSV()
	{

		//Path, File, Directory
		string desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory); //Pfad zum Desktop
		string folderPath = Path.Combine(desktop, "Test");
		string filePath = Path.Combine(folderPath, "Test.txt"); //Diese Pfade sind nur strings, im unterliegenden Dateisystem passiert hier noch nichts

		if (!Directory.Exists(folderPath))
			Directory.CreateDirectory(folderPath);

		List<Fahrzeug> fahrzeuge = new List<Fahrzeug>
		{
			new Fahrzeug(251, FahrzeugMarke.BMW),
			new Fahrzeug(274, FahrzeugMarke.BMW),
			new Fahrzeug(146, FahrzeugMarke.BMW),
			new Fahrzeug(208, FahrzeugMarke.Audi),
			new Fahrzeug(189, FahrzeugMarke.Audi),
			new Fahrzeug(133, FahrzeugMarke.VW),
			new Fahrzeug(253, FahrzeugMarke.VW),
			new Fahrzeug(304, FahrzeugMarke.BMW),
			new Fahrzeug(151, FahrzeugMarke.VW),
			new Fahrzeug(250, FahrzeugMarke.VW),
			new Fahrzeug(217, FahrzeugMarke.Audi),
			new Fahrzeug(125, FahrzeugMarke.Audi)
		};

		//Serialisierung
		//Objekte aus dem Programm heraus bewegen
		//-> In ein Format konvertieren, welches gespeichert/gelesen werden kann

		//CSV: Comma Separated Values
		//Excel Dateien sind CSV, Excel Dateien müssen oft verarbeitet werden

		//CsvHelper: NuGet-Package, nachdem der C# interne CSV Serializer sehr rudimentär ist
		StreamWriter sw = new StreamWriter(filePath);
		CsvWriter writer = new CsvWriter(sw, CultureInfo.CurrentCulture);
		writer.WriteRecords(fahrzeuge);
		sw.Close();

		StreamReader sr = new StreamReader(filePath);
		CsvReader reader = new CsvReader(sr, CultureInfo.CurrentCulture);
		IEnumerable<Fahrzeug> readFzg = reader.GetRecords<Fahrzeug>();
		sr.Close();
	}
}

public class Fahrzeug
{
	public int MaxV { get; set; }

	public FahrzeugMarke Marke { get; set; }

	public Fahrzeug(int maxV, FahrzeugMarke marke)
	{
		MaxV = maxV;
		Marke = marke;
	}

	public Fahrzeug()
	{

	}
}

public enum FahrzeugMarke { Audi, BMW, VW }