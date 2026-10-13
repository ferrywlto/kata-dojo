public class Q4071_MinRotationsToDialANumberII(ITestOutputHelper output)
{
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

    public int MinRotations(int n, string s)
    {
        var result = 0;
        // var pointer = 0;
        var end = s[^1] - '0';
        var minIdx = -1;
        // var minDiff = int.MaxValue;

        for (var i = 1; i < s.Length; i++)
        {
            var prev = s[i - 1] - '0';
            var next = s[i] - '0';
            output.WriteLine($"from next {prev} to {end}: {Best[prev][end]}");
            // output.WriteLine($"from prev {prev} to {next}: {Best[prev][next]}");
            result += Best[prev][next];
            // pointer = next;
        }
        // output.WriteLine($"from {pointer} to {end}: {Best[pointer][end]}");
        output.WriteLine($"minIdx: {minIdx}, result: {result}");

        return -1;
    }

    public static TheoryData<int, string, int> TestData => new()
    {
        // { 4, "04219", 6 }, // minIDx 0
        // 09 -> 1*, 49 -> 5, 29 -> 3, 19 -> 2 vs 04 -> 4
        // 09124 = 1 2 1 2 = 6
        // 04912 = 4 5 2 1 = 12
        // 04291 = 4 2 3 2 = 11
        // 04219 = 4 2 1 2 = 9

        // { 4, "01502", 9 }, // minIDx 1
        // 02 -> 2, 12 -> 1*, 52 -> 3 vs 01 -> 1
        // 02051 = 2 2 5 1 = 10
        // 01205 = 1 1 2 5 = 9 *
        // 01520 = 1 4 3 2 = 10
        // 01502 = 1 4 5 2 = 12

        { 4, "02916", 12 }, // minIDx 2
        // 06 -> 6, 26 -> 4, 96 -> 3 *, 16 -> 5 vs 02
        // 06192 = 4 5 2 3 = 14, 06 = 6
        // 02619 = 2 4 5 2 = 13, 26 = 4
        // 02961 = 2 3 3 5 = 13, 96 = 3
        // 02916 = 2 3 2 5 = 12, 16 = 5 x
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, string input, int expected)
    {
        var actual = MinRotations(n, input);
        Assert.Equal(expected, actual);
    }
}
