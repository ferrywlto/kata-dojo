class Q1822_SignOfProductOfArray
{
    // TC: O(n), where n is length of nums
    // SC: O(1), space use is fixed
    public int ArraySign(int[] nums)
    {
        return product(nums);
    }
    public int product(int[] input)
    {
        var negativeCount = 0;
        for (var i = 0; i < input.Length; i++)
        {
            if (input[i] == 0) return 0;
            if (input[i] < 0) negativeCount++;
        }
        return negativeCount % 2 == 0 ? 1 : -1;
    }
}
class Q1822_SignOfProductOfArrayTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {-1,-2,-3,-4,3,2,1}, 1],
        [new int[] {1,5,0,2,-3}, 0],
        [new int[] {-1,1,-1,1,-1}, -1],
        [new int[] {41,65,14,80,20,10,55,58,24,56,28,86,96,10,3,84,4,41,13,32,42,43,83,78,82,70,15,-41}, -1],
    ];
}
public class Q1822_SignOfProductOfArrayTests
{
    [Theory]
    [ClassData(typeof(Q1822_SignOfProductOfArrayTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1822_SignOfProductOfArray();
        var actual = sut.ArraySign(input);
        Assert.Equal(expected, actual);
    }
}
