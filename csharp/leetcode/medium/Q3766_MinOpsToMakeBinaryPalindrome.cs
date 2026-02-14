public class Q3766_MinOpsToMakeBinaryPalindrome
{
    // TC: O(n log n), each item in nums needs log n for binary search time. This is a bit cheating to generate all known binary palindromes from 1 to 5000 but the hints say so.
    // SC: O(1), modify the input in-place as result.
    private static readonly int[] palindromes = [
        1, 3, 5, 7, 9, 15, 17, 21, 27, 31, 33, 45, 51, 63, 65, 73, 85, 93, 99, 107, 119, 127, 129, 153, 165, 189, 195, 219, 231, 255, 257, 273, 297, 313, 325,
        341, 365, 381, 387, 403, 427, 443, 455, 471, 495, 511, 513, 561, 585, 633, 645, 693, 717, 765, 771, 819, 843, 891, 903, 951, 975, 1023, 1025, 1057, 1105,
        1137, 1161, 1193, 1241, 1273, 1285, 1317, 1365, 1397, 1421, 1453, 1501, 1533, 1539, 1571, 1619, 1651, 1675, 1707, 1755, 1787, 1799, 1831, 1879, 1911, 1935,
        1967, 2015, 2047, 2049, 2145, 2193, 2289, 2313, 2409, 2457, 2553, 2565, 2661, 2709, 2805, 2829, 2925, 2973, 3069, 3075, 3171, 3219, 3315, 3339, 3435, 3483,
        3579, 3591, 3687, 3735, 3831, 3855, 3951, 3999, 4095, 4097, 4161, 4257, 4321, 4369, 4433, 4529, 4593, 4617, 4681, 4777, 4841, 4889, 4953
    ];

    public int[] MinOperations(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            var idx = Array.BinarySearch(palindromes, nums[i]);

            if (idx < 0)
            {
                var actualIdx = ~idx;
                if (actualIdx == 0)
                {
                    nums[i] = palindromes[actualIdx] - nums[i];
                }
                else if (actualIdx == palindromes.Length)
                {
                    nums[i] = nums[i] - palindromes[actualIdx - 1];
                }
                else
                {
                    nums[i] = Math.Min(
                        palindromes[actualIdx] - nums[i],
                        Math.Abs(palindromes[actualIdx - 1] - nums[i])
                    );
                }
            }
            else
            {
                nums[i] = 0;
            }
        }

        return nums;
    }

    // Save for future reference
    // private bool IsBinaryPalindrome(int input)
    // {
    //     var list = new List<int>();
    //     while (input > 0)
    //     {
    //         list.Add(input % 2);
    //         input >>= 1;
    //     }

    //     for (var i = 0; i < list.Count; i++)
    //     {
    //         if (list[i] != list[list.Count - 1 - i])
    //         {
    //             return false;
    //         }
    //     }
    //     return true;
    // }
    public static TheoryData<int[], int[]> TestData => new()
    {
        {[1,2,4], [0,1,1]},
        {[6,7,12], [1,0,3]},
        {[1624], [5]},
        {[1049,4972], [8,19]},
        //1 1 o 
        //3 11 o
        //5 101 o 0
        //7 111 o 1
        //9 1001 o 00
        //15 1111 o 11
        //17 10001 o  000
        //21 10101 o  010
        //27 11011 o  101
        //31 11111 o  111
        //33 100001 o 0000
        //45 101101 o 0110
        //51 110011 o 1001
        //55 110111
        //63 111111 o 1111
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int[] expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}
