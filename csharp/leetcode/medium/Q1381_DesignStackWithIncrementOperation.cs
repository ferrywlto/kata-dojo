public class Q1381_DesignStackWithIncrementOperation
{
    public class CustomStack
    {
        public CustomStack(int maxSize)
        {

        }

        public void Push(int x)
        {
        }

        public int Pop()
        {
            return 0;
        }

        public void Increment(int k, int val)
        {

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

