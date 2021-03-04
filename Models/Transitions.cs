using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trabalho_IA.Helpers;

namespace Trabalho_IA.Models
{
    public class Transitions
    {
        public List<Node> AppliedRules { get; set; }
        public List<Node> OpenRules { get; set; }

        public Transitions()
        {
            AppliedRules = new List<Node>();
            OpenRules = new List<Node>();
        }

        public List<Node> AvailableTransitions(Node node)
        {
            List<Node> transitions = new List<Node>();

            var jugOne = node.Jugs.ElementAt(0);
            var jugTwo = node.Jugs.ElementAt(1);
            var jugThree = node.Jugs.ElementAt(2);

            if (!jugOne.IsFull())
            {
                if (!node.Jugs.ElementAt(1).IsEmpty())
                {
                    var jug1EmptySpace = node.Jugs.ElementAt(0).EmptySpace;
                    var jug2Current = node.Jugs.ElementAt(1).Current;

                    if (jug1EmptySpace >= jug2Current)
                    {
                        var jug1 = new Jug(node.Jugs.ElementAt(0).Capacity, node.Jugs.ElementAt(0).Current);
                        var jug2 = new Jug(node.Jugs.ElementAt(1).Capacity, node.Jugs.ElementAt(1).Current);

                        jug1.UpdateContent(jug2.Current);
                        jug2.EmptyJug();
                        transitions.Add(new Node(jug1, jug2, node.Jugs.ElementAt(2), node.Depth + 1));
                    }

                    else
                    {
                        var jug1 = new Jug(node.Jugs.ElementAt(0).Capacity, node.Jugs.ElementAt(0).Current);
                        var jug2 = new Jug(node.Jugs.ElementAt(1).Capacity, node.Jugs.ElementAt(1).Current);

                        jug2.Current -= jug1.EmptySpace;
                        jug1.FillJug();
                        transitions.Add(new Node(jug1, jug2, node.Jugs.ElementAt(2), node.Depth + 1));
                    }
                }

                if (!node.Jugs.ElementAt(2).IsEmpty())
                {
                    var jug1EmptySpace = node.Jugs.ElementAt(0).EmptySpace;
                    var jug3Current = node.Jugs.ElementAt(2).Current;

                    if (jug1EmptySpace >= jug3Current)
                    {
                        var jug1 = new Jug(node.Jugs.ElementAt(0).Capacity, node.Jugs.ElementAt(0).Current);
                        var jug3 = new Jug(node.Jugs.ElementAt(2).Capacity, node.Jugs.ElementAt(2).Current);

                        jug1.UpdateContent(jug3.Current);
                        jug3.EmptyJug();
                        transitions.Add(new Node(jug1, node.Jugs.ElementAt(1), jug3, node.Depth + 1));
                    }

                    else
                    {
                        var jug1 = new Jug(node.Jugs.ElementAt(0).Capacity, node.Jugs.ElementAt(0).Current);
                        var jug3 = new Jug(node.Jugs.ElementAt(2).Capacity, node.Jugs.ElementAt(2).Current);

                        jug3.Current -= jug1.EmptySpace;
                        jug1.FillJug();
                        transitions.Add(new Node(jug1, node.Jugs.ElementAt(1), jug3, node.Depth + 1));
                    }
                }
            }

            if (!jugTwo.IsFull())
            {
                if (!jugOne.IsEmpty())
                {
                    var jug2EmptySpace = node.Jugs.ElementAt(1).EmptySpace;
                    var jug1Current = node.Jugs.ElementAt(0).Current;

                    if (jug2EmptySpace >= jug1Current)
                    {
                        var jug1 = new Jug(node.Jugs.ElementAt(0).Capacity, node.Jugs.ElementAt(0).Current);
                        var jug2 = new Jug(node.Jugs.ElementAt(1).Capacity, node.Jugs.ElementAt(1).Current);

                        jug2.UpdateContent(jug1.Current);
                        jug1.EmptyJug();
                        transitions.Add(new Node(jug1, jug2, node.Jugs.ElementAt(2), node.Depth + 1));
                    }

                    else
                    {
                        var jug1 = new Jug(node.Jugs.ElementAt(0).Capacity, node.Jugs.ElementAt(0).Current);
                        var jug2 = new Jug(node.Jugs.ElementAt(1).Capacity, node.Jugs.ElementAt(1).Current);

                        jug1.Current -= jug2.EmptySpace;
                        jug2.FillJug();
                        transitions.Add(new Node(jug1, jug2, node.Jugs.ElementAt(2), node.Depth + 1));
                    }
                }

                if (!jugThree.IsEmpty())
                {
                    var jug2EmptySpace = node.Jugs.ElementAt(1).EmptySpace;
                    var jug3Current = node.Jugs.ElementAt(1).Current;

                    if (jug2EmptySpace >= jug3Current)
                    {
                        var jug2 = new Jug(node.Jugs.ElementAt(1).Capacity, node.Jugs.ElementAt(1).Current);
                        var jug3 = new Jug(node.Jugs.ElementAt(2).Capacity, node.Jugs.ElementAt(2).Current);

                        jug2.UpdateContent(jug3.Current);
                        jug3.EmptyJug();
                        transitions.Add(new Node(node.Jugs.ElementAt(0), jug2, jug3, node.Depth + 1));
                    }

                    else
                    {
                        var jug2 = new Jug(node.Jugs.ElementAt(1).Capacity, node.Jugs.ElementAt(1).Current);
                        var jug3 = new Jug(node.Jugs.ElementAt(2).Capacity, node.Jugs.ElementAt(2).Current);

                        jug3.Current -= jug2.EmptySpace;
                        jug2.FillJug();
                        transitions.Add(new Node(node.Jugs.ElementAt(0), jug2, jug3, node.Depth + 1));
                    }
                }
            }

            if (!jugThree.IsFull())
            {
                if (!jugOne.IsEmpty())
                {
                    var jug3EmptySpace = jugThree.EmptySpace;
                    var jug1Current = jugOne.Current;

                    if (jug3EmptySpace >= jug1Current)
                    {
                        var jug3 = new Jug(jugThree.Capacity, jugThree.Current);
                        var jug1 = new Jug(jugOne.Capacity, jugOne.Current);

                        jug3.UpdateContent(jug1.Current);
                        jug1.EmptyJug();

                        transitions.Add(new Node(jug1, jugTwo, jug3, node.Depth + 1));
                    }

                    else
                    {
                        var jug3 = new Jug(jugThree.Capacity, jugThree.Current);
                        var jug1 = new Jug(jugOne.Capacity, jugOne.Current);

                        jug1.Current -= jug3.EmptySpace;
                        jug3.FillJug();

                        transitions.Add(new Node(jug1, jugTwo, jug3, node.Depth + 1));
                    }
                }

                if (!jugTwo.IsEmpty())
                {
                    var jug3EmptySpace = jugThree.EmptySpace;
                    var jug2Current = jugTwo.Current;

                    if (jug3EmptySpace >= jug2Current)
                    {
                        var jug3 = new Jug(jugThree.Capacity, jugThree.Current);
                        var jug2 = new Jug(jugTwo.Capacity, jugTwo.Current);

                        jug3.UpdateContent(jug2.Current);
                        jug2.EmptyJug();

                        transitions.Add(new Node(jugOne, jug2, jug3, node.Depth + 1));
                    }

                    else
                    {
                        var jug3 = new Jug(jugThree.Capacity, jugThree.Current);
                        var jug2 = new Jug(jugTwo.Capacity, jugTwo.Current);

                        jug2.Current -= jug3.EmptySpace;
                        jug3.FillJug();

                        transitions.Add(new Node(jugOne, jug2, jug3, node.Depth + 1));
                    }
                }
            }

            return GetOnlyAvailableTransitions(transitions);
        }

