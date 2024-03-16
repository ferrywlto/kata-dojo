
namespace dojo.leetcode;

public abstract class Kthlargest 
{
    public Kthlargest(int k, int[] nums) {}

    public abstract int Add(int val);
}

public class Q703_KthLargestElementInStream : Kthlargest
{
    protected readonly int targetRank;
    protected readonly List<int> _nums = [];
    public Q703_KthLargestElementInStream(int k, int[] nums) : base(k, nums)
    {
        targetRank = k;
        _nums.AddRange(nums);
    }

    public override int Add(int val)
    {
        _nums.Add(val);
        _nums.Sort();
        var largestK = _nums.TakeLast(targetRank);
        return largestK.First();
    }
}

public class Q703_KthLargestElementInStreamTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [3, new int[] {4, 5, 8, 2}, new int[]{3, 5, 10, 9, 4}, new int?[] {null, 4, 5, 5, 8, 8}],
    ];
}

public class Q703_KthLargestElementInStreamTests
{
    [Theory]
    [ClassData(typeof(Q703_KthLargestElementInStreamTestData))]
    public void OfficialTestCases(int targetRank, int[] input, int[] ops, int?[] expected)
    {
        var sut = new Q703_KthLargestElementInStream(targetRank, input);
        var actual = new int?[expected.Length];
        actual[0] = null;
        for(var i=0; i<ops.Length; i++)
        {
            actual[i+1] = sut.Add(ops[i]);
        }
        Assert.Equal(expected, actual);
    }
}