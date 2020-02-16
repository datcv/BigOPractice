using System;
using System.Collections.Generic;
namespace StackOfPlates
{
    class Program
    {
        static void Main(string[] args)
        {
            var stackofPlates = new StackOfPlates();
            stackofPlates.Push(1);
            stackofPlates.Push(2);
            stackofPlates.Push(3);
            stackofPlates.Push(4);
            stackofPlates.Push(5);
            stackofPlates.Push(6);
            stackofPlates.Push(7);
            stackofPlates.Push(8);
            stackofPlates.Push(9);
            stackofPlates.Push(10);
            stackofPlates.Push(11);

            // Console.WriteLine(stackofPlates.PopAt(2));
            Console.WriteLine(stackofPlates.Pop());
            Console.WriteLine(stackofPlates.Pop());
            Console.WriteLine(stackofPlates.Pop());
            Console.WriteLine(stackofPlates.Pop());
            Console.WriteLine(stackofPlates.Pop());

            Console.WriteLine(stackofPlates.Pop());
            Console.WriteLine(stackofPlates.Pop());
            Console.WriteLine(stackofPlates.Pop());
            Console.WriteLine(stackofPlates.Pop());
            Console.WriteLine(stackofPlates.Pop());
        }

    }

    public class StackOfPlates
    {
        private int _stackCount = 0;
        private int _threshold = 2;
        private Stack<int>[] _stacks;

        public StackOfPlates()
        {
            this._stacks = new Stack<int>[4];
        }

        public void Push(int i)
        {
            if (this._stackCount == 0)
            {
                this._stackCount++;
            }

            // Get last stack
            var stack = this.GetLastStack();
            if (stack.Count >= this._threshold)
            {
                this._stackCount++;
                stack = this.GetLastStack();
            }

            stack.Push(i);
        }

        public int Pop()
        {
            if (this._stackCount < 1)
            {
                throw new IndexOutOfRangeException();
            }

            // Get last stack
            var stack = this.GetLastStack();

            var r = stack.Pop();

            if (stack.Count < 1)
            {
                this._stackCount--;
            }

            return r;
        }


        // public int PopAt(int index)
        // {
        //     if (this._stackCount < 1 || index >= this._stackCount)
        //     {
        //         throw new IndexOutOfRangeException();
        //     }

        //     // Get last stack
        //     var stack = this._stacks[index];

        //     var r = stack.Pop();

        //     for (int i = index - 1; i >= 0; i--)
        //     {
        //         var nextStack = this._stacks[i + 1];
        //         var preStack = this._stacks[i];
        //         while (preStack.Count > 0)
        //         {
        //            var d= preStack.Pop();
        //             Console.WriteLine($"AA - {d}");
        //             nextStack.Push(d);
        //             if (nextStack.Count == this._threshold)
        //             {
        //                 break;
        //             }
        //         }
        //     }

        //     return r;
        // }

        private Stack<int> GetLastStack()
        {

            this.EnsureCapacity();

            if (this._stacks[this._stackCount - 1] == null)
            {
                this._stacks[this._stackCount - 1] = new Stack<int>(this._threshold);
            }

            return this._stacks[this._stackCount - 1];
        }

        private void EnsureCapacity()
        {
            var currentStacks = this._stacks;
            if (this._stackCount == currentStacks.Length)
            {
                this._stacks = new Stack<int>[this._stacks.Length * 2];
                for (int i = 0; i < currentStacks.Length; i++)
                {
                    this._stacks[i] = currentStacks[i];
                }
            }
        }
    }
}
