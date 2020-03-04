using System;

namespace _19.RemoveNthNodeFromEndOfList
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

            var r = RemoveNthFromEnd(head, 2);
            Console.WriteLine("Result: ");
            var d = r;
            while(d != null)
            {
                Console.Write($"{d.val} -> ");
                d = d.next;
            }
        }

        public static ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            var dummy = new ListNode(0)
            {
                next = head
            };

            var first = dummy;
            var second = dummy;
            while (n > 0)
            {
                n--;
                second = second.next;
            }

            while (second.next != null)
            {
                first = first.next;
                second = second.next;
            }

            first.next = first.next.next;
            return dummy.next;

        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
