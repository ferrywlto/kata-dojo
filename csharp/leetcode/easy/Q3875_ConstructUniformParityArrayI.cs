public class Q3875_ConstructUniformParityArrayI
{
    // TC: O(1)
    // SC: O(1)
#pragma warning disable IDE0060 // Remove unused parameter
    public bool UniformArray(int[] nums1)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        // Properties
        // even - even = even
        // odd - odd = even
        // even - odd = odd

        // Constraints
        // [2,4,5,8,10] true
        // [1,3,6,7,9] true
        // [1,3,6,8,7,9] true
        // [3,4,6,8,10] true
        // if there is at least one odd then all elements can become odd
        // or all even, then the condition is always true.
        return true;
    }

    public static TheoryData<int[], bool> TestData => new() { { [2, 3], true }, { [4, 6], true }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = UniformArray(input);
        Assert.Equal(expected, actual);
    }
}
