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

        public static void LongParameterListTest(string param1, string param2, string param3, string param4, string param5, string param6, string param7, string param8, string param9, string param10, string param11, string param12, string param13, string param14)
        {
            Console.WriteLine(param1 + param2);
        }
    }
}
