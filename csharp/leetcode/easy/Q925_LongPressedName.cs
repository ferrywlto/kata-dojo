
class Q925_LongPressedName
{
    public bool IsLongPressedName(string name, string typed) 
    {
        return false;
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