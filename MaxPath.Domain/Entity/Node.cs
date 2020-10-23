namespace MaxPath.Domain.Entity
{
    public class Node
    {
        public int Value { get; set; }
        public int Level { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public NodeType NodeType
        {
            get
            {
                if (Value % 2 == 0)
                    return NodeType.Even;
                else
                    return NodeType.Odd;
            }
        }

        public Node(int itemValue, int itemLevel)
        {
            Value = itemValue;
            Level = itemLevel;
            Left = Right = null;
        }

        private Node()
        {
        }

        public Node NodeClone()
        {
            return new Node()
            {
                Value = this.Value,
                Level = this.Level,
                Left = this.Left,
                Right = this.Right
            };
        }
    }
}
