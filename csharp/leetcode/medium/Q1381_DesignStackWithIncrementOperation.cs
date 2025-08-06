public class Q1381_DesignStackWithIncrementOperation
{
    public class CustomStack
    {
        private readonly int[] fakeStack;
        private readonly int maxSize;
        private int top = -1;
        public CustomStack(int maxSize)
        {
            this.maxSize = maxSize;
            fakeStack = new int[maxSize];
        }

        public void Push(int x)
        {
            if (top < maxSize - 1)
            {
                fakeStack[++top] = x;
            }
        }

        public int Pop()
        {
            if (top == -1) return top;
            var popped = fakeStack[top];
            top--;
            return popped;
        }

        public void Increment(int k, int val)
        {
            var max = Math.Min(k - 1, top);
            for (var i = 0; i <= max; i++)
            {
                fakeStack[i] += val;
            }
        }
    }

    public static TheoryData<string[], int[][], int?[]> TestData => new()
    {
        {
            ["CustomStack","push","push","pop","push","push","push","increment","increment","pop","pop","pop","pop"],
            [[3],[1],[2],[],[2],[3],[4],[5,100],[2,100],[],[],[],[]],
            [null,null,null,2,null,null,null,null,null,103,202,201,-1]
        },
        {
            ["CustomStack","push","pop","increment","pop","increment","push","pop","push","increment","increment","increment"],
            [[2],[34],[],[8,100],[],[9,91],[63],[],[84],[10,93],[6,45],[10,4]],
            [null,null,34,null,-1,null,null,63,null,null,null,null,null]
        }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] cmd, int[][] param, int?[] expected)
    {
        var stack = new CustomStack(param[0][0], output);
        for (var i = 1; i < cmd.Length; i++)
        {
            if (cmd[i] == "push")
            {
                stack.Push(param[i][0]);
            }
            else if (cmd[i] == "pop")
            {
                Assert.Equal(expected[i], stack.Pop());
            }
            else if (cmd[i] == "increment")
            {
                stack.Increment(param[i][0], param[i][1]);
            }
        }
    }
}

