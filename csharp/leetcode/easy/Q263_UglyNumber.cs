using dojo.leetcode;

public class Q263_UglyNumber
{
    public bool IsUgly(int n)
    {
        return false;
    }
}

public class Q263_UglyNumberTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [6, true],
        [1, true],
        [14, false],
    ];
}


public class Q263_UglyNumberTests(ITestOutputHelper output):BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q263_UglyNumberTestData))]
    public void OfficialTestCases(int input, bool expected)
    {
        var sut = new Q263_UglyNumber();
        var actual = sut.IsUgly(input);
        Assert.Equal(expected, actual); 
    }
}