public class Q2433_FindTheOriginalArrayPrefixXor
{
    // TC: O(n), n scale with length of pref
    // SC: O(1), space used does not scale with input as using in-place replace
    public int[] FindArray(int[] pref)
    {
        var temp = pref[0];
        for (var i = 1; i < pref.Length; i++)
        {
            pref[i] ^= temp;
            temp ^= pref[i];
        }
        return pref;
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