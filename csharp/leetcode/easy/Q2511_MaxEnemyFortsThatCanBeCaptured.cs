public class Q2511_MaxEnemyFortsThatCanBeCaptured
{
    // TC: O(n^2), for each 1 found, search n-1 items worst case for both directions
    // SC: O(n), n scale with 1 in forts
    public int CaptureForts(int[] forts)
    {
        var startIndexes = new List<int>();

        for (var i = 0; i < forts.Length; i++)
        {
            if (forts[i] == 1) startIndexes.Add(i);
        }
        if (startIndexes.Count == 0) return 0;

        var maxForts = int.MinValue;
        foreach (var idx in startIndexes)
        {
            var fortsCaptured = Math.Max(SearchForward(forts, idx), SearchBackward(forts, idx));
            if (fortsCaptured > maxForts)
                maxForts = fortsCaptured;
        }

        return maxForts;
    }
    public int SearchForward(int[] input, int startIdx)
    {
        var result = 0;
        for (var i = startIdx + 1; i < input.Length; i++)
        {
            if (input[i] == 0) result++;
            else if (input[i] == 1) return 0;
            else if (input[i] == -1) return result;
        }
        return 0;
    }
    public int SearchBackward(int[] input, int startIdx)
    {
        var result = 0;
        for (var i = startIdx - 1; i >= 0; i--)
        {
            if (input[i] == 0) result++;
            else if (input[i] == 1) return 0;
            else if (input[i] == -1) return result;
        }
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,0,0,-1,0,0,0,0,1}, 4],
        [new int[] {-1,-1,0,1,0,0,1,-1,1,0}, 1],
        [new int[] {0,0,1,0,1,1}, 0],
        [new int[] {0,0,1,-1}, 0],
        [new int[] {0,0,0,-1}, 0],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CaptureForts(input);
        Assert.Equal(expected, actual);
    }
}

