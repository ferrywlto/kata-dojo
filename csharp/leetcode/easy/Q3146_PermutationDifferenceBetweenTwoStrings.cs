public class Q3146_PermutationDifferenceBetweenTwoStrings
{
    public int FindPermutationDifference(string s, string t)
    {
        return 0;
    }
    public static TheoryData<string, string, int> TestData => new()
    {
        {"abc", "bac", 2},
        {"abcde", "edbac", 12},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input1, string input2, int expected)
    {
        var actual = FindPermutationDifference(input1, input2);
        Assert.Equal(expected, actual);
    }
}
