// for any Palindrome questions, first think of S + S

public class Q4021_MinOpsToMakeRotatedPalindromeI
{
    // TC: O(n^2), need to calculate all right rotation combination to find the smallest possible value
    // SC: O(n), 2n for buffer, n for cache
    public int MinOperations(string s)
    {
        var minResult = int.MaxValue;
        var len = s.Length;

        // Duplicate input into stack buffer
        Span<char> buffer = stackalloc char[len + len];
        for (int i = 0; i < len; i++)
        {
            buffer[i] = s[i];
            buffer[i + len] = s[i];
        }

        // avoid repeated calculation by checking if the string has been calculated before
        var cache = new HashSet<string>();

        // sliding window loop through all combinations
        for (var i = 0; i < len; i++)
        {
            var str = buffer[i..(i + len)].ToString();
            if (cache.Contains(str)) continue;

            var result = 0;
            for (var startIdx = 0; startIdx < str.Length / 2; startIdx++)
            {
                var endIdx = str.Length - 1 - startIdx;
                if (str[startIdx] >= str[endIdx])
                    result += Math.Min(str[startIdx] - str[endIdx], str[endIdx] + 26 - str[startIdx]);
                else
                    result += Math.Min(str[endIdx] - str[startIdx], str[startIdx] + 26 - str[endIdx]);
            }

            result += i;
            cache.Add(str);
            if (result < minResult) minResult = result;
        }

        return minResult;
    }

    public static TheoryData<string, int> TestData => new()
    {
        { "abc", 2 },
        { "yb", 3 },
        { "xl", 12 },
        { "krk", 0 },
        { "uhj", 4 },
        { "cz", 3 }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinOperations(input);
        Assert.Equal(expected, actual);
    }
}
