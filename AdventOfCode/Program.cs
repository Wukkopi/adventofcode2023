using AdventOfCode;
using System;

public class Program
{
	static void Main(string[] args)
	{
		var day1 = new Day1(File.ReadAllLines("files/Day1.txt"));
		var day2 = new Day2(File.ReadAllLines("files/Day2.txt"));
		var day3 = new Day3(File.ReadAllLines("files/Day3.txt"));
		
		Console.WriteLine("---===Advent Of Code 2023===---");
		Console.WriteLine($"Day1 solutions = {day1.Part1} & {day1.Part2}");
		Console.WriteLine($"Day2 solutions = {day2.Part1} & {day2.Part2}");
		Console.WriteLine($"Day3 solutions = {day3.Part1} & {day3.Part2}");
	}
}
