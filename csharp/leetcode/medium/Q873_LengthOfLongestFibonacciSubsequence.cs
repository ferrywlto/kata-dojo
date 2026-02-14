public class Q873_LengthOfLongestFibonacciSubsequence
{
    // It can be solved by dynamic programming and memorization, but I leave it for future.
    // TC: O(n^2 * log n), n scale with length of arr
    // SC: O(1), space used does not scale with input 
    public int LenLongestFibSubseq(int[] arr)
    {
        var maxLen = 0;
        for (var i = 0; i < arr.Length - 2; i++)
        {
            for (var j = i + 1; j < arr.Length - 1; j++)
            {
                var len = 0;
                var last = arr[j];
                var secondLast = arr[i];
                var targetIdx = Array.BinarySearch(arr, j + 1, arr.Length - j - 1, last + secondLast);
                if (targetIdx >= 0)
                {
                    len = 3;
                    while (targetIdx >= 0)
                    {
                        secondLast = last;
                        last = arr[targetIdx];
                        targetIdx = Array.BinarySearch(arr, targetIdx + 1, arr.Length - targetIdx - 1, last + secondLast);
                        if (targetIdx >= 0) len++;
                    }
                }
                if (len > maxLen) maxLen = len;
            }
        }
        return maxLen;
    }

    public static TheoryData<int[], int> TestData => new()
    {
        {[1,2,3,4,5,6,7,8], 5},
        {[1,3,7,11,12,14,18], 3},
        {[2,4,7,8,9,10,14,15,18,23,32,50], 5},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] arr, int expected)
    {
        var actual = LenLongestFibSubseq(arr);
        Assert.Equal(expected, actual);
    }
}
