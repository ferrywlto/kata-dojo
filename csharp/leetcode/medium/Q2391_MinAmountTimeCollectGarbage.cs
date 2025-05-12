public class Q2391_MinAmountTimeCollectGarbage
{
    public int GarbageCollection(string[] garbage, int[] travel)
    {
        var travalledDistanceSinceLastCollect = new int[3];
        var result = garbage[0].Length;
        for(var i=1; i<garbage.Length; i++)
        {
            var travelTime = travel[i-1];
            var bin = garbage[i];
            var binCount = new int[3];
            for(var j=0; j<bin.Length; j++)
            {
                var t = bin[j];
                if(t == 'M') {
                    binCount[0]++;
                }
                else if(t == 'P') {
                    binCount[1]++;
                }
                else {
                    binCount[2]++;
                }
            }
            // handle case that 
            // 1. some houses in between has no bin
            // 2. remaining bin has no that type of garbage
            for(var k=0; k<binCount.Length; k++) {
                travalledDistanceSinceLastCollect[k] += travelTime;
                if(binCount[k] > 0) {
                    result += binCount[k] + travalledDistanceSinceLastCollect[k];
                    travalledDistanceSinceLastCollect[k] = 0;
                }
            }
        }

        return result;
    }
    public static TheoryData<string[], int[], int> TestData => new()
    {
        {["G","P","GP","GG"], [2,4,3], 21},
        // P -> 8
        // G -> 13
        // M -> 0
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