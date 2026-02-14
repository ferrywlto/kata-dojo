public class Q3074_AppleRedistributionIntoBoxes
{
    // TC: O(n+m+m log m), n scale with length of apple and m scale with length of capacity
    // SC: O(1), space used does not scale with input
    public int MinimumBoxes(int[] apple, int[] capacity)
    {
        var appleCount = apple.Sum();
        Array.Sort(capacity);
        var result = 0;
        var capacitySum = 0;
        for (var i = capacity.Length - 1; i >= 0; i--)
        {
            capacitySum += capacity[i];
            result++;
            if (capacitySum >= appleCount)
            {
                return result;
            }
        }

        return 0;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {
        {[1,3,2], [4,3,1,5,2], 2},
        {[5,5,5], [2,4,2,7], 4},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] apple, int[] boxes, int expected)
    {
        var actual = MinimumBoxes(apple, boxes);
        Assert.Equal(expected, actual);
    }
}
