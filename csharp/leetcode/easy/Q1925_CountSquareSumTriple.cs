public class Q1925_CountSquareSumTriple
{
    // TC: O(n + n^2), n scale with size of n
    // SC: O(1), space used does not sacle with input 
    public int CountTriples(int n)
    {
        var result = 0;
        var power = new Dictionary<int, int>();
        var sqrt = new Dictionary<int, int>();
        for (var i = 1; i <= n; i++)
        {
            power.Add(i, i * i);
            sqrt.Add(i * i, i);
        }

        foreach (var p_power in power)
        {
            foreach (var p_sqrt in sqrt)
            {
                var diff = p_power.Value - p_sqrt.Key;
                if (sqrt.ContainsKey(diff)) result++;
            }
        }
        return result;
    }
    public static List<object[]> TestData =>
    [
        [5,2],
        [10,4],
        [250,330],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int expected)
    {
        var actual = CountTriples(input);
        Assert.Equal(expected, actual);
    }
}
