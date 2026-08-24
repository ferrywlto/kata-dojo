public class Q4008_MinInitialStrengthToDefeatAllMonsters(ITestOutputHelper output)
{
    public long MinInitialStrength(int[] monsters, int[][] boosts)
    {
        // Use difference array to avoid n^2 writing to obtain boosts
        var difference = new long[monsters.Length + 1];

        foreach (var boost in boosts)
        {
            var left = boost[0];
            var right = boost[1];
            var value = boost[2];

            difference[left] += value;
            // reset after the last effective index
            difference[right + 1] -= value;
        }

        var effectiveBoost = new long[monsters.Length];
        // keep tracking
        var currentBoost = 0L;

        // difference[1] = 10
        // difference[4] = -10
        // effectiveBoost = [0, 10 (+10), 10(+0), 10(+0), 0(+-10)]
        for (var i = 0; i < monsters.Length; i++)
        {
            currentBoost += difference[i];
            effectiveBoost[i] = currentBoost;
        }

        output.WriteLine($"{string.Join(',', effectiveBoost)}");
        var result = 0L;

        for (var i = monsters.Length - 1; i >= 0; i--)
        {
            // Strength needed merely to be allowed to start this fight.
            var strengthToQualify =
                Math.Max(0L, (long)monsters[i] - effectiveBoost[i]);

            // Strength needed to pay for this monster and still have
            // `result` strength for the monsters to its right.
            var strengthToKeepForLater =
                // The == 0 ? 0 here is the trick for the last monster, it only needs minimum to qualify, then the line below will choose strengthToQualify
                result == 0 ? 0 : result + monsters[i];

            result = Math.Max(strengthToQualify, strengthToKeepForLater);
        }

        return result;
    }

    public static TheoryData<int[], int[][], long> TestData => new()
    {
        { [5, 10, 15], [[1, 1, 10]], 30 },
        { [5, 10, 15], [[1, 2, 10], [1, 2, 5]], 5 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] monsters, int[][] boosts, long expected)
    {
        var actual = MinInitialStrength(monsters, boosts);
        Assert.Equal(expected, actual);
    }
}
