class Q1863_SumOfAllSubsetXORTotal
{
    // TC: O(2^n * n), where n is length of nums, times 2^n for all possible subset combinations  
    // SC: O(1), space used does not scale with input
    public int SubsetXORSum(int[] nums)
    {
        int n = nums.Length;
        int totalSubsets = 1 << n; // 2^n subsets
        int sumTotal = 0;

        // the trick is, the bits pattern from 1 to totalSubsets is unique
        // for each possible bits combination, scan the nums array once,
        // if bit is 1, include the item of bit index from nums 
        for (int i = 0; i < totalSubsets; i++)
        {
            // this is because any N XOR 0 = N
            var sum = 0;
            for (int j = 0; j < n; j++)
            {
                // Check if the j-th bit in i is set
                // 0 means no bit is match, thus != 0
                if ((i & (1 << j)) != 0)
                {
                    sum ^= nums[j];
                }
            }
            sumTotal += sum;
        }
        return sumTotal;
    }
}
class Q1863_SumOfAllSubsetXORTotalTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {1,3}, 6],
        [new int[] {5,1,6}, 28],
        [new int[] {3,4,5,6,7,8}, 480],
        [new int[] {2,4,4}, 24],
    ];
}
public class Q1863_SumOfAllSubsetXORTotalTests
{
    [Theory]
    [ClassData(typeof(Q1863_SumOfAllSubsetXORTotalTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1863_SumOfAllSubsetXORTotal();
        var actual = sut.SubsetXORSum(input);
        Assert.Equal(expected, actual);
    }
}