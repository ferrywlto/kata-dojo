public class Q1769_MinNumOpsToMoveAllBallsToEachBox
{
    // TC: O(n * m), n scale with length of boxes, m scale with number of 1 in boxes
    // SC: O(n + m), n for holding answer, m for list
    public int[] MinOperations(string boxes)
    {
        var ans = new int[boxes.Length];
        var list = new List<int>();
        for (var i = 0; i < boxes.Length; i++)
        {
            if (boxes[i] == '1') list.Add(i);
        }
        for (var i = 0; i < boxes.Length; i++)
        {
            var sum = 0;
            for (var j = 0; j < list.Count; j++)
            {
                var diff = Math.Abs(list[j] - i);
                sum += diff;
            }
            ans[i] = sum;
        }
        return ans;
    }
    public static TheoryData<string, int[]> TestData => new()
    {
        {"110", [1,1,3]},
        {"001011", [11,8,5,4,3,4]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int[] expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }

}