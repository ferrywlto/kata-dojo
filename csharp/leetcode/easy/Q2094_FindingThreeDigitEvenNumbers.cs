public class Q2094_FindingThreeDigitEvenNumbers(ITestOutputHelper output)
{
    int[]? _sharedDigits = null;
    readonly HashSet<int> result = [];
    public int[] FindEvenNumbers(int[] digits)
    {
        _sharedDigits = digits;
        RecursiveInnerProduct(digits, 0, 3, []);
        // var l = result.Select(x => string.Join(',', x));
        // output.WriteLine(string.Join(Environment.NewLine, l));

        var sorted = result
            .Order()
            .ToArray();
        return sorted;
    }

    private void RecursiveInnerProduct(int[] input, int depth, int depthMax, int[] list)
    {
        if (depth == depthMax)
        {
            result.Add(_sharedDigits![list[0]]*100 + _sharedDigits[list[1]]* 10 + _sharedDigits[list[2]]);
            return;
        }

        for (var i = 0; i < input.Length; i++)
        {
            var n = input[i];
            if (depth == 0 && n == 0) continue;
            else if (depth == depthMax - 1 && n % 2 != 0) continue;
            else if (list.Contains(i)) continue;

            var newList = new int[list.Length + 1];
            Array.Copy(list, newList, list.Length);
            newList[^1] = i;
            RecursiveInnerProduct(input, depth + 1, depthMax, newList);
        }
    }
    public static List<object[]> TestData =>
    [
        [new int[] {2,1,3,0}, new int[] {102,120,130,132,210,230,302,310,312,320}],
        [new int[] {2,2,8,8,2}, new int[] {222,228,282,288,822,828,882}],
        [new int[] {3,7,5}, Array.Empty<int>()],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = FindEvenNumbers(input);
        Assert.Equal(expected, actual);
    }
}