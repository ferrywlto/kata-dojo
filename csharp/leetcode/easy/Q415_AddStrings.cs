
namespace dojo.leetcode;

public class Q415_AddStrings
{
    public string AddStrings(string num1, string num2)
    {
        return string.Empty;
    }
}

public class Q415_AddStringsTestData: TestData
{
    protected override List<object[]> Data => 
    [
        ["11", "123", "134"],
        ["456", "77", "533"],
        ["0", "0", "0"],
    ];
}

public class Q415_AddStringsTests
{
    [Theory]
    [ClassData(typeof(Q415_AddStringsTestData))]
    public void OfficialTestCase(string num1, string num2, string expected)
    {
        var sut = new Q415_AddStrings();
        var actual = sut.AddStrings(num1, num2);
        Assert.Equal(expected, actual);
    }
}