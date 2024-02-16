namespace dojo.leetcode;

public class Q504_Base7
{
    public string ConvertToBase7(int num)
    {
        return string.Empty;
    }
}

public class Q504_Base7TestData : TestData
{
    protected override List<object[]> Data =>
    [
        [100, "202"],
        [-7, "-10"],
    ];
}

public class Q504_Base7Tests
{
    [Theory]
    [ClassData(typeof(Q504_Base7TestData))]
    public void OfficialTestCases(int num, string expected)
    {
        var sut = new Q504_Base7();
        var actual = sut.ConvertToBase7(num);
        Assert.Equal(expected, actual);
    }
}