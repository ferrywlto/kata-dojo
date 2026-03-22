public class Q3875_ConstructUniformParityArrayI
{
    public bool UniformArray(int[] nums1)
    {
        return false;
    }

    public static TheoryData<int[], bool> TestData => new() { { [2, 3], true }, { [4, 6], false }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = UniformArray(input);
        Assert.Equal(expected, actual);
    }
}
