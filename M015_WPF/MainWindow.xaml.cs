using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace M015_WPF;

public partial class MainWindow : Window
{
	private int Counter;

	public MainWindow()
	{
		//Toolbox und Properties
		//View -> Toolbox (Mittig)
		//View -> Properties (vorletzter Eintrag)
		InitializeComponent();

		//CB.ItemsSource = new List<string>() { "Item1", "Item2", "Item3" };
		//CB.ItemsSource = Enum.GetValues<DayOfWeek>().OrderBy(e => e.ToString());
		CB.ItemsSource = Enum.GetValues<DayOfWeek>();
		LB.ItemsSource = Enumerable.Range(0, 10).Select(e => $"Zahl: {e}");
	}

	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//Zählervariable um 1 erhöhen und in der UI anzeigen
		Counter++;
		TB.Text = $"Zähler: {Counter}";

		MessageBoxResult result = MessageBox.Show("Der Text der MessageBox", "Eine Nachricht", MessageBoxButton.YesNo, MessageBoxImage.Question);
		if (result == MessageBoxResult.Yes) //Hier auf das korrekte Result achten
		{
			Close();
		}
	}

	private void CB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = CB.SelectedItem.ToString();
	}

	private void LB_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		TB.Text = string.Join(", ", LB.SelectedItems.OfType<string>());
	}

	private void CheckBox_Checked(object sender, RoutedEventArgs e)
	{
		//Jetzt wird standardmäßig das Event gefeurt, wenn in der UI die CheckBox auf true gesetzt wird
		//IsInitialized ist erst true, wenn die UI komplett fertig erzeugt wurde
		if (this.IsInitialized) 
		{
			CheckBox check = (CheckBox) sender;
			TB.Text = check.Content.ToString() + " checked";
		}
	}

	private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
	{
		if (!this.IsInitialized) return;

		CheckBox check = (CheckBox) sender;
		TB.Text = check.Content.ToString() + " unchecked";
	}
}
