public class Q2644_FindMaxDivisibilityScore
{
    // TC: O(n * m), n scale with length of divisors, m scale with length of nums
    // SC: O(1), space used does not scale with input
    public int MaxDivScore(int[] nums, int[] divisors)
    {
        var highestScore = int.MinValue;
        var smallestDiv = int.MaxValue;
        foreach (var div in divisors)
        {
            var currentScore = 0;
            foreach (var n in nums)
            {
                if (n % div == 0) currentScore++;
            }
            if (currentScore > highestScore)
            {
                highestScore = currentScore;
                smallestDiv = div;
            }
            else if (currentScore == highestScore && div < smallestDiv)
            {
                smallestDiv = div;
            }
        }
        return smallestDiv;
    }
    public static TheoryData<int[], int[], int> TestData => new()
    {

        {new int[] {2,9,15,50}, new int[] {5,3,7,2}, 2},
        {new int[] {4,7,9,3,9}, new int[] {5,2,3}, 3},
        {new int[] {20,14,21,10}, new int[] {10,16,20}, 10},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = MaxDivScore(input1, input2);
        Assert.Equal(expected, actual);
    }
}