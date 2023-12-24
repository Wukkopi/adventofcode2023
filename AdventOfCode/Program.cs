using AdventOfCode.Solutions;

public class Program
{
	static void Main(string[] args)
	{
		var day = new Day10(File.ReadAllLines("files/Day10.txt"));
		
		Console.WriteLine("---===Advent Of Code 2023===---");
		Console.Write($"Solutions = {day.Part1} ");
		Console.WriteLine($"& {day.Part2}");
	}
}
