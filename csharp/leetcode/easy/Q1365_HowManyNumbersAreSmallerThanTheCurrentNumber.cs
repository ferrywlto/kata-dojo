class Q1365_HowManyNumbersAreSmallerThanTheCurrentNumber
{
    // TC: O(n log n), due to Array.Sort()
    // SC: O(n+m) for the n unique number in dictionary, and m for the copied array
    public int[] SmallerNumbersThanCurrent(int[] nums)
    {
        var dict = new Dictionary<int, int>();
        var copy = new int[nums.Length];
        Array.Copy(nums, copy, nums.Length);
        Array.Sort(copy);
        for(var i=copy.Length-1; i>=1; i--)
        {
            if (copy[i] > copy[i - 1]) 
                dict.TryAdd(copy[i], i);
        }
        for(var j=0; j<nums.Length; j++)
        {
            if (dict.TryGetValue(nums[j], out var count)) 
                nums[j] = count;
            else 
                nums[j] = 0;
        }
        return nums;
    }
}
class Q1365_HowManyNumbersAreSmallerThanTheCurrentNumberTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {8,1,2,2,3}, new int[]{4,0,1,1,3}],
        [new int[] {6,5,4,8}, new int[]{2,1,0,3}],
        [new int[] {7,7,7,7}, new int[]{0,0,0,0}],
    ];
}
public class Q1365_HowManyNumbersAreSmallerThanTheCurrentNumberTests
{
    [Theory]
    [ClassData(typeof(Q1365_HowManyNumbersAreSmallerThanTheCurrentNumberTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q1365_HowManyNumbersAreSmallerThanTheCurrentNumber();
        var actual = sut.SmallerNumbersThanCurrent(input);
        Assert.Equal(expected, actual);
    }
}