using M017.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M017;

public partial class MainWindow : Window
{
	public MainWindow()
	{
		InitializeComponent();

		//List<Person> personen = new();
		//for (int i = 0; i < 20; i++)
		//	personen.Add(new Person(GenString(), GenString(), Random.Shared.Next(20, 100), GenString()));
		//DG.ItemsSource = personen;

		#region Basic Connection
		//Datenbank angreifen
		//2 Möglichkeiten
		//Basic SQL Connection
		//EntityFramework

		//using SqlConnection conn = new SqlConnection("Server=WIN10-LK3;Database=Northwind;Trusted_Connection=True;");
		//conn.Open(); //try-catch falls die Verbindung nicht funktioniert

		//using SqlCommand command = conn.CreateCommand();
		//command.CommandText = "SELECT * FROM Customers";

		//using SqlDataReader reader = command.ExecuteReader();
		//List<Customer> rows = new();
		//while (reader.Read())
		//{
		//	object[] values = new object[reader.VisibleFieldCount];
		//	reader.GetValues(values); //values ist ein Referenztyp -> Referenz auf das Array
		//	rows.Add(new Customer(values));
		//}
		//DG.ItemsSource = rows;
		#endregion

		#region EF
		//EF
		//NuGet: Microsoft.EntityFrameworkCore installieren
		//NuGet: Microsoft.EntityFrameworkCore.<DBServer> installieren
		//Extensions -> EF Core Power Tools
		//Server Explorer -> DB Verbindung hinzufügen

		//Rechtsklick aufs Projekt -> EF Core Power Tools -> Reverse Engineer
		//Datenbank auswählen -> Tabellen auswählen -> Context erzeugen + Model Klassen (am besten in einem eigenen Ordner)

		NorthwindContext context = new NorthwindContext();
		//DG.ItemsSource = context.Customers; //context.Customers ist ein IEnumerable -> Anleitung
		DG.ItemsSource = context.Customers.ToList(); //ToList holt tatsächlich die Daten
		DG.ItemsSource = context.Customers.Where(e => e.Country == "Germany").ToList(); //Linq Where wird hier zu SQL Where übersetzt -> SELECT * FROM Customers WHERE Country = 'Germany'
		#endregion
	}

	public string GenString() => new string(new int[Random.Shared.Next(5, 15)].Select(e => (char) Random.Shared.Next(65, 65 + 26)).ToArray());
}

public record Person(string Vorname, string Nachname, int Alter, string Adresse);

//public class Customer
//{
//	public string ID { get; set; }
//	public string Name { get; set; }
//	public string ContactName { get; set; }
//	public string Role { get; set; }
//	public string Street { get; set; }
//	public string City { get; set; }
//	public string PostalCode { get; set; }
//	public string Country { get; set; }
//	public string Phone { get; set; }
//	public string Fax { get; set; }

//	public Customer(object[] values)
//	{
//		ID = values[0].ToString();
//		Name = values[1].ToString();
//		ContactName = values[2].ToString();
//		Role = values[3].ToString();
//		Street = values[4].ToString();
//		City = values[5].ToString();
//		PostalCode = values[7].ToString();
//		Country = values[8].ToString();
//		Phone = values[9].ToString();
//		Fax = values[10].ToString();
//	}
//}