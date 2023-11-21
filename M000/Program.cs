while (true)
{
	Console.Write("Gib die erste Zahl ein: ");
	double zahl1 = double.Parse(Console.ReadLine());

	Console.Write("Gib die zweite Zahl ein: ");
	double zahl2 = double.Parse(Console.ReadLine());

	foreach (Operation operation in Enum.GetValues<Operation>())
	{
		Console.WriteLine($"{(int) operation}: {operation}");
	}

	Console.Write("Gib eine Rechenoperation ein: ");
	Operation op = Enum.Parse<Operation>(Console.ReadLine());

	switch (op)
	{
		case Operation.Addition:
			Console.WriteLine($"Ergebnis: {zahl1 + zahl2}");
			break;
		case Operation.Subtraktion:
			Console.WriteLine($"Ergebnis: {zahl1 - zahl2}");
			break;
		case Operation.Multiplikation:
			Console.WriteLine($"Ergebnis: {zahl1 * zahl2}");
			break;
		case Operation.Division:
			if (zahl2 != 0)
				Console.WriteLine($"Ergebnis: {zahl1 / zahl2}");
			else
				Console.WriteLine("Teilung durch 0 ist nicht möglich!");
			break;
		default:
			Console.WriteLine("Fehler");
			break;
	}

    Console.WriteLine("Enter drücken zum Wiederholen");
	if (Console.ReadKey(true).Key != ConsoleKey.Enter)
		break;
	Console.Clear();
}


enum Operation
{
	Addition = 1, Subtraktion, Multiplikation, Division
}