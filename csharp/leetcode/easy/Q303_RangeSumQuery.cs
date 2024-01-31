
using System.Diagnostics;

namespace dojo.leetcode;

/* Constraints
1 <= nums.length <= 10^4
-10^5 <= nums[i] <= 10^5
0 <= left <= right < nums.length
At most 10^4 calls will be made to sumRange
*/
public class Q303_RangeSumQuery(int[] nums)
{
    protected readonly int[] Nums = nums;
    protected readonly SortedDictionary<int, SortedDictionary<int, int>> Cache = [];

    // This cache version only faster when half the query hit the cache, there could be even more efficient if the query is not hit, just calculate part and add the rest from cache, but it takes time thus will work on it when have time. 
    public int SumRange(int left, int right)
    {
        if (Cache.TryGetValue(left, out var rightDict))
        {
            if (rightDict.TryGetValue(right, out var cachedSum))
            {
                return cachedSum;
            }
        }

        var sum = SumInclusive(left, right);

        if (!Cache.TryGetValue(left, out SortedDictionary<int, int>? value))
        {
            value = new SortedDictionary<int, int>
            {
                { right, sum }
            };
            Cache.Add(left, value);
        }

        return sum;
    }

    public int SumInclusive(int from, int to)
    {
        var sum = 0;
        for (var i = from; i <= to; i++)
        {
            sum += Nums[i];
        }
        return sum;
    }

    public int SumRange_Slow(int left, int right)
    {
        var sum = 0;
        for (var i = left; i <= right; i++)
        {
            sum += Nums[i];
        }
        return sum;
    }
}

public class Q303_RangeSumQueryTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{-2, 0, 3, -5, 2, -1}, 0, 2, 1],
        [new int[]{-2, 0, 3, -5, 2, -1}, 2, 5, -1],
        [new int[]{-2, 0, 3, -5, 2, -1}, 0, 5, -3],
    ];
}

public class Q303_RangeSumQueryTests
{
    [Theory]
    [ClassData(typeof(Q303_RangeSumQueryTestData))]
    public void OfficialTestCases(int[] input, int left, int right, int expected)
    {
        var sut = new Q303_RangeSumQuery(input);
        var actual = sut.SumRange(left, right);
        Assert.Equal(expected, actual);

        var slow = sut.SumRange_Slow(left, right);
        Assert.Equal(expected, slow);
    }
}

public class Q303_RangeSumQueryStressTests(ITestOutputHelper output)
{
    [Fact(Skip = "Time consuming benchmarking, run only when explicit specifiied")]
    public void SumRange_ShouldRunMuchFasterWithCache()
    {
        // Arrange test data
        var random = new Random();
        var input = Enumerable.Repeat(0, 10000).ToArray();
        for(var i = 0; i<input.Length; i++)
        {
            input[i] = random.Next(100000);
        }
        var list = new List<(int, int)>();
        const int timesToRun = 10000;
        const int batch = 5000;
        var batchSize = timesToRun / batch;

        for (var i=0; i<batch; i++)
        {
            var rndStart = random.Next(input.Length-1);
            var rndEnd = random.Next(input.Length-1);
            var entry = (Math.Min(rndStart, rndEnd), Math.Max(rndStart, rndEnd));
             
            for(var j=0; j<batchSize; j++)
                list.Add(entry);            
        }

        var sut = new Q303_RangeSumQuery(input);

        var timePassedFast = Benchmark(list, sut.SumRange);
        output.WriteLine($"Fast: {timePassedFast}");

        var timePassedSlow = Benchmark(list, sut.SumRange_Slow);
        output.WriteLine($"Slow: {timePassedSlow}");

        Assert.True(timePassedFast < timePassedSlow);
    }

    private double Benchmark(IEnumerable<(int, int)> input, Func<int, int, int> sumFunc) {
        Stopwatch.StartNew();
        var timeStart = Stopwatch.GetTimestamp();
        foreach (var d in input)
        {
            _ = sumFunc(d.Item1, d.Item2);
        } 
        var timePassed = Stopwatch.GetElapsedTime(timeStart);
        return timePassed.TotalSeconds;
    }
}