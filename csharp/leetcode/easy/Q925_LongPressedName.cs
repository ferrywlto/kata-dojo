using System.Text;
using System.Text.RegularExpressions;

class Q925_LongPressedName
{
    // TC: O(n), n is length of name
    // SC: O(n), n is size of string builder, which is also the length of name 
    public bool IsLongPressedName(string name, string typed)
    {
        var regexInput = new StringBuilder("^");
        for (var i = 0; i < name.Length; i++)
        {
            regexInput.Append($"[{name[i]}]+");
        }
        regexInput.Append('$');

        var regex = new Regex(regexInput.ToString());
        var matches = regex.Matches(typed);

        return matches.Count == 1;
    }
}

class Q925_LongPressedNameTestData : TestData
{
    protected override List<object[]> Data =>
    [
        ["alex", "aaleex", true],
        ["saeed", "ssaaedd", false],
    ];
}

public class Q925_LongPressedNameTests
{
    [Theory]
    [ClassData(typeof(Q925_LongPressedNameTestData))]
    public void OfficialTestCases(string input, string target, bool expected)
    {
        var sut = new Q925_LongPressedName();
        var actual = sut.IsLongPressedName(input, target);
        Assert.Equal(expected, actual);
    }
}