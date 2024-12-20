public class Q2682_FindLosersOfCircularGame
{
    //TC: O(n), n scale with size of n, worst case all 1 to n are traversed, plus n to select those not traversed into result
    //SC: O(n), worst case n entries are added
    public int[] CircularGameLosers(int n, int k)
    {
        var set = new HashSet<int> { 1 };
        var round = 1;
        var current = 0;
        while (true)
        {
            current = (current + (round * k)) % n;
            if (set.Add(current + 1)) round++;
            else break;
        }
        var result = new List<int>();
        for (var i = 1; i <= n; i++)
        {
            if (!set.Contains(i)) result.Add(i);
        }
        return result.ToArray();
    }
    public static TheoryData<int, int, int[]> TestData => new()
    {
        {5, 2, [4, 5]},
        {4, 4, [2, 3, 4]},
        {2, 1, []},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int k, int[] expected)
    {
        var actual = CircularGameLosers(input, k);
        Assert.Equal(expected, actual);
    }
}