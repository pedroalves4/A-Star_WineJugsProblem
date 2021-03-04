using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trabalho_IA.Models
{
    public class Node
    {
        public int Depth { get; set; }
        public int Heuristc { get; set; }
        public List<Jug> Jugs { get; set; }
        public int Function { get; set; }
        public bool Visited { get; set; }

        public Node(Jug jug1, Jug jug2, Jug jug3, int depth)
        {
            Jugs = new List<Jug>
            {
                jug1,
                jug2,
                jug3
            };

            Depth = depth;

            Heuristc = Depth > 0 ? (Math.Abs(Jugs.ElementAt(0).Current - 4)) + (Math.Abs(Jugs.ElementAt(1).Current - 4)) : 0;

            Function = Heuristc + Depth;
        }

        public List<int> GetJugsCurrent
        {
            get
            {
                return new List<int>
                {
                    this.Jugs.ElementAt(0).Current,
                    this.Jugs.ElementAt(1).Current,
                    this.Jugs.ElementAt(2).Current,
                };
            }
        }     
    }
}
