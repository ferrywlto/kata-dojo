public class Q3718_SmallestMissingMultipleOfK
{
    // TC: O(n), n scale with length of nums
    // SC: O(m), m scale with max divisible number
    public int MissingMultiple(int[] nums, int k)
    {
        var divisible = new List<int>();
        var max = 0;
        foreach (var num in nums)
        {
            if (num % k == 0)
            {
                divisible.Add(num);
                if (num > max)
                {
                    max = num;
                }
            }
        }

        var exists = new int[max + 1];
        foreach (var num in divisible)
        {
            exists[num] = 1;
        }

        for (var i = k; i <= max; i += k)
        {
            if (exists[i] == 0)
            {
                return i;
            }
        }
        return ((max / k) + 1) * k;
    }

    public static TheoryData<int[], int, int> TestData => new()
    {
        {[50], 7, 7},
        {[8,2,3,4,6], 2, 10},
        {[1,4,7,10,15], 5, 5},
        {[42,13,99,13,71,32,64,32,63,44,6,22,8,2,55,88,43,40,71,80,95,32,46,19], 44, 132},
        {[1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100], 1, 101},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] nums, int k, int expected)
    {
        var result = MissingMultiple(nums, k);
        Assert.Equal(expected, result);
    }
}
