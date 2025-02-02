public class Q3069_DistributeElementsIntoTwoArraysI
{
    // TC: O(n), n scale with length of nums
    // SC: O(n), same as time
    public int[] ResultArray(int[] nums)
    {
        var list1 = new List<int> { nums[0] };
        var list2 = new List<int> { nums[1] };
        for (var i = 2; i < nums.Length; i++)
        {
            if (list1[^1] > list2[^1]) list1.Add(nums[i]);
            else list2.Add(nums[i]);
        }

        list1.AddRange(list2);
        return list1.ToArray();
    }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[2,1,3], [2,3,1]},
        {[5,4,3,8], [5,3,4,8]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = ResultArray(input);
        Assert.Equal(expected, actual);
    }
}