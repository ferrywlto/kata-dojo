public class Q2341_MaxNumberOfPairsInArray
{
    // TC: O(n+m), n scale with length of nums, m scale with unique numbers in nums
    // SC: O(m), m scale with unique numbers in nums
    public int[] NumberOfPairs(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        foreach (var n in nums)
        {
            if (dict.TryGetValue(n, out var val)) dict[n] = ++val;
            else dict.Add(n, 1);
        }
        var pair = 0;
        var remaining = 0;
        foreach (var p in dict)
        {
            if (p.Value % 2 == 0) pair += p.Value / 2;
            else
            {
                remaining++;
                if (p.Value > 1) pair += p.Value / 2;
            }
        }
        return [pair, remaining];
    }
    public static List<object[]> TestData =>
    [
        [new int[] {5,12,53,22,7,59,41,54,71,24,91,74,62,47,20,14,73,11,82,2,15,38,38,20,57,70,86,93,38,75,94,19,36,40,28,6,35,86,38,94,4,90,18,87,24,22}, new int[] {7,32}],
        [new int[] {1,3,2,1,3,2,2}, new int[] {3,1}],
        [new int[] {1,1}, new int[] {1,0}],
        [new int[] {0}, new int[] {0,1}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = NumberOfPairs(input);
        Assert.Equal(expected, actual);
    }
}