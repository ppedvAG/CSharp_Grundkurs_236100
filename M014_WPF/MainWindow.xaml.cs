using System;
using System.Windows;

namespace M014_WPF;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();
	}

	private void Comp_ProcessStarted(object? sender, EventArgs e)
	{
		TB.Text += $"{DateTime.Now}: Prozess gestartet\n";
	}

	private void Comp_ProcessEnded(object? sender, EventArgs e)
	{
		TB.Text += $"{DateTime.Now}: Prozess beendet\n";
	}

	private void Comp_Progress(object? sender, int e)
	{
		TB.Text += $"Fortschritt: {e}\n";
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		Component comp = new Component();
		comp.ProcessStarted += Comp_ProcessStarted;
		comp.ProcessEnded += Comp_ProcessEnded;
		comp.Progress += Comp_Progress;
		comp.DoWork();
	}

	private void TB_SizeChanged(object sender, SizeChangedEventArgs e)
	{
		SV.ScrollToBottom();
	}
}
