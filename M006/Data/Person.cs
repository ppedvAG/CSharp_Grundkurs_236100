namespace M006.Data;

/// <summary>
/// Rechtsklick auf Projekt -> Add -> Class -> Name eingeben -> OK
/// Klasse:
/// Bauplan, gefüllt mit Variablen/Properties/Methoden/... -> Member
/// Aus dem Bauplan können beliebig viele Objekte erzeugt werden, die alle jeweils die Struktur die im Bauplan festgelegt ist haben
/// </summary>
public class Person
{
    //Eigenschaften: Körpergröße, Vorname, Nachname, Alter, Rückenbehaarung
    //Funktionen: Laufen, Schlafen, Speisen, Sprechen

    #region Variable
    private string vorname;

    public string GetVorname()
    {
        return vorname;
    }

    /// <summary>
    /// Get-/Set Methoden ermöglichen sichereren Zugriff auf bestimmte Felder
    /// -> In vorname (string) kann alles geschrieben werden, aber Zahlen im Vornamen machen keinen Sinn
    /// SetVorname kann Beschränkungen enthalten
    /// </summary>
    /// <param name="neuerVorname"></param>
    public void SetVorname(string neuerVorname)
    {
        //Hier kann jetzt eine Fehlerbehandlung gemacht werden
        if (neuerVorname.Length >= 3 && neuerVorname.Length <= 15 && neuerVorname.All(char.IsLetter))
            vorname = neuerVorname;
        else
            Console.WriteLine("Neuer Vorname ist nicht valide");
    }
    #endregion

    #region Properties
    private string nachname;

    /// <summary>
    /// Properties:
    /// Vereinfachung von Get-/Set Methoden
    /// Haben bis zu einen Get- und einen Set-Accessor die die Get- und Set Methoden von Vorname reflektieren
    /// Können beschrieben/gelesen werden wie eine normale Variable
    /// </summary>
    public string Nachname
    {
        get
        {
            return nachname;
        }
        set
        {
            //Das value Keyword gibt hier den Parameter vor
            //neuerVorname -> value
            if (value.Length >= 3 && value.Length <= 15 && value.All(char.IsLetter))
                nachname = value;
            else
                Console.WriteLine("Neuer Nachname ist nicht valide");
        }
    }

    //3 verschiedene Formen von Properties

    //Full Property: privates Feld und public Property, welches auf das private Feld zugreift
    //Snippet: propfull

    //Auto Property: Öffentliches Feld mit { get; set; }
    //Generiert im Hintergrund ein private Feld + Get-/Set Methoden
    //Snippet: prop
    public int Alter { get; set; }

    public int Gehalt { get; private set; }

    //Get-only Property: Property, ohne Setter ( { get; } )
    //Beispiel: Kombination von Vorname und Nachname
    public string VollerName
    {
        get
        {
            return $"{vorname} {nachname}";
        }
        //set macht hier keinen Sinn, weil VollerName sich aus Vorname und Nachname zusammensetzt
    }

    public string VollerName2
    {
        get => $"{vorname} {nachname}"; //Expression Body (=>): Einzeilige Statements in eine Zeile schreiben (ohne Klammern)
    }

    public string VollerName3 => $"{vorname} {nachname}";
    #endregion

    #region Funktionen
    public void Sprechen(string text)
    {
        Console.WriteLine($"{VollerName} sagt: {text}");
    }

    /// <summary>
    /// Hier eine Funktion mit einem Enum Parameter
    /// </summary>
    public void Laufen(Direction richtung)
    {

    }
    #endregion

    #region Konstruktor
    public Person()
    {
        Console.WriteLine("Person erstellt");
    }

    /// <summary>
    /// Konstruktor:
    /// Initialcode, der bei Erstellung des Objektes ausgeführt wird (bei new)
    /// Hier werden beliebige Parameter verlangt, die die Standardwerte des Objekts darstellen
    /// Standardmäßig wird ein leerer Konstruktor (public Person() { }) erstellt, damit Objekt direkt erstellt werden können
    /// Wenn ein eigener Konstruktor definiert wird, wird der Standardkonstruktor entfernt
    /// </summary>
    public Person(string vorname, string nachname) : this()
    {
        //this: Greife innerhalb der Klasse nach oben
        //Hier gibt es ein Feld namens vorname (der Parameter)
        //In der Klasse gibt es auch ein Feld namens vorname (private string vorname)
        //Mit this kann angegeben werden, ob das Feld hier drinnen oder in der Klasse gemeint ist
        //this bezieht sich auf das Objekt, dass gerade erstellt wird
        this.vorname = vorname;
        this.nachname = nachname;
    }

    /// <summary>
    /// this am Ende vom Konstruktor stellt eine Verkettung dar, damit der Code im oberen Konstruktor nicht herunterkopiert werden muss
    /// Wenn dieser Konstruktor ausgeführt wird, wird der obere Konstruktor auch ausgeführt
    /// </summary>
    public Person(string vorname, string nachname, int alter) : this(vorname, nachname)
    {
        Alter = alter;
    }
    #endregion
}