public class Q3776_MinMovesToBalanceCircularArray
{
    public long MinMoves(int[] balance)
    {
        var sum = 0L;
        var negIdx = -1;

        for (var i = 0; i < balance.Length; i++)
        {
            sum += balance[i];
            if (balance[i] < 0)
            {
                negIdx = i;
            }
        }
        if (negIdx == -1) return 0;
        if (sum < 0) return -1;

        long valueToFeed = -balance[negIdx];

        var steps = 0L;
        var currDistance = 1;
        var leftIdx = negIdx;
        var rightIdx = negIdx;

        while (valueToFeed > 0)
        {
            leftIdx = leftIdx == 0 ? balance.Length - 1 : leftIdx - 1;
            rightIdx = rightIdx == balance.Length - 1 ? 0 : rightIdx + 1;

            if (balance[leftIdx] >= valueToFeed)
            {
                steps += valueToFeed * currDistance;
                return steps;
            }
            else
            {
                steps += balance[leftIdx] * currDistance;
                valueToFeed -= balance[leftIdx];
                balance[leftIdx] = 0;
            }

            if (balance[rightIdx] >= valueToFeed)
            {
                steps += valueToFeed * currDistance;
                return steps;
            }
            else
            {
                steps += balance[rightIdx] * currDistance;
                valueToFeed -= balance[rightIdx];
                balance[rightIdx] = 0;
            }

            currDistance++;
        }

        return steps;
    }
    public static TheoryData<int[], long> TestData => new()
    {
        {[5,1,-4], 4},
        {[1,2,-5,2], 6},
        {[-3,2], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, long expected)
    {
        var actual = MinMoves(input);
        Assert.Equal(expected, actual);
    }
}
