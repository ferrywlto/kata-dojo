public class Q3191_MinOpsToMakeBinaryArrayElementsEqualToOneI
{
    // TC: O(n), n sacle with length of nums, worst case 3n
    // SC: O(1), space used does not sacle with input
    /* This can be even faster with flip accounting approach, simulate flip instead of modifying
     The number of 1 in marks equals to total ops needed, the flip variable is used to memorize the odd / even times flipped
     Indices:  0 1 2 3 4 5
     nums:   [0, 1, 1, 1, 0, 0]
     mark:   [1, 1, 0, 1, 0, 0]
     flip:   0
     ops:   3
    */
    public int MinOperations(int[] nums)
    {
        var ops = 0;
        var endIdx = nums.Length - 2;
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                if (i >= endIdx) return -1;
                nums[i] ^= 1;
                nums[i + 1] ^= 1;
                nums[i + 2] ^= 1;
                ops++;
            }
        }
        return ops;
    }
    public int MinOperations_Reference(int[] nums)
    {
        int n = nums.Length, k = 3;
        int ops = 0, flip = 0;
        // mark array tracks whether a flip started at index i (1 if yes, else 0)
        var mark = new int[n];

        // Process the array from left to right
        for (var i = 0; i < n; i++)
        {
            // If our window (of size k) has passed the beginning of a flip, remove its effect.
            if (i >= k)
            {
                flip ^= mark[i - k];
            }

            // Determine the actual state of nums[i] after cumulative flips.
            // (nums[i] XOR flip) will be 0 if an odd number of flips have occurred and 1 otherwise.
            if ((nums[i] ^ flip) == 0) // Need to flip because current bit is 0
            {
                // If there isn’t enough room to flip a block of k bits, return -1.
                if (i > n - k)
                    return -1;

                // Mark that we performed a flip starting at i.
                mark[i] = 1;
                // Toggle the flip effect.
                flip ^= 1;
                ops++;
            }
        }
        return ops;
    }
    public static TheoryData<int[], int> TestData => new()
    {
        {[0,1,1,1,0,0], 3},
        {[0,1,1,1], -1},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}