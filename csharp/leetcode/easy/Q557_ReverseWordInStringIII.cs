namespace dojo.leetcode;

public class Q557_ReverseWordInStringIII
{
    public string ReverseWords(string s)
    {
        return string.Empty;
    }
}

public class Q557_ReverseWordInStringIIITestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["Let's take LeetCode contest", "s'teL ekat edoCteeL tsetnoc"],
        ["God Ding", "doG gniD"],
    ];
}

public class Q557_ReverseWordInStringIIITests
{
    [Theory]
    [ClassData(typeof(Q557_ReverseWordInStringIIITestData))]
    public void OfficialTestCases(string input, string expected)
    {
        var sut = new Q557_ReverseWordInStringIII();
        var actual = sut.ReverseWords(input);
        Assert.Equal(expected, actual);
    }
}