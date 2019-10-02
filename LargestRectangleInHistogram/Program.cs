using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargestRectangleInHistogram
{
    class Program
    {
        private static int [] heights = {2, 1, 5, 6, 2, 3};
        // Seems like Java letsyou say Stack<Integer> stack = new Stack<>() but C# does not. Wonder why.
        private static Stack<Int32> stack = new  Stack<Int32>();
        static void Main(string[] args)
        {
            
        }
        private static Int32 LargestRectangleArea (Int32 [] heights)
        {
            Int32 maxArea = 0;
            //Wonder if it is better to say: if(heights == null || heights.Length==0) 
            if (heights.Equals(null) || heights.Length==0)
            {
                return 0;
            }
            stack.Push(-1);
            for (int i = 0; i < heights.Length; i++)
            {
                int currentBarHeight = heights[i];
                while (stack.Peek()!=-1 && currentBarHeight <= heights[stack.Peek()])
                {
                    int height = heights[stack.Pop()];
                    int width = i-stack.Peek()-1;//I do not see what is happening in this line.
                    int area = height * width;
                    maxArea = Math.Max(area, maxArea);
                }
                stack.Push(i);
            }
            while (stack.Peek() != -1)
            {
                int height = heights[stack.Pop()];
                int width = heights.Length - stack.Peek() - 1;
                int area = height * width;
                maxArea = Math.Max(area, maxArea);
            }
            return maxArea;
        }
    }
}
