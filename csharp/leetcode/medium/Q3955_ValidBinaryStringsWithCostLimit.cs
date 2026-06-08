public class Q3955_ValidBinaryStringsWithCostLimit
{
    // TC: O(2^n)
    // SC: O(n)
    public IList<string> GenerateValidStrings(int n, int k)
    {
        var result = new List<string>();
        Span<char> sb = stackalloc char[n];
        Print(result, sb, n, k, 0, 0);
        return result;
    }

    private void Print(List<string> list, Span<char> sb, int n, int k, int cost, int curr)
    {
        if (curr >= n)
        {
            if (cost <= k)
            {
                list.Add(new string(sb));
            }
            return;
        }

        sb[curr] = '0';
        Print(list, sb, n, k, cost, curr + 1);

        if (curr != 0 && sb[curr - 1] == '1') return;

        sb[curr] = '1';
        Print(list, sb, n, k, cost + curr, curr + 1);
    }

    public static TheoryData<int, int, List<string>> TestData => new()
    {
        { 3, 1, ["000", "010", "100"] },
        { 1, 0, ["0", "1"] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int n, int k, List<string> expected)
    {
        var actual = GenerateValidStrings(n, k);
        Assert.Equal(expected, actual);
    }
}
