using System.Text;

public class Q3963_CreateGridWithExactlyOnePath
{
    // TC: O(m * n)
    // SC: O(m + n)
    public string[] CreateGrid(int m, int n)
    {
        var result = new string[m];
        var sb = new StringBuilder();
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i == 0 || j == n - 1)
                {
                    sb.Append('.');
                }
                else
                    sb.Append('#');
            }

            result[i] = sb.ToString();
            sb.Clear();
        }
        return result;
    }

    public static TheoryData<int, int, string[]> TestData => new()
    {
        { 2, 3, ["...", "##."] },
        { 3, 3, ["...", "##.", "##."] },
        { 1, 4, ["...."] },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int m, int n, string[] expected)
    {
        var actual = CreateGrid(m, n);
        Assert.Equal(expected, actual);
    }
}
