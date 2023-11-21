using System.Net;

#region Schleifen
int a = 0;
int b = 10;
while (a < b) //Läuft solange die Bedingung true ist, solange a kleiner als 10 ist
{
    Console.WriteLine($"while: {a}");
	a++;
}

//a = 0;
do //do-while: Selbiges wie while, wird aber mindestens einmal ausgeführt (egal ob die Bedingung von Anfang an true oder false ist)
{
    Console.WriteLine($"do-while: {a}");
	a++;
}
while (a < b);

//while (true) { Console.WriteLine("Endlos"); } //Endlosschleife

//break und continue
//Ermöglichen das Steuern von Schleifen
//Werden häufig mit einer if kombiniert
//break: Beendet die Schleife
//continue: Springe zum Schleifenkopf zurück -> Überspringe den Code danach

a = 0;
while (true)
{
    Console.WriteLine($"while true: {a}");
	a++;
	if (a >= b)
	{
        //Console.WriteLine("Schleife beendet");
        break; //Beendet hier die Schleife (springe in die Zeile 37)
	}
} //Selbiges wie do-while, aber mit mehr Anpassungsmöglichkeiten
Console.WriteLine();

a = 0;
while (a < 10)
{
	a++;
	if (a % 2 == 0)
		continue; //Führe hier den Code danach nicht aus
	Console.WriteLine($"while-true: {a}");
}

//Snippet: for + Tab
for (int i = 0; i < 10; i++) //Funktioniert wie die while-Schleife, hat aber einen Zähler integriert
{
    Console.WriteLine($"for: {i}");
}

//Snippet: forr + Tab
for (int i = 10 - 1; i >= 0; i--)
{
    Console.WriteLine($"forr: {i}");
}

//Die for-Schleife ist sehr gut anpassbar
//Alle Zahlen in Form von 2^X ausgeben
//2^0=1
//2^1=2
//2^2=4
//...
for (int i = 1, counter = 0; counter < 31; i *= 2, counter++)
{
    Console.WriteLine($"2^{counter}={i}");
}

//for vs. foreach
int[] zahlen = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
//Alle Zahlen in dem Array ausgeben
for (int i = 0; i < zahlen.Length; i++)
{
	Console.WriteLine(zahlen[i]);
	//Console.WriteLine(zahlen[i + 1]); //IndexOutOfRangeException, weil der Index außerhalb des Arrays liegt
}

//Snippet: foreach + Tab
foreach (int i in zahlen) //Die Foreach Schleife greift auf die Elemente direkt zu, anstatt per Index darauf zu greifen
{
    Console.WriteLine(i);
}
#endregion

#region Enums
//Enum: Eigener Datentyp, befüllt mit fixen Zuständen
//Verwendung: Variablen, Parameter, Rückgabetypen mit dem gegebenen Enumtyp definieren, damit nur bestimmte Werte dort vorkommen können

//Variable, die Wochentage speichern kann
string tag = "Montag";
tag = "Januar"; //Passt nicht
tag = "C# Kurs"; //String kann alles halten

Wochentag wochentag = Wochentag.Mo;
//wochentag = Wochentag.Januar; //Dieser Zustand existiert nicht

//Beispiel für fixe Zustände: Http Status Codes
HttpStatusCode code = HttpStatusCode.OK;
code = HttpStatusCode.NotFound;

Wochentag[] tage = Enum.GetValues<Wochentag>();
//Per Hand:
//Wochentag[] tage2 = { Wochentag.Mo, Wochentag.Di, Wochentag.Mi, Wochentag.Do, Wochentag.Fr, Wochentag.Sa, Wochentag.So };

Wochentag parseTag = Enum.Parse<Wochentag>("Mo");

//Zahl zu Enumwert konvertieren
//Jeder Enumwert hat immer eine Zahl dahinter
int x = 0;
Wochentag castTag = (Wochentag) x;
#endregion

#region Switch
//Switch: Nimmt einen Wert als Parameter, prüft den Wert des Parameters und führt dementsprechend Code aus
//Ähnlich wie ein if/else if/else Konstrukt
int z = 4;
switch (z) //Hier muss der Wert angegeben werden, der geprüft werden soll
{
	case 0: //Effektiv eine if
        Console.WriteLine("z ist 0");
		break; //Am Ende von jedem Case muss ein break existieren
	case 1:
        Console.WriteLine("z ist 1");
        Console.WriteLine();
		break;
	case 2:
        Console.WriteLine("z ist 2");
		break;
	default: //Effektiv eine else
		Console.WriteLine("z hat einen anderen Wert");
		break;
}

//Wenn Mo bis Fr -> Wochentag, Sa oder So -> Wochenende
switch (wochentag)
{
	case Wochentag.Mo: //Cases kombinieren
	case Wochentag.Di:
	case Wochentag.Mi:
	case Wochentag.Do:
	case Wochentag.Fr:
        Console.WriteLine("Wochentag");
        break;
	case Wochentag.Sa:
	case Wochentag.So:
        Console.WriteLine("Wochenende");
        break;
	default:
        Console.WriteLine("Fehler");
        break;
}

//Boolescher Switch
switch (wochentag)
{
	case >= Wochentag.Mo and <= Wochentag.Fr:
        Console.WriteLine("Wochentag");
		break;
	case Wochentag.Sa or Wochentag.So:
        Console.WriteLine("Wochenende");
		break;
	default:
        Console.WriteLine("Fehler");
		break;
}
#endregion

enum Wochentag
{
	Mo = 1, Di, Mi, Do, Fr, Sa, So
}