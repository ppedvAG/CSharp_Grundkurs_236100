while (true)
{
	double zahl1 = ZahlEingabe("Gib die erste Zahl ein: ");
	double zahl2 = ZahlEingabe("Gib die zweite Zahl ein: ");

	foreach (Operation operation in Enum.GetValues<Operation>())
		Console.WriteLine($"{(int) operation}: {operation}");

	Operation op = RechenoperationEingabe();

	double ergebnis = Berechne(zahl1, zahl2, op);

    Console.WriteLine("Enter drücken zum Wiederholen");
	if (Console.ReadKey(true).Key != ConsoleKey.Enter)
		break;
	Console.Clear();
}

double Berechne(double zahl1, double zahl2, Operation op)
{
	switch (op)
	{
		case Operation.Addition:
			Console.WriteLine($"{zahl1} + {zahl2} = {zahl1 + zahl2}");
			return zahl1 + zahl2;
		case Operation.Subtraktion:
			Console.WriteLine($"{zahl1} - {zahl2} = {zahl1 - zahl2}");
			return zahl1 - zahl2;
		case Operation.Multiplikation:
			Console.WriteLine($"{zahl1} * {zahl2} = {zahl1 * zahl2}");
			return zahl1 * zahl2;
		case Operation.Division:
			if (zahl2 != 0)
			{
				Console.WriteLine($"{zahl1} / {zahl2} = {zahl1 / zahl2}");
				return zahl1 / zahl2;
			}
			else
			{
				Console.WriteLine("Teilung durch 0 ist nicht möglich!");
				return double.NaN;
			}
		default:
			Console.WriteLine("Fehler");
			return double.NaN;
	}
}

double ZahlEingabe(string text)
{
	double result;
	bool funktioniert;
	while (true)
	{
        Console.WriteLine(text);
		funktioniert = double.TryParse(Console.ReadLine(), out result);
		if (funktioniert)
			return result;
	}
}

Operation RechenoperationEingabe()
{
	double eingabe = ZahlEingabe("Gib eine Rechenoperation ein: ");
	return (Operation) eingabe;
}

enum Operation
{
	Addition = 1, Subtraktion, Multiplikation, Division
}