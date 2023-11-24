using System;
using System.Threading.Tasks;

namespace M014_WPF;

/// <summary>
/// Component: Beispielsklasse zum Simulieren von einer länger andauernden Arbeit
/// Über Events soll der Status von der Arbeit zurückgegeben werden
/// </summary>
public class Component
{
	public event EventHandler ProcessStarted;

	public event EventHandler ProcessEnded;

	public event EventHandler<int> Progress;

	public async void DoWork()
	{
		ProcessStarted(this, EventArgs.Empty);
		for (int i = 0; i < 100; i++)
		{
			await Task.Delay(200);
            //Console.WriteLine($"Fortschritt: {i}"); //Problem: UI hat keine Konsole
			Progress(this, i);
		}
		ProcessEnded(this, EventArgs.Empty);
	}
}
