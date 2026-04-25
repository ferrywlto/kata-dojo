public class Q3876_ConstructUniformParityArrayII
{
    // TC: O(n), n scale with length of nums1
    // SC: O(1), space used does not scale with input
    public bool UniformArray(int[] nums1)
    {
        // Properties
        // even - even = even
        // odd - odd = even
        // even - odd = odd

        // Tricks
        // if there is at least one odd then all elements can become odd
        // or all even, then the condition is always true.
        // therefore if the smallest even is larger than smallest odd, then all numbers can become odd.

        var smallestOdd = int.MaxValue;
        var smallestEven = int.MaxValue;
        var oddCount = 0;
        var evenCount = 0;
        foreach (var n in nums1)
        {
            if (n % 2 == 1)
            {
                oddCount++;
                if (n < smallestOdd)
                {
                    smallestOdd = n;
                }
            }
            else
            {
                evenCount++;
                if (n < smallestEven)
                {
                    smallestEven = n;
                }
            }
        }

        if (oddCount == 0 || evenCount == 0) return true;

        return smallestEven > smallestOdd;
    }

    public static TheoryData<int[], bool> TestData =>
        new() { { [1, 4, 7], true }, { [2, 3], false }, { [4, 6], true }, };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = UniformArray(input);
        Assert.Equal(expected, actual);
    }
}
