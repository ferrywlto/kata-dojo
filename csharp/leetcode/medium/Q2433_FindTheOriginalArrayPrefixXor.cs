public class Q2433_FindTheOriginalArrayPrefixXor
{
    public int[] FindArray(int[] pref)
    {
        return [];
    }
    public static TheoryData<int[], int[]> TestData => new()
  {
    {[5,2,0,3,1], [5,7,2,3,2]},
    {[13], [13]},
  };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = FindArray(input);
        Assert.Equal(expected, actual);
    }
}