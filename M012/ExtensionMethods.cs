namespace M012;

public static class ExtensionMethods
{
	public static int Quersumme(this int x) //Mit this den Typen bestimmen, auf den sich diese Methode bezieht
	{
		return x.ToString().Sum(e => (int) char.GetNumericValue(e)); //Auf einen String kann auch Linq angewandt werden
	}

	public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> x)
	{
		return x.OrderBy(e => Random.Shared.Next());
	}
}
