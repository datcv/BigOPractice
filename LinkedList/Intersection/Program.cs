using System;

namespace Intersection
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Node c = new Node(1);
            c.InsertBack(new Node(2));
            c.InsertBack(new Node(3));
            c.InsertBack(new Node(4));

            Node n1 = new Node(9);
            n1.InsertBack(new Node(8));
            n1.InsertBack(new Node(8));
            n1.InsertBack(new Node(7));
            n1.InsertBack(c);

            Node n2 = new Node(91);
            n2.InsertBack(new Node(82));
            n2.InsertBack(c);

            var l1 = n1.Length();
            var l2 = n2.Length();

            for (int i = l2; i < l1; i++)
            {
                n1 = n1.Next;
            }

            for (int i = l1; i < l2; i++)
            {
                n2 = n2.Next;
            }


            var r = FindIntersection(n1, n2);
            if (r.Intersection == null)
            {
                Console.WriteLine("NIL");
            }
            else
            {
                r.Intersection?.PrintAll();
            }

        }


        static PResult FindIntersection(Node n1, Node n2)
        {
            if (n1 == null && n2 == null)
            {
                return new PResult();
            }

            var r2 = FindIntersection(n1.Next, n2.Next);

            if (n1 == n2)
            {
                r2.Intersection = n1;
            }

            return r2;

        }

    }

    public class PResult
    {
        public Node Intersection { get; set; }
    }


    public class Node
    {
        public Node(int v)
        {
            this.Value = v;
            this.Next = null;
        }

        public int Value { get; set; }
        public Node Next { get; set; }

        public void InsertBack(Node n)
        {
            var c = this;
            while (c.Next != null)
            {
                c = c.Next;

            }

            c.Next = n;
        }
        public void PrintAll()
        {
            var head = this;
            while (head != null)
            {
                System.Console.Write($"{head.Value} ");
                head = head.Next;
            }
        }

        public int Length()
        {
            int count = 0;
            var head = this;
            while (head != null)
            {
                count++;
                head = head.Next;
            }

            return count;
        }
    }
}
