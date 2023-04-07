using System;
using System.Collections.Generic;
using Trabalho_IA.Helpers;
using Trabalho_IA.Models;

namespace Trabalho_IA
{
    class Program
    {
        static void Main(string[] args)
        {
            Jug jug1 = new Jug(8, 8);
            Jug jug2 = new Jug(5, 0);
            Jug jug3 = new Jug(3, 0);

            Node root = new Node(jug1, jug2, jug3, 0);
         
            var currentNode = root;

            var transitions = new Transitions
            {
                AppliedRules = new List<Node>
                {
                    root
                }
            };

            while (!transitions.IsProblemSolved(currentNode))
            {
                Console.WriteLine($"Nó atualll: {Helper.PrintNode(currentNode)}");

                var commitPrimeiraBranchSaindoDaMaster = 0;

                var commitSegundaBranchSaindoDaMaster = 1;

                var avaialbieTransitions = transitions.AvailableTransitions(currentNode);

                currentNode = transitions.ChooseBestNode(avaialbieTransitions);
            }

            Console.WriteLine($"Problema finalizado, nó atual: {Helper.PrintNode(currentNode)}");
        }
    }
}
