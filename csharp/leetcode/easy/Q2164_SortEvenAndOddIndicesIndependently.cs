public class Q2164_SortEvenAndOddIndicesIndependently
{
    // TC: O(n log n), n scale with length of num, because of 2 Array.Sort
    // n for distribute to 2 arrays, 2* n log n for Sort, n for update nums
    // 2n + 2(n log n) => n log n
    // SC: O(n), n scale with length of num, the total space used in two arrays equals length of num 
    public int[] SortEvenOdd(int[] nums)
    {
        if (nums.Length <= 2) return nums;

        var len = nums.Length / 2;
        var oddsLen = len;
        if (nums.Length % 2 == 1) oddsLen++;
        var odds = new int[len];
        var even = new int[oddsLen];

        for (var i = 0; i < odds.Length; i++)
        {
            odds[i] = nums[(2 * i) + 1];
        }
        for (var i = 0; i < even.Length; i++)
        {
            even[i] = nums[2 * i];
        }
        Array.Sort(odds);
        odds = odds.Reverse().ToArray();
        Array.Sort(even);

        for (var i = 0; i < nums.Length; i++)
        {
            var targetIdx = i / 2;
            nums[i] = i % 2 == 0
                ? even[targetIdx]
                : odds[targetIdx];
        }
        return nums;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {4,1,2,3,5}, new int[] {2,3,4,1,5}],
        [new int[] {4,1,2,3}, new int[] {2,3,4,1}],
        [new int[] {4,1,2}, new int[] {2,1,4}],
        [new int[] {2,1}, new int[] {2,1}],
        [new int[] {1}, new int[] {1}],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = SortEvenOdd(input);
        Assert.Equal(expected, actual);
    }
}
