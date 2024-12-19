public class Q2678_NumberOfSeniorCitizens
{
    // TC: O(n), n scale with length of details
    // SC: O(1), space used does not scale with input
    public int CountSeniors(string[] details)
    {
        var result = 0;
        foreach (var p in details)
        {
            if (int.Parse(p.Substring(11, 2)) > 60) result++;
        }
        return result;
    }
    public static TheoryData<string[], int> TestData => new()
    {
        {["7868190130M7522","5303914400F9211","9273338290F4010"], 2},
        {["1313579440F2036","2921522980M5644"], 0},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int expected)
    {
        var actual = CountSeniors(input);
        Assert.Equal(expected, actual);
    }
}