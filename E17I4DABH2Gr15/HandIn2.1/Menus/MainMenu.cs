using System;

namespace HandIn2._1
{
	public class MainMenu
	{
		public static void Show()
		{
		Console.Clear();
		MenuTextFormatter.CenteredHeader("Welcome to your digital rolodex!");
		Console.WriteLine();
		MenuTextFormatter.MenuItem("1", "Show contacts alphabetically.");
		MenuTextFormatter.MenuItem("2", "Search to modify, delete or show contacts information.");
		MenuTextFormatter.MenuItem("3", "Add contacts.");
		MenuTextFormatter.MenuItem("9", "Exit.");
		}
	}
}