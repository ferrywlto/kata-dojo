namespace dojo.leetcode;

public class Q338_CountingBits
{
    // Provided by Copilot, use fewer memory and loop less
    public int[] CountBits_Faster(int n)
    {
        var head = new List<int> { 0, 1 };
        
        while(head.Count <= n)
        {
            var count = head.Count;
            // The && head.Count <= n is to stop the loop once it hit n, better than mine which create the expansion then shrink
            for(int i = 0; i < count && head.Count <= n; i++)
            {
                head.Add(head[i] + 1);
            }
        }
        return head.ToArray();
    }

    // TC:O(n), SC:O(n)
    public int[] CountBits(int n)
    {
        var num = n;
        var head = new List<int> { 0, 1 };
        
        List<int> temp = [1];
        while(num > 0)
        {
            temp = ReplicateThenExpand(temp);
            head.AddRange(temp);
            num /= 2;
        }
        var result = head[..(n+1)];
        return [.. result];
    }

    // This method is to get the bit sequence, it is observed that the binary bit sequence have the pattern below
    // For each power of 2 the bit sequence of 1s will repeat the sequence of previous power of 2, then repeat again with each plus 1
    // Thus: number of ones in bits (actual number) 
    // 2^0 = 1 (1)
    // 2^1 = 1 (2), 2 (3) -> repeat 1, then repeat with plus one get 2 -> 1,2
    // 2^2 = 1 (4), 2 (5), 2 (6), 3 (7) -> repeat last power of 2, 1,2, then repeat again with each plus one, get 2,3 -> 1, 2, 2, 3
    // 2^3 = 1 (8), 2 (9), 2 (10), 3 (11), 2 (12), 3 (13), 3 (14), 4 (15) -> repeat 1,2,2,3 then repeat with each plus one get 2,3,3,4 -> 1,2,2,3,2,3,3,4
    // and so on.  
    public List<int> ReplicateThenExpand(List<int> nums)
    {
        var output = new List<int>();
        output.AddRange(nums);
        output.AddRange(nums.Select(x => x + 1));
        return output;
    }
}

public class Q338_CountingBitsTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [2, new int[] {0,1,1}],
        [5, new int[] {0,1,1,2,1,2}],
        [8, new int[] {0,1,1,2,1,2,2,3,1}],
    ];
}

public class Q338_CountingBitsTests
{
    [Theory]
    [ClassData(typeof(Q338_CountingBitsTestData))]
    public void OfficialTestCases(int input, int[] expected)
    {
        var sut = new Q338_CountingBits();
        var actual = sut.CountBits(input);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }

    [Theory]
    [ClassData(typeof(Q338_CountingBitsExtraTestData))]
    public void ReplicateThenExpand_ShouldCopyInput_AndCopyAgainWithPlusOne(List<int> input, List<int> expected)
    {
        var sut = new Q338_CountingBits();
        var actual = sut.ReplicateThenExpand(input);
        Assert.True(Enumerable.SequenceEqual(expected, actual));
    }
}

public class Q338_CountingBitsExtraTestData: TestData
{
    protected override List<object[]> Data => 
    [
        [new List<int>{1}, new List<int>{1,2}],
        [new List<int>{1,2}, new List<int>{1,2,2,3}],
        [new List<int>{1,2,2,3}, new List<int>{1,2,2,3,2,3,3,4}],
    ];
}