using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace M014;

public class Program
{
	static void Main(string[] args)
	{
		//Event
		//Statischer Punkt, an den eine Methode angehängt werden kann
		//Symbol: Blitz

		//Zweiseitige Entwicklung: Entwicklerseite, Anwenderseite (unsere Seite)
		//Entwicklerseite: Event wird angelegt und ausgeführt
		//Anwenderseite: Wir hängen eine Methode an, die bei Ausführung des Events ausgeführt wird

		//Beispiel: Button Click, wir müssen festlegen, was passiert wenn der Button geklickt wird
		//Entwicklerseite: Click Event als Variable, ist die Maus innerhalb des Buttons, wird Linksklick gedrückt, sind keine anderen UI Elemente darüber, ...
		//Anwenderseite: Was passiert wenn der Button geklickt wird?

		//Mit += kann eine Methode an ein Event angehängt werden
		//Die Methodenstruktur muss mit der vorgegebenen Struktur des Events zusammenpassen
		AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

		ObservableCollection<string> x = new ObservableCollection<string>();
		x.CollectionChanged += Strings_CollectionChanged; //Hier können wir auf Änderungen innerhalb der Liste reagieren
		x.Add("Hello");
		x.Add("XYZ");
		x.Remove("Hello");

		Component comp = new Component();
		comp.ProcessStarted += Comp_ProcessStarted;
		comp.ProcessEnded += Comp_ProcessEnded;
		comp.Progress += Comp_Progress;
		comp.DoWork();
	}

	private static void Comp_ProcessStarted(object? sender, EventArgs e)
	{
		Console.WriteLine($"{DateTime.Now}: Prozess gestartet");
	}

	private static void Comp_ProcessEnded(object? sender, EventArgs e)
	{
		Console.WriteLine($"{DateTime.Now}: Prozess beendet");
	}

	private static void Comp_Progress(object? sender, int e)
	{
		//Hier kann der User jetzt Frei entscheiden was mit dem Wert passiert
		Console.WriteLine($"Fortschritt: {e}");
		//File.AppendAllText("Log.txt", $"Fortschritt: {e}");
	}

	private static void Strings_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
	{
		switch (e.Action)
		{
			case NotifyCollectionChangedAction.Add:
                Console.WriteLine($"Element wurde hinzugefügt: {e.NewItems[0]}");
                break;
			case NotifyCollectionChangedAction.Remove:
				Console.WriteLine($"Element wurde entfernt: {e.OldItems[0]}");
				break;
			//case NotifyCollectionChangedAction.Replace:
			//	break;
			//case NotifyCollectionChangedAction.Move:
			//	break;
			//case NotifyCollectionChangedAction.Reset:
			//	break;
		}
	}

	/// <summary>
	/// Sender: Wo ist das Event aufgetreten, gibt ein Object zurück
	/// EventArgs: Daten, die beim feuern des Events mitgegeben werden können
	/// </summary>
	private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e) { }
}