public class Q4070_MinRotationsToDialANumberI
{
    // Min rotations obtained from the code below:
    // for (var i = 0; i < 10; i++)
    // {
    //     for (var j = 0; j < 10; j++)
    //     {
    //         var forward = Math.Abs(i - j);
    //         var backward = Math.Abs(i + 10 - j);
    //         var min = Math.Min(forward, backward);
    //         output.WriteLine($"{i} to {j}: f:{forward}, b: {backward}, min: {min}");
    //     }
    // }
    private static readonly int[][] Best = new int[][]
    {
        [0, 1, 2, 3, 4, 5, 4, 3, 2, 1],
        [1, 0, 1, 2, 3, 4, 5, 4, 3, 2],
        [2, 1, 0, 1, 2, 3, 4, 5, 4, 3],
        [3, 2, 1, 0, 1, 2, 3, 4, 5, 4],
        [4, 3, 2, 1, 0, 1, 2, 3, 4, 5],
        [5, 4, 3, 2, 1, 0, 1, 2, 3, 4],
        [4, 5, 4, 3, 2, 1, 0, 1, 2, 3],
        [3, 4, 5, 4, 3, 2, 1, 0, 1, 2],
        [2, 3, 4, 5, 4, 3, 2, 1, 0, 1],
        [1, 2, 3, 4, 5, 4, 3, 2, 1, 0]
    };

    // TC: O(n)
    // SC: O(1)
    public int MinRotations(string s)
    {
        var result = 0;
        var pointer = 0;
        foreach (var c in s)
        {
            var n = c - '0';
            result += Best[pointer][n];
            pointer = n;
        }
        return result;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "0192837465", 25 },
        { "1200210200", 12 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinRotations(input);
        Assert.Equal(expected, actual);
    }
}
