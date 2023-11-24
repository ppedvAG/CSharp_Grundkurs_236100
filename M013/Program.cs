namespace M013;

internal class Program
{
	static void Main(string[] args)
	{
		//Debugging
		//1. Breakpoint setzen (Ganz links in VS klicken)
		//2. Programm starten
		Console.WriteLine(); //Gelb hinterlegt: Wird als nächstes ausgeführt

		//3 Pfeile:
		//Step Over: Führt das derzeitige Statement aus, ohne in den Code der unterliegenden Methode hineinzugehen
		//Step Into: Springt eine Ebene im Code nach unten -> In den Code der Methode selbst
		//Step Out: Springt aus der Methode heraus nach einem Step Into
		//Continue: Führt den Code weiter aus, bis zum nächsten Breakpoint

		//GUI Elemente beim Debugging
		//Debug -> Windows -> <Fenster> (Diesen Menüpunkt gibt es nur während dem Debugging)
		//Locals: Zeigt alle Variablen und Werte
		//Immediate Window: Code ausführen, der nicht im Code festgelegt ist


		//Fehlerbehandlung mittels try-catch
		try //Snippet -> Surround With -> try
		{
			string eingabe = Console.ReadLine(); //Maus über die Methode -> Exceptions
			int x = int.Parse(eingabe); //2 Mögliche Fehler: Keine Zahl, Zu kleine/große Zahl

			if (x == 0)
				throw new TestException("Zahl darf nicht 0 sein"); //Hier eine Exception werfen mit dem throw Keyword
		}
		catch (FormatException) //Spezifische Fehlerbehandlung für keine Zahl
		{
			Console.WriteLine("Keine Zahl eingegeben"); //Code wird ausgeführt, wenn der User keine Zahl eingibt
		}
		catch (OverflowException)
		{
			Console.WriteLine("Zahl zu klein/groß");
		}
		//catch (TestException e)
		//{
		//		Console.WriteLine(e.Status);
		//}
		catch (Exception e) //Hier werden alle anderen Exceptions gefangen
		{
			//Exceptions können auch einen Namen bekommen, um in diese hereinzuschauen
			Console.WriteLine("Anderer Fehler"); //Hier kommen wir nur hinein, wenn ein Fehler auftritt, der vorher nicht behandelt wurde
			Console.WriteLine(e.Message); //Die C# Interne Nachricht
			Console.WriteLine(e.StackTrace); //Eine Nachverfolgung, wo der Fehler aufgetreten ist (sollte von unten nach oben gelesen werden)
		}
		finally //Wird immer ausgeführt
		{
			Console.WriteLine("Parsen fertig");
		}

		//Alle Exception loggen
		//Hier kann beliebiger Code ausgeführt werden, falls eine Exception das Programm zum Absturz bringt
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
		//Diese Zeile Code sollte am Anfang des Programms ausgeführt werden, um das Logging zu registrieren
		//throw new Exception("Test");
	}

	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
	{
		//Hier ein Log schreiben
		Exception ex = e.ExceptionObject as Exception;
		File.WriteAllText("Log.txt", $"{ex.Message}\n{ex.StackTrace}");
	}

	static void Test()
	{
		Console.WriteLine();
	}
}

public class TestException : Exception
{
	public string Status { get; set; }

	public TestException(string? message) : base(message)
	{

	}
}