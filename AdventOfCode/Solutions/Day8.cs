﻿using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;
using System.Text.RegularExpressions;

namespace AdventOfCode.Solutions
{
    public class Day8 : Day<long>
    {
        private class Node
        {
            public Node? Left { get; private set; }
            public Node? Right { get; private set; }

            public bool IsExit { get; set; } = false;

            public string Name { get; private set; }

            public Node(string name)
            {
                Name = name;
            }
            public void Init(Node left, Node right)
            {
                Left = left;
                Right = right;
            }
        }

        public Day8(string[] input) : base(input)
        {
        }

        protected override long SolvePart1()
        {
            var graph = parseNodes(out var instructions);

            var currentNode = graph["AAA"];
            var steps = 0;
            while (currentNode != graph["ZZZ"])
            {
                currentNode = instructions[steps++ % instructions.Length] == 'L' ? currentNode.Left : currentNode.Right;
            }
            return steps;

        }

        protected override long SolvePart2()
        {
            var graph = parseNodes(out var instructions);

            var ghostNodes = new List<Node>();

            foreach(var n in graph)
            {
                if (n.Value.Name.EndsWith('A'))
                {
                    ghostNodes.Add(n.Value);
                }
                else if (n.Value.Name.EndsWith('Z'))
                {
                    n.Value.IsExit = true;
                }
            }

            var steps = 0L;
            var finished = false;
            var instructionPoint = 0;
            try
            {
                do
                {
                    if (steps % 100000 == 0) Console.WriteLine(steps);


                    while (instructionPoint >= instructions.Length) instructionPoint -= instructions.Length;

                    //var ghostPickup = 0;
                    //while (!finished || !ghostNodes[0].Name.EndsWith('Z'))
                    //{
                    //    var iPos = (instructionPoint + ghostPickup++) % instructions.Length;
                    //    ghostNodes[0] = instructions[iPos] == 'L' ? ghostNodes[0].Left : ghostNodes[0].Right;
                    //    finished = true;
                    //}
                    //ghostPickup = 0;
                    //while (!finished || !ghostNodes[1].Name.EndsWith('Z'))
                    //{
                    //    var iPos = (instructionPoint + ghostPickup++) % instructions.Length;
                    //    ghostNodes[1] = instructions[iPos] == 'L' ? ghostNodes[1].Left : ghostNodes[1].Right;
                    //    finished = true;
                    //}

                    for (var i = 0; i < ghostNodes.Count; i++)
                    {
                        //for (var j = 0; j < ghostPickup; j++)
                        {
                            var iPos = instructionPoint % instructions.Length;
                            ghostNodes[i] = instructions[iPos] == 'L' ? ghostNodes[i].Left : ghostNodes[i].Right;
                        }
                        if (finished && !ghostNodes[i].IsExit)
                        {
                            finished = false;
                        }
                    }


                    steps++; //= ghostPickup;
                    instructionPoint++;// += ghostPickup;
                } while (!finished);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            return steps;
        }

        private Dictionary<string, Node> parseNodes(out string instructions)
        {
            instructions = input[0];

            var result = new Dictionary<string, Node>();
            for (var i = 2; i < input.Length; i++)
            {
                
                var nodes = Regex.Matches(input[i], @"\w{3}");
                var t = nodes[0].ToString();
                var l = nodes[1].ToString();
                var r = nodes[2].ToString();

                foreach(var name in nodes)
                {
                    result.TryAdd(name.ToString(), new Node(name.ToString()));
                }
                result[t].Init(result[l], result[r]);
            }
            return result;
        }
    }
}