public class Q1995_CountSpecialQuadruplets
{
    // TC: O(n^4), n scale with length of nums, n(n-1)(n-2)(n-3) thus n^4
    // SC: O(m), m scale with unique index combinations in nums 
    public int CountQuadruplets(int[] nums)
    {
        var existed = new HashSet<string>();
        for (var i = nums.Length - 1; i >= 3; i--)
        {
            var d = nums[i];
            for (var j = i - 1; j >= 2; j--)
            {
                var c = nums[j];
                for (var k = j - 1; k >= 1; k--)
                {
                    var b = nums[k];
                    for (var m = k - 1; m >= 0; m--)
                    {
                        var a = nums[m];
                        if (a + b + c == d) existed.Add(string.Join("", new int[] { m, k, j, i }));
                    }
                }
            }
        }
        return existed.Count;
    }
    public static List<object[]> TestData =>
    [
        [new int[] {1,2,3,6}, 1],
        [new int[] {3,3,6,4,5}, 0],
        [new int[] {1,1,1,3,5}, 4],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, int expected)
    {
        var actual = CountQuadruplets(input);
        Assert.Equal(expected, actual);
    }
}