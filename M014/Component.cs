namespace M014;

/// <summary>
/// Component: Beispielsklasse zum Simulieren von einer länger andauernden Arbeit
/// Über Events soll der Status von der Arbeit zurückgegeben werden
/// </summary>
public class Component
{
	public event EventHandler ProcessStarted;

	public event EventHandler ProcessEnded;

	public event EventHandler<int> Progress;

	public void DoWork()
	{
		ProcessStarted(this, EventArgs.Empty);
		for (int i = 0; i < 10; i++)
		{
			Thread.Sleep(200);
            //Console.WriteLine($"Fortschritt: {i}"); //Problem: UI hat keine Konsole
			Progress(this, i);
		}
		ProcessEnded(this, EventArgs.Empty);
	}
}
