namespace M006.Data;

public class Kurs
{
    //Anforderungen:
    //Name, Datum, Dauer (Properties)
    //Trainer als separate Variable (einzelnes Property)
    //Beliebige Anzahl an Personen halten (Array von Personen)
    //Funktion, die neue Teilnehmer hinzufügen kann (void, Parameter Person)
    //Konstruktor mit allen Properties außer Trainer

    public string Kursname { get; set; }

    public int Tage { get; set; }

    public DateTime StartDatum { get; set; }

    public DateTime EndDatum { get; set; }

    public Person Trainer { get; set; }

    public Person[] Teilnehmer { get; set; }

    public void TeilnehmerHinzufuegen(Person p)
    {
        Teilnehmer = Teilnehmer.Append(p).ToArray();
    }

    public void TeilnehmerHinzufuegen(params Person[] p)
    {
        Teilnehmer = Teilnehmer.Concat(p).ToArray();
    }

    public Kurs(string kursname, int tage, DateTime startDatum, DateTime endDatum, params Person[] teilnehmer)
    {
        Kursname = kursname;
        Tage = tage;
        StartDatum = startDatum;
        EndDatum = endDatum;
        Teilnehmer = teilnehmer;
    }
}
