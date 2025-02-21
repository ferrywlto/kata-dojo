public class Q3258_CountSubstringsThatSatisfyKConstraintI
{
    // TC: O(n^3), n^2 for length of s to find all substrings
    // SC: O(1), space used does not scale with input
    public int CountKConstraintSubstrings(string s, int k)
    {
        // if size <= k must satisfy
        // add all combinations from size 1 to k first
        var result = 0;
        var size = s.Length;
        for (var i = 0; i < k; i++)
        {
            result += size;
            size--;
        }
        // then from size k to s.Length check each
        size = k + 1;
        while (size <= s.Length)
        {
            for (var i = 0; i < s.Length - size + 1; i++)
            {
                var substring = s.Substring(i, size);
                if (Satisfy(substring, k)) result++;
            }
            size++;
        }
        return result;
    }
    public bool Satisfy(string input, int k)
    {
        var count = new int[2];
        for (var i = 0; i < input.Length; i++)
        {
            var idx = input[i] - '0';
            count[idx]++;
        }
        return count[0] <= k || count[1] <= k;
    }
    public static TheoryData<string, int, int> TestData => new()
    {
        {"10101", 1, 12},
        {"1010101", 2, 25},
        {"11111", 1, 15},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int k, int expected)
    {
        var actual = CountKConstraintSubstrings(input, k);
        Assert.Equal(expected, actual);
    }
}