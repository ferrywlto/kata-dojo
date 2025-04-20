public class Q3507_MinPairRemovalToSortArrayI
{
    // TC: O(n^2), n scale with length of nums
    // SC: O(n), for the list used to create a new array
    public int MinimumPairRemoval(int[] nums)
    {
        var removeCount = 0;
        while (!IsSorted(nums))
        {
            var pairInfo = FindMinPair(nums);
            var list = new List<int>();

            for (var i = 0; i < nums.Length; i++)
            {
                if (i == pairInfo[2])
                {
                    list.Add(pairInfo[0]);
                    i += 1;
                    removeCount++;
                }
                else list.Add(nums[i]);
            }
            nums = list.ToArray();
        }
        return removeCount;
    }
    private int[] FindMinPair(int[] input)
    {
        var min = int.MaxValue;
        var result = new int[3];

        for (var i = 1; i < input.Length; i++)
        {
            var sum = input[i] + input[i - 1];
            if (sum < min)
            {
                min = sum;
                result[0] = min;
                result[1] = i;
                result[2] = i - 1;
            }
        }
        return result;
    }
    private bool IsSorted(int[] input)
    {
        for (var i = 1; i < input.Length; i++)
        {
            if (input[i] < input[i - 1]) return false;
        }
        return true;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[5,2,3,1], 2},
        {[1,2,2], 0},
        {[2,2,-1,3,-2,2,1,1,1,0,-1], 9},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinimumPairRemoval(input);
        Assert.Equal(expected, actual);
    }
}