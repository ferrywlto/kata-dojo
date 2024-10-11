public class Q2094_FindingThreeDigitEvenNumbers(ITestOutputHelper output)
{
    public int[] FindEvenNumbers(int[] digits)
    {
        RecursiveInnerProduct(digits, 0, 3, []);
        var l = result.Select(x => string.Join(',', x.Select(x => digits[x]).ToArray()));
        output.WriteLine(string.Join(Environment.NewLine, l));

        var sorted = result
            .Select(x => digits[x[0]] * 100 + digits[x[1]] * 10 + digits[x[2]])
            .Order()
            .Distinct()
            .ToArray();
        return sorted;
    }

    // This is for reference, will make it to use generic 
    List<int[]> result = [];
    private void RecursiveInnerProduct(int[] input, int depth, int depthMax, int[] list)
    {
        if (depth == depthMax)
        {
            result.Add(list);
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