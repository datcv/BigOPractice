using System;

namespace _83.RemoveDuplicatesFromSortedList
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new ListNode(1)
            {
                next = new ListNode(1)
                {
                    next = new ListNode(2)
                    {
                        next = new ListNode(3)
                        {
                            next = new ListNode(3)
                        }
                    }
                }
            };

            Console.WriteLine("Input: ");
            lst.Print();

            var l = DeleteDuplicates(lst);

            Console.WriteLine();
            Console.WriteLine("Output: ");
            l.Print();
        }

        public static ListNode DeleteDuplicates(ListNode head)
        {
            var temp = head;

            while (temp != null && temp.next != null)
            {
                if (temp.val == temp.next.val)
                {
                    temp.next = temp.next.next;
                }
                else
                {
                    temp = temp.next;
                }

            }

            return head;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }

        public void Print()
        {
            var t = this;
            while(t != null)
            {
                Console.Write($" {t.val}");
                t = t.next;
            }
        }
    }
}
