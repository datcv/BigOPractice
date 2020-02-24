using System;

namespace _23.MergeKSortedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            var lists = new ListNode[] {
                new ListNode(1){next = new ListNode(4){next = new ListNode(5)}},
                new ListNode(1){next = new ListNode(3){next = new ListNode(4)}},
                new ListNode(2){next = new ListNode(6){}},
            };

            
            
            // var d = MergeKLists(lists);

            var d = MergeKLists(lists);

            Console.WriteLine("Output: ");
            while (d != null)
            {
                Console.Write(" " + d.val);
                d = d.next;
            }

        }

        private static int FindNext(ListNode[] lists)
        {            
            var minIndex = -1;
            for (int i = 0; i < lists.Length; i++)
            {
                if (lists[i] == null)
                {
                    continue;
                }

                if (minIndex == -1 || lists[minIndex].val > lists[i].val)
                {
                    minIndex = i;
                }               
            }

            return minIndex;
        }

        public static ListNode MergeKLists(ListNode[] lists)
        {            
            if (lists.Length == 0)
            {
                return null;
            }

            if (lists.Length == 1)
            {
                return lists[0];
            }

            var n = lists.Length;
            var i = 0;
            while(n > 1)
            {
                var m = Merge2Lists(lists[i], lists[n - 1 - i]);
                lists[i] = m;
                i++;

                if (i == n/2)
                {
                    if (n % 2 == 1)
                    {
                        n = n/2 + 1;
                    }
                    else
                    {
                        n = n/2;
                    }

                    i = 0;                    
                }

                if (n == 0)
                {
                    break;
                }
            }

           
            return lists[0];
        }

        public static ListNode Merge2Lists(ListNode a, ListNode b)
        {
            if (a == null)
            {
                return b;
            }

            if (b == null)
            {
                return a;
            }

            var m = new ListNode(0);
            var c = m;
            while(a != null && b != null)
            {
                if (a.val < b.val)
                {
                    c.next = a;                    
                    a = a.next;
                }
                else{
                    c.next = b;
                    b = b.next;
                }

                c = c.next;
            }

            if (a != null)
            {
                c.next = a;
            }
            
            if (b != null)
            {
                c.next = b;
            }

            return m.next;
        }

        

        private static int? MinValue(ListNode[] lists)
        {
            var minIndex = 0;
            
            for (var i = 1; i < lists.Length; i++)
            {
                if (lists[i] == null)
                {
                    continue;
                }

                if (lists[minIndex] == null || lists[i].val < lists[minIndex].val)
                {
                    minIndex = i;
                }
            }

            if (lists[minIndex] == null)
            {
                return null;
            }

            var minValue = lists[minIndex].val;

            lists[minIndex] = lists[minIndex].next;
            
            return minValue;
        }

    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
}
