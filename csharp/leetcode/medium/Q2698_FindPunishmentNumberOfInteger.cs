using System.Text;

public class Q2698_FindPunishmentNumberOfInteger
{
    private static HashSet<int> cache = [];
    private HashSet<int> set = [];
    private string numStr = "";
    public int PunishmentNumber(int n)
    {
        for (var i = 1; i <= n; i++)
        {
            if (cache.Contains(i))
            {
                set.Add(i);
            }
            var sq = i * i;
            numStr = sq.ToString();
            t(0, 0, i);
        }

        return set.Sum(p => p * p);
    }
    // A way to enumerate all possible partitions
    private void t(int idx, int sum, int n)
    {
        if (idx >= numStr.Length)
        {
            if (sum == n)
            {
                cache.Add(n);
                set.Add(n);
                return;
            }
        }

        var sb = new StringBuilder();
        for (var i = idx; i < numStr.Length; i++)
        {
            if (sb.Length == numStr.Length) return;

            sb.Append(numStr[i]);
            var val = int.Parse(sb.ToString());
            var nextSum = val + sum;

            if (nextSum > n) return;
            t(i + 1, nextSum, n);
        }
    }
    public static TheoryData<int, int> TestData => new()
    {
        {10, 182},
        {37, 1478},
        {91, 21533},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = PunishmentNumber(input);
        Assert.Equal(expected, actual);
    }
}