using AdventOfCode.Solutions;

public class Program
{
	static void Main(string[] args)
	{
		//var day1 = new Day1(File.ReadAllLines("files/Day1.txt"));
		//var day2 = new Day2(File.ReadAllLines("files/Day2.txt"));
		//var day3 = new Day3(File.ReadAllLines("files/Day3.txt"));
		//var day4 = new Day4(File.ReadAllLines("files/Day4.txt"));
		var day5 = new Day5(File.ReadAllLines("files/Day5.txt"));
		
		Console.WriteLine("---===Advent Of Code 2023===---");
		//Console.WriteLine($"Day1 solutions = {day1.Part1} & {day1.Part2}");
		//Console.WriteLine($"Day2 solutions = {day2.Part1} & {day2.Part2}");
		//Console.WriteLine($"Day3 solutions = {day3.Part1} & {day3.Part2}");
		//Console.WriteLine($"Day4 solutions = {day4.Part1} & {day4.Part2}");
		Console.WriteLine($"Day5 solutions = {day5.Part1} & {day5.Part2}");
	}
}
