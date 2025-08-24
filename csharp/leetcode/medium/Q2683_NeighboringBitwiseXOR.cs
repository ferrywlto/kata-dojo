public class Q2683_NeighboringBitwiseXOR
{
    public bool DoesValidArrayExist(int[] derived)
    {
        return false;
    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1,1,0], true},
        {[1,1], true},
        {[1,0], false},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = DoesValidArrayExist(input);
        Assert.Equal(expected, actual);
    }
}
