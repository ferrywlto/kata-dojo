using Microsoft.VisualBasic;

public class Q1381_DesignStackWithIncrementOperation
{
    public class CustomStack
    {
        private readonly Stack<int> stack = new();
        private readonly int maxSize;
        public CustomStack(int maxSize)
        {
            this.maxSize = maxSize;
        }

        public void Push(int x)
        {
            if (stack.Count < maxSize)
            {
                stack.Push(x);
            }
        }

        public int Pop()
        {
            if (stack.Count == 0) return -1;
            return stack.Pop();
        }

        private readonly Stack<int> reverseStack = new();
        public void Increment(int k, int val)
        {
            if (k < stack.Count)
            {
                var top = stack.Count - k;
                for (var i = 0; i < top; i++)
                {
                    reverseStack.Push(stack.Pop());
                }
            }
            while (stack.Count > 0)
            {
                reverseStack.Push(stack.Pop() + val);
            }
            while (reverseStack.Count > 0)
            {
                stack.Push(reverseStack.Pop());
            }
        }
    }

    public static TheoryData<string[], int[][], int?[]> TestData => new()
    {
        {
            ["CustomStack","push","push","pop","push","push","push","increment","increment","pop","pop","pop","pop"],
            [[3],[1],[2],[],[2],[3],[4],[5,100],[2,100],[],[],[],[]],
            [null,null,null,2,null,null,null,null,null,103,202,201,-1]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] cmd, int[][] param, int?[] expected)
    {
        var stack = new CustomStack(param[0][0]);
        for (var i = 1; i < cmd.Length; i++)
        {
            if (cmd[i] == "push")
            {
                stack.Push(param[i][0]);
            }
            else if (cmd[i] == "pop")
            {
                Assert.Equal(stack.Pop(), expected[i]);
            }
            else if (cmd[i] == "increment")
            {
                stack.Increment(param[i][0], param[i][1]);
            }
        }
    }
}

