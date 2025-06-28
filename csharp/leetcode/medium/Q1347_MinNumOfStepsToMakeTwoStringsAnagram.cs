public class Q1347_MinNumOfStepsToMakeTwoStringsAnagram
{
    public int MinSteps(string s, string t)
    {
        return 0;
    }
    public static TheoryData<string, string, int> TestData => new()
    {
        {"bab", "aba", 1},
        {"leetcode", "practice", 5},
        {"anagram", "mangaar", 5},
    };
    [Theory]
    [MemberData(nameof(TestData)]
    public void Test(string input1, string input2, int expected)
    {
        var actual = MinSteps(input1, input2);
        Assert.Equal(expected, actual);
    }
}