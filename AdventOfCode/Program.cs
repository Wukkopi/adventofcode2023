﻿using AdventOfCode;
using System;

public class Program
{
	static void Main(string[] args)
	{
		var day1Solution = Day1.getCalibrationValue(File.ReadAllLines("files/Day1.txt"));
		
		Console.WriteLine("---===Advent Of Code 2023===---");
		Console.WriteLine($"Day1 solution = {day1Solution}");
	}
}