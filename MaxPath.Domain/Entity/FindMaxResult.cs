using System;
using System.Collections.Generic;
using System.Text;

namespace MaxPath.Domain.Entity
{
    public class FindMaxResult
    {
        public int MaxSum { get; set; }
        public string MaxPath { get; set; }
        public int LevelOfResult { get; set; }
    }
}
