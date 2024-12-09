public class Q2605_FormSmallestNumberFromTwoDigitArrays
{
    // TC: O(n), n scale with length of nums1 plus length of nums2
    // SC: O(1), space used does not scale with input
    public int MinNumber(int[] nums1, int[] nums2)
    {
        var min1 = int.MaxValue;
        var min2 = int.MaxValue;

        var count = new int[10];
        for (var i = 0; i < nums1.Length; i++)
        {
            if (nums1[i] < min1) min1 = nums1[i];
            count[nums1[i]]++;
        }
        for (var j = 0; j < nums2.Length; j++)
        {
            if (nums2[j] < min2) min2 = nums2[j];
            count[nums2[j]]++;
        }
        for (var k = 0; k < count.Length; k++)
        {
            if (count[k] > 1) return k;
        }

        var larger = Math.Max(min1, min2);
        var smaller = Math.Min(min1, min2);

        return smaller * 10 + larger;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,1,3}, new int[] {5,7}, 15],
        [new int[] {3,5,2,6}, new int[] {3,1,7}, 3],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input1, int[] input2, int expected)
    {
        var actual = MinNumber(input1, input2);
        Assert.Equal(expected, actual);
    }
}