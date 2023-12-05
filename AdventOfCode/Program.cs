using AdventOfCode;
using System;

public class Program
{
	static void Main(string[] args)
	{
		var day1Solution = Day1.Part1(File.ReadAllLines("files/Day1.txt"));
		var day2Solution = Day2.Part1(File.ReadAllLines("files/Day2.txt"));
		
		Console.WriteLine("---===Advent Of Code 2023===---");
		Console.WriteLine($"Day1 solution = {day1Solution}");
		Console.WriteLine($"Day2 solution = {day2Solution}");
	}
}
