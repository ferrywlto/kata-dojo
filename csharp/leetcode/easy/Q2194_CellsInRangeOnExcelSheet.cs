public class Q2194_CellsInRangeOnExcelSheet
{
    // TC: O(n * m), n scale with diff from s[0] and s[3], m sacle with diff from s[4] and s[1]
    // SC: O(n * m) if counting the list to store the result, O(1) otherwise
    public IList<string> CellsInRange(string s)
    {
        var result = new List<string>();

        for (var i = s[0]; i <= s[3]; i++)
        {
            for (var j = s[1]; j <= s[4]; j++)
            {
                result.Add(i.ToString() + j.ToString());
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        ["K1:L2", new string[] {"K1","K2","L1","L2"}],
        ["A1:F1", new string[] {"A1","B1","C1","D1","E1","F1"}],
        ["A1:A9", new string[] {"A1","A2","A3","A4","A5","A6","A7","A8","A9"}],
        ["Z1:Z1", new string[] {"Z1"}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, string[] expected)
    {
        var actual = CellsInRange(input);
        Assert.Equal(expected, actual);
    }
}
