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
        if (n == 1 || IsBadVersion(1)) return 1;
        if (IsBadVersion(n) && !IsBadVersion(n-1)) return n;

        var start = 1;
        var end = n;
        var middle = Middle(start, end);

        while (middle != start && middle != end)
        {
            if (IsBadVersion(middle) && !IsBadVersion(middle - 1)) return middle;
            else 
            {
                if (IsBadVersion(middle - 1))
                    end = middle;
                else
                    start = middle;
                middle = Middle(start, end);
            }
        }
        return int.MaxValue;
    }

    public int Middle(int start, int end) 
    {
        var temp = start + (long)end;
        return (int)(temp / 2);
    } 
}

public class Q278_FirstBadVersionTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [5, 4, 4],
        [1, 1, 1],
        [int.MaxValue, int.MaxValue, int.MaxValue],
        [int.MaxValue, 1, 1],
        [int.MaxValue, int.MaxValue-1, int.MaxValue-1],
    ];
}

public class Q278_FirstBadVersionTests
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