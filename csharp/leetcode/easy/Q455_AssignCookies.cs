public class Q455_AssignCookies
{
    // TC: O(n log n), SC: O(1)
    public int FindContentChildren(int[] g, int[] s)
    {
        var match = 0;
        Array.Sort(g);
        Array.Sort(s);
        for(var i = 0; i<s.Length; i++)
        {
            if(s[i] >= g[match]) { match++; }
            if (match >= g.Length) break;
        }
        return match;
    }
}

public class Q455_AssignCookiesTestData: TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1, 2, 3}, new int[] {1, 1}, 1],
        [new int[] {1, 2}, new int[] {1, 2, 3}, 2],
    ];
}

public class Q455_AssignCookiesTest
{
    [Theory]
    [ClassData(typeof(Q455_AssignCookiesTestData))]
    public void OfficerTestCase(int[] g, int[] s, int expected)
    {
        var sut = new Q455_AssignCookies();
        var actual = sut.FindContentChildren(g, s);
        Assert.Equal(expected, actual);
    }
}