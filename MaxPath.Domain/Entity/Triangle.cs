using System;
using System.Collections.Generic;
using System.Text;

namespace MaxPath.Domain.Entity
{
    public class Triangle
    {
        public Node Head { get; set; }
        public string Tree { get; set; }
        public string MaxPath { get; set; }
        public int MaxSum { get; set; }
        public int DeepestPathLevel { get; set; }
        public int Level { get; set; }

        public bool IsValidPath
        {
            get
            {
                if (DeepestPathLevel != Level)
                    return false;
                else
                    return true;
            }
        }
    }
}
