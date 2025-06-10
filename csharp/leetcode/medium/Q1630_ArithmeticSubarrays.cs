public class Q1630_ArithmeticSubarrays
{
    public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
    {
        return [];
    }
    public static TheoryData<int[], int[], int[], bool[]> TestData => new()
    {
        {[4,6,5,9,3,7], [0,0,2], [2,3,5], [true,false,true]},
        {[-12,-9,-3,-12,-6,15,20,-25,-20,-15,-10], [0,1,6,4,8,7], [4,4,9,7,9,10], [false,true,false,false,true,true]},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] n, int[] l, int[] r, bool[] expected)
    {
        var actual = CheckArithmeticSubarrays(n, l, r);
        Assert.Equal(expected, actual);
    }
}