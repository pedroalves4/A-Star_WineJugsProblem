using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_IA.Models
{
    public class Jug
    {
        public Jug(int capacity, int current)
        {
            Capacity = capacity;
            Current = current;
        }

        public int Capacity { get; set; }
        public int Current { get; set; }
        public int EmptySpace
        {
            get
            {
                return Capacity - Current;
            }
        }

        public void UpdateContent(int amount)
        {
            Current += amount;
        }

        public bool IsEmpty()
        {
            return Current == 0;
        }

        public bool IsFull()
        {
            return Current == Capacity;
        }

        public bool FillJug()
        {
            if (EmptySpace > 0)
            {
                Current = Capacity;
                return true;
            }

            return false;
        }

        public bool EmptyJug()
        {
            if (Current > 0)
            {
                Current = 0;
                return true;
            }

            return false;
        }
    }
}
