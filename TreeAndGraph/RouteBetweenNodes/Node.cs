namespace RouteBetweenNodes
{
    public class Node
    {
        public Node(){}
        public Node(string name):this()
        {
            this.Name = name;
        }

        public string Name { get; set; }
        public Node[] Children { get; set; }
    }
}