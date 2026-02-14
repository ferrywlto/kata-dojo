using System.Numerics;

class Q1356_SortIntegersByNumberOfOneBits
{
    // TC: O(n log n), it iterate each element in arr once then sort each bucket
    // SC: O(n+m), n holds all number of bits of each number, another m for buckets  
    public int[] SortByBits(int[] arr)
    {
        var bits = new Dictionary<int, int>();
        var buckets = new SortedDictionary<int, List<int>>();
        foreach (var num in arr)
        {
            if (!bits.TryGetValue(num, out var numOfBits))
            {
                numOfBits = 0;
                var n = num;
                while (n > 0)
                {
                    if ((n & 1) == 1) numOfBits++;
                    n >>= 1;
                }
                bits.Add(num, numOfBits);
            }
            if (buckets.TryGetValue(numOfBits, out var list)) list.Add(num);
            else buckets.Add(numOfBits, [num]);
        }
        var result = new List<int>();
        foreach (var p in buckets)
        {
            result.AddRange(p.Value.OrderBy(x => x));
        }
        return result.ToArray();
    }
    public int[] SortByBits_OneLiner(int[] arr)
    {
        return arr.OrderBy(num => BitOperations.PopCount((uint)num))
            .ThenBy(num => num)
            .ToArray();
    }
}
class Q1356_SortIntegersByNumberOfOneBitsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{0,1,2,3,4,5,6,7,8}, new int[]{0,1,2,4,8,3,5,6,7}],
        [new int[]{1024,512,256,128,64,32,16,8,4,2,1}, new int[]{1,2,4,8,16,32,64,128,256,512,1024}],
    ];
}
public class Q1356_SortIntegersByNumberOfOneBitsTests
{
    [Theory]
    [ClassData(typeof(Q1356_SortIntegersByNumberOfOneBitsTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1356_SortIntegersByNumberOfOneBits();
        var actual = sut.SortByBits(input);
        Assert.Equal(expected, actual);
    }
}
