
namespace dojo.leetcode;

public abstract class Kthlargest 
{
    public Kthlargest(int k, int[] nums) {}

    public abstract int Add(int val);
}

public class Q703_KthLargestElementInStream : Kthlargest
{
    protected readonly int _k;
    protected readonly int[] _nums;
    public Q703_KthLargestElementInStream(int k, int[] nums) : base(k, nums)
    {
        _k = k;
        _nums = nums;
    }

    public override int Add(int val)
    {
        return 0;
    }
}

public class Q703_KthLargestElementInStreamTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [3, new int[] {4, 5, 6, 2}, new int[]{3, 5, 10, 9, 4}, new int?[] {null, 4, 5, 5, 8, 8}],
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