        private List<Node> GetOnlyAvailableTransitions(List<Node> nodes)
        {
            var availableNodes = new List<Node>(nodes);

            if (AppliedRules.Any())
            {
                foreach (var node in nodes)
                {
                    foreach (var appliedRule in AppliedRules)
                    {
                        if (Enumerable.SequenceEqual(node.GetJugsCurrent, appliedRule.GetJugsCurrent))
                        {
                            availableNodes.Remove(node);
                        }
                    }
                }
            }
            Console.WriteLine($"Transições disponíveis: {Helper.PrintNodes(availableNodes)}");
            return availableNodes;
        }

        public Node ChooseBestNode(List<Node> nodes)
        {
            OpenRules.AddRange(nodes);

            var candidateNodes = OpenRules.Where(x => x.Function == OpenRules.Min(x => x.Function)).ToList();
            Node bestNode = null;

            if (candidateNodes.Count() > 1)
            {
                var higherDepth = candidateNodes.Min(x => x.Depth);
                var higherDepthNodes = candidateNodes.Where(x => x.Depth == higherDepth).ToList();
                bestNode = higherDepthNodes.FirstOrDefault();

                if (higherDepthNodes.Count() > 1)
                {
                    var openRules = new List<Node>(OpenRules);

                    foreach (var openRule in openRules)
                    {
                        if (Enumerable.SequenceEqual(openRule.GetJugsCurrent, bestNode.GetJugsCurrent))
                        {
                            OpenRules.RemoveAll(x => Enumerable.SequenceEqual(x.GetJugsCurrent, bestNode.GetJugsCurrent));
                        }
                    }
                }
            }
            else
            {
                bestNode = candidateNodes.FirstOrDefault();
            }

            Console.WriteLine($"Abertas: {Helper.PrintNodes(OpenRules)}");
            Console.WriteLine($"Fechadas: {Helper.PrintNodes(AppliedRules)} \n");

            AppliedRules.Add(bestNode);
            PruneNodes(OpenRules);
            OpenRules.Remove(bestNode);
         
            return bestNode;
        }

        private void PruneNodes(List<Node> nodes)
        {
            var candidates = new List<Node>(nodes);

            foreach (var candidate in candidates)
            {
                var candidatesPruneNodes = candidates.Where(x => Enumerable.SequenceEqual(x.GetJugsCurrent, candidate.GetJugsCurrent)).ToList();

                if (candidatesPruneNodes.Any())
                {
                    var pruneNodes = candidatesPruneNodes.Where(x => x.Function > candidate.Function).ToList();

                    if (pruneNodes.Any())
                    {
                        foreach (var pruneNode in pruneNodes)
                        {
                            nodes.Remove(pruneNode);
                        }
                    }
                }
            }
        }

        public bool IsProblemSolved(Node node)
        {
            if (node.Jugs.ElementAt(0).Current.Equals(4) &&
               node.Jugs.ElementAt(1).Current.Equals(4) &&
               node.Jugs.ElementAt(2).Current.Equals(0))
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}


