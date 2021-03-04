using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_IA.Models;

namespace Trabalho_IA.Helpers
{
    public static class Helper
    {
        public static string PrintNodes(List<Node> nodes)
        {
            string returnString = "";

            foreach (var node in nodes)
            {
                returnString += "{ ( ";
                foreach (var currentJug in node.GetJugsCurrent)
                {
                    returnString += $"{currentJug} ";
                }

                returnString += $"), {node.Depth}";
                returnString += " }, ";
            }

            return returnString;
        }

        public static string PrintNode(Node node)
        {
            string returnString = "";

            foreach (var currentJug in node.GetJugsCurrent)
            {
                returnString += $"{currentJug} ";
            }

            return $"( {returnString}), {node.Depth}";
        }
    }
}
