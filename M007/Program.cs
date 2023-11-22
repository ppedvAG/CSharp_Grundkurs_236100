namespace M007;

internal class Program
{
	static void Main(string[] args)
	{
		#region GC
		for (int i = 0; i < 5; i++)
		{
			Person p = new Person(); //Hier werden 5 Personen Objekte angelegt, von denen 4 im RAM vergessen werden
		}
		
		GC.Collect();
		GC.WaitForPendingFinalizers();
        #endregion

        #region Static
        //Static: "Global", ein static Member kann über den Klassennamen ohne Objekt aufgerufen werden
        Console.WriteLine(); //Console gibt es nur einmal -> global
		//Console c = new Console(); //Nicht möglich, da static

		//Person.Sprechen(""); //Diese Methode kann nur mit einem Objekt ausgeführt werden
		Person p2 = new Person();
		p2.Sprechen("");

		Console.WriteLine(DateTime.Now);

		Console.WriteLine(Person.PersonenCounter); //Global ansprechbar, da static
		#endregion

		#region Datumswerte
		DateTime date = new DateTime(2023, 11, 22); //Datum erstellen
		DateTime gebDat = new DateTime(1998, 07, 18);

        //Was ist der Unterschied zwischen diesen beiden Datumswerten?
        Console.WriteLine(date - gebDat); //9258 Tage
		Console.WriteLine(date >= gebDat); //Welches Datum ist das neuere?

		TimeSpan span = TimeSpan.FromMinutes(20);
        Console.WriteLine(span * 31); //Datumswerte multiplizieren

		DateTime freigabe = DateTime.Now + TimeSpan.FromSeconds(30);
        Console.WriteLine(freigabe);

        Console.WriteLine(DateTime.Now - TimeSpan.FromDays(365 * 5));
		#endregion

		#region Werte- und Referenztypen
		//class und struct

		//Referenztyp
		//class
		//Bei Zuweisung wird ein Objekt referenziert
		//Bei Vergleichen werden die Speicheradressen verglichen
		Person person = new Person(); //Hier wird ein Objekt im RAM angelegt, und person enthält einen Zeiger auf dieses Objekt
		Person p3 = person; //Hier wird in p3 ein Zeiger abgelegt auf das Objekt hinter person
		person.Alter = 20; //Hier wird bei dem Unterliegenden Objekt von person das Alter geändert, und dadurch auch bei p3

        Console.WriteLine(person.GetHashCode());
        Console.WriteLine(p3.GetHashCode()); //Hier kommt 2 mal derselbe HashCode heraus -> Die Objekte sind gleich

        Console.WriteLine(person == p3);
		//Console.WriteLine(person.GetHashCode() == p3.GetHashCode()); //Selbiges wie oben

		//Wertetyp
		//struct
		//Bei Zuweisung wird der Inhalt kopiert
		//Bei Vergleichen werden die Inhalte verglichen
		int original = 5;
		int x = original; //Hier wird der Wert aus original kopiert
		original = 10; //Unterschiedliche Werte

        Console.WriteLine(original == x); //Hier werden die Inhalte verglichen
		#endregion

		#region Null
		Person p4; //Standardwert null
		Person p5 = null;

		//p5.Sprechen("abc"); //p5 was null

		if (p5 != null) //Null-Check
			p5.Sprechen("abc");

		p5?.Sprechen("abc");

		if (p5 is not null)
			p5.Sprechen("abc");

		//int x = null; //structs sind nicht nullable
		int? y = null; //Typ nullable machen mit ? am Ende
		#endregion
	}

	static void Test(Person p) //Hier wird eine Referenz auf das Objekt unter p übergeben
	{
		p.Alter = 30;
	}

	static void Test(int x) //Hier wird der Inhalt des gegebenen Wertes in die Funktion hereinkopiert
	{
		x = 30;
	}
}