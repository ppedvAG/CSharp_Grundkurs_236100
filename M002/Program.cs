#region Variablen
//Variablen
//Aufbau:
//<Typ> <Name>;
//<Typ> <Name> = <Wert>;
int zahl;
int zahl2 = 5;
Console.WriteLine(zahl2); //cw + Tab -> Console.WriteLine

/*
	Mehrzeilige
	Kommentare
*/

//Typen
//Ganzzahltypen: int, byte, short, long
//Kommazahltypen: double, float, decimal
//Texttypen: string, char
//bool: Wahr-/Falsch Wert

short s = 2398;
long l = 2398;
byte b = 42;

double d = 3257392.3275102;
float f = 390328529.129357120948f; //Mit f am Ende die Konvertierung von Double zu Float erzwingen
decimal m = 3890512304.2359712048m; //Mit m am Ende die Konvertierung von Double zu Decimal erzwingen

string str = "Das ist ein Text"; //String benötigt Doppelte Hochkomma (" ")
char c = 'A'; //Char benötigt Einzelne Hochkomma (' ')

bool wahr = true;
bool falsch = false;
#endregion

#region Strings
//Strings verbinden
//Mit +
string text = "Das ist ein Text " + d;
Console.WriteLine(text);

string kombi = "Das ist eine Kommazahl " + d + ", das ist ein Text: " + str + ", das ist ein byte: " + b; //Anstrengend
Console.WriteLine(kombi);

//String Interpolation ($-String): Mit { } Code in einen String einbauen
string interpolation = $"Das ist eine Kommazahl {d}, das ist ein Text: {str}, das ist ein byte: {b}";
Console.WriteLine(interpolation);

//Escape-Sequenzen: Untippbare Zeichen in einen String einbauen
//https://docs.microsoft.com/en-us/cpp/c-language/escape-sequences?view=msvc-170
string umbruch = "Das ist\nein Text";
Console.WriteLine(umbruch);

string pfad = "C:\\Program Files\\dotnet\\shared\\Microsoft.NETCore.App\\7.0.5\\System.Console.dll";

//Verbatim-String (@-String): String, der Escape Sequenzen ignoriert
string verbatimPfad = @"C:\Program Files\dotnet\shared\Microsoft.NETCore.App\7.0.5\System.Console.dll";
string verbatim = @"Das ist 
ein Text \n\t\\"; //Escape-Sequenzen werden hier nicht interpretiert
Console.WriteLine(verbatim);
#endregion

#region Eingabe
////Mittels ReadLine() können vom Benutzer Eingaben empfangen werden
//string eingabe = Console.ReadLine(); //Hier bleibt das Programm stehen, bis eine Eingabe vom Benutzer kommt
//Console.WriteLine($"Du hast {eingabe} eingegeben");

//ConsoleKeyInfo info = Console.ReadKey(); //Verlangt genau eine Eingabe vom Benutzer
//Console.WriteLine(info.Key); //In dem ConsoleKeyInfo Objekt befinden sich 3 Informationen: der Key, der Char hinter dem Key und die Modifier (Strg, Alt, Shift)
#endregion

#region Konvertierungen
//Typ -> String
//String -> Typ
//Typ -> Typ

//Typ -> String
int x = 347;
x.ToString();

//String -> Typ
string z = "123";
//Console.WriteLine($"z * 2 = {z * 2}"); //Inkompatibel, da z ein Text ist

//Parse Funktionen
int parseZahl = int.Parse(z);
Console.WriteLine($"z * 2 = {parseZahl * 2}");

//Typ -> Typ
double kommazahl = 235.3295872;
//int ganzeZahl = kommazahl; //Inkompatibel, da eine Kommazahl Dezimalstellen hat, und eine Ganze Zahl nicht

//Typecast (Cast, Casting)
//Konvertierung von einem Typen zu einem anderen (ohne string)
int ganzeZahl = (int) kommazahl; //Explizite Konvertierung: In Klammern ( ) den Typen angeben, der heraus kommen soll
double k = ganzeZahl; //Implizite Konvertierung, da alle ints immer in double passen
short a = (short) ganzeZahl; //Hier muss die Umwandlung auch erzwungen werden
#endregion

#region Arithmetik
int z1 = 4;
int z2 = 8;

//Unterschied zwischen + und +=
//z1 + z2; Berechnet die Summe
//z1 += z2; Berechnet die Summe, und schreibt das Ergebnis in z1

z1 += z2; //Verändert z1 und z2 
Console.WriteLine(z1 + z2); //Verändert z1 und z2 NICHT

//Modulo: Rest einer Division
Console.WriteLine(z2 % z1); // 8 / 4 = 2, 0R -> 0
Console.WriteLine(8 % 5); //8 / 5 = 1, 3R -> 3
Console.WriteLine(z2 % 2); //Prüfen, ob eine Zahl gerade/ungerade ist
Console.WriteLine(528 % 10); //Letzte Zahl einer Zahl zurückgeben

z1++; //Erhöhe z1 um 1 (Verändert z1)
z1--;

Math.Floor(4.5); //Abrunden
Math.Ceiling(4.5); //Aufrunden
Math.Round(4.5); //Hier wird zum nächsten geraden Wert geraden gerundet (4)
Math.Round(5.5); //Hier wird zum nächsten geraden Wert geraden gerundet (6)
double gerundet = Math.Round(524.53158712390, 2); //Runde auf X Kommastellen (hier 2)
Console.WriteLine(gerundet);

Console.WriteLine(8 / 5); //1, weil Int-Division, da beide Zahlen ints sind
Console.WriteLine(8 / 5.0); //1.6, double Division durch Konvertierung einer Zahl erzwingen
Console.WriteLine(8 / 5d);
Console.WriteLine((double) z1 / z2);
#endregion