public class Q2391_MinAmountTimeCollectGarbage
{
    // TC: O(n * m), n scale with length of garbage, m scale with length of travel
    // SC: O(1), space used does not scale with input
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        var result = 0;
        var lastMPicked = false;
        var lastPPicked = false;
        var lastGPicked = false;
        for (var i = garbage.Length - 1; i >= 0; i--)
        {
            var house = garbage[i];
            if (!lastMPicked && house.Contains('M'))
            {
                lastMPicked = true;
                for (var j = 0; j < i; j++) result += travel[j];
            }
            if (!lastGPicked && house.Contains('G'))
            {
                lastGPicked = true;
                for (var j = 0; j < i; j++) result += travel[j];
            }
            if (!lastPPicked && house.Contains('P'))
            {
                lastPPicked = true;
                for (var j = 0; j < i; j++) result += travel[j];
            }
            result += garbage[i].Length;
        }

        return result;
    }
    public static TheoryData<string[], int[], int> TestData => new()
    {
        {["G","P","GP","GG"], [2,4,3], 21},
        {["MMM","PGM","GP"], [3,10], 37},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] house, int[] time, int expected)
    {
        var actual = GarbageCollection(house, time);
        Assert.Equal(expected, actual);
    }
}
