using dojo.leetcode;

public class VersionControl
{
    protected readonly int BadVersion;
    public VersionControl(int bad) { BadVersion = bad; }
    public bool IsBadVersion(int n) => n >= BadVersion;
}

public class Q278_FirstBadVersion(int bad) : VersionControl(bad)
{

    public int FirstBadVersion(int n)
    {
        for (var i = 1; i <= n; i++)
        {
            if (IsBadVersion(i)) return i;
        }
        return int.MaxValue;
    }  
}

public class Q278_FirstBadVersionTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [5, 4, 4],
        [1, 1, 1],
    ];
}

public class Q278_FirstBadVersionTests(ITestOutputHelper output): BaseTest(output)
{
    [Theory]
    [ClassData(typeof(Q278_FirstBadVersionTestData))]
    public void OfficialTestCases(int input, int bad, int expected)
    {
        var sut = new Q278_FirstBadVersion(bad);
        var actual = sut.FirstBadVersion(input);
        Assert.Equal(expected, actual);
    }
}