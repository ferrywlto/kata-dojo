public abstract class Kthlargest 
{
    public Kthlargest(int k, int[] nums) {}

    public abstract int Add(int val);
}

public class Q703_KthLargestElementInStream : Kthlargest
{
    protected readonly int targetRank;
    protected List<int> list = [];
    // TC: O(log n)
    // SC: O(n)
    public Q703_KthLargestElementInStream(int k, int[] nums) : base(k, nums)
    {
        targetRank = k;
        Array.Sort(nums);
        list.AddRange(nums);
    }

    public override int Add(int val)
    {
        BinaryAdd(val);
        return list[^targetRank];
    }

    public void BinaryAdd(int val)
    {
        if (list.Count == 0 || val > list[^1])
        {
            list.Add(val);
            return;
        } 
        else if (val < list[0])
        {
            list.Insert(0, val);
            return;
        }

        var left = 0;
        var right = list.Count - 1;
        while(right - left > 1)
        {
            var middle = (right + left) / 2;
            if(val > list[middle])
            {
                left = middle;
            }
            else if (val < list[middle])
            {
                right = middle;
            }
            else 
            {
                list.Insert(middle + 1, val);
                return;
            }
        }
        list.Insert(left + 1, val);
    }
}

public class Q703_KthLargestElementInStreamTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [3, new int[] {4, 5, 8, 2}, new int[]{3, 5, 10, 9, 4}, new int?[] {null, 4, 5, 5, 8, 8}],
        [1, Array.Empty<int>(), new int[]{-3, -2, -4, 0, 4}, new int?[] {null, -3, -2, -2, 0, 4}],
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