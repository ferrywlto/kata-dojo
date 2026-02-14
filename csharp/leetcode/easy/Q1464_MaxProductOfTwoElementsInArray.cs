class Q1464_MaxProductOfTwoElementsInArray
{
    // TC: O(n), where n is the length of nums
    // SC: O(1), the space used are fixed
    public int MaxProduct(int[] nums)
    {
        var max = int.MinValue;
        var secondMax = int.MinValue;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] > max)
            {
                secondMax = max;
                max = nums[i];
            }
            else if (nums[i] > secondMax)
            {
                secondMax = nums[i];
            }
        }
        return (max - 1) * (secondMax - 1);
    }
}
class Q1464_MaxProductOfTwoElementsInArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {3,4,5,2}, 12],
        [new int[] {1,5,4,5}, 16],
        [new int[] {3,7}, 12],
    ];
}
public class Q1464_MaxProductOfTwoElementsInArrayTests
{
    [Theory]
    [ClassData(typeof(Q1464_MaxProductOfTwoElementsInArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1464_MaxProductOfTwoElementsInArray();
        var actual = sut.MaxProduct(input);
        Assert.Equal(expected, actual);
    }
}
