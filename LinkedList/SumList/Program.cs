using System;

namespace SumList
{
    class Program
    {
        static void Main(string[] args)
        {
            var l1 = new SinglyLinkedList(new int[] { 9, 7, 1, 6 });
            var l2 = new SinglyLinkedList(new int[] { 5, 9, 2 });

            // var sumNode = SumBackward(l1.Head, l2.Head, 0);
            var sumNode = SumForward(l1.Head, l2.Head);
            sumNode.PrintAll();
        }

        private static Node SumBackward(Node n1, Node n2, int carry)
        {
            if (n1 == null || n2 == null)
            {
                return null;
            }

            var val = carry;
            if (n1 != null)
            {
                val += n1.Value;
            }

            if (n2 != null)
            {
                val += n2.Value;
            }

            var i = val % 10;
            var node = new Node(i);
            carry = val / 10;

            node.Next = SumBackward(n1?.Next, n2?.Next, carry);
            return node;
        }



        private static Node SumForward(Node n1, Node n2)
        {
            if (n1 == null || n2 == null)
            {
                return null;
            }

            // Length n1, n2
            var length1 = n1.Length();
            var length2 = n2.Length();

            n1 = PadZeroToLeft(n1, length2 - length1);
            n2 = PadZeroToLeft(n2, length1 - length2);

            var sum = new PartialSum();
            var partialSum = RecAdd(sum, n1, n2);
            Node resultHead = partialSum.Sum;
            if (partialSum.Carry > 0)
            {
                // Insert before
                var newHead = new Node(partialSum.Carry);
                newHead.Next = resultHead;
                resultHead = newHead;
            }

            return resultHead;
        }

        private static Node PadZeroToLeft(Node n, int l)
        {
            if (l <= 0)
            {
                return n;
            }

            Node newHead = n;
            while(l > 0)
            {
                var newNode = new Node(0);
                newNode.Next = newHead;
                newHead = newNode;
                l--;
            }

            return newHead;
        }

        private static PartialSum RecAdd(PartialSum sum, Node n, Node m)
        {
            if (n == null && m == null)
            {
                return sum;
            }

            var sum2 = RecAdd(sum, n.Next, m.Next);

            var val = n.Value + m.Value + sum2.Carry;
            var newNode = new Node(val % 10);
            newNode.Next = sum2.Sum;            
            sum2.Sum = newNode;
            sum2.Carry = val / 10;            
            return sum2;

        }

        
    }

    public class PartialSum
    {
        public Node Sum{get;set;}
        public int Carry{get;set;}
    }
}
