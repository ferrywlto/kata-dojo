namespace dojo.leetcode;

public class Q258_AddDigits
{
    public int AddDigits(int num)
    {
        return 0;
    }
}

public class Q258_AddDigitsTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [38, 2],
        [0, 0],
    ];
}

public class Q258_AddDigitsTest(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q258_AddDigitsTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q258_AddDigits();
        var actual = sut.AddDigits(input);
        Assert.Equal(expected, actual);
    }
}