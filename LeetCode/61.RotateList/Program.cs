using System;

namespace _61.RotateList
{
    class Program
    {
        static void Main(string[] args)
        {
            var head = new ListNode(1)
            {
                next = new ListNode(2)
                {
                    next = new ListNode(3)
                    {
                        next = new ListNode(4)
                        {
                            next = new ListNode(5)
                        }
                    }
                }
            };

            Console.WriteLine($"Input: {head.Print()}");
            var rotatedList = RotateRight(head, 2);
            Console.WriteLine($"Output: {rotatedList.Print()}");
        }

        public static ListNode RotateRight(ListNode head, int k)
        {
            if (head == null)
            {
                return null;
            }

            var length = 1;
            var tail = head;
            while (tail.next != null)
            {
                length++;
                tail = tail.next;
            }

            if (k % length == 0)
            {
                return head;
            }

            tail.next = head;
            var t = length - k % length;

            var previousNode = head;
            for (int i = 1; i < t; i++)
            {
                previousNode = previousNode.next;
            }

            var result = previousNode.next;
            previousNode.next = null;
            return result;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public string Print()
        {
            var s = "";
            var temp = this;
            while (temp != null)
            {
                s += $" -> {temp.val}";
                temp = temp.next;
            }

            return s;
        }
    }
}
