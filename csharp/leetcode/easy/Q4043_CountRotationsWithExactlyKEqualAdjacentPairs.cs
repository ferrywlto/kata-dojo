public class Q4043_CountRotationsWithExactlyKEqualAdjacentPairs
{
    // TC: O(n)
    // SC: O(1)
    public int CountRotations(string s, int k)
    {
        var len = s.Length - 1;
        var result = 0;
        var score = 0;

        // handle the score of no rotation
        for (var i = 0; i < len; i++)
        {
            if (s[i] == s[i + 1]) score++;
        }

        if (score == k) result++;

        for (var i = 0; i < len; i++)
        {
            if (s[i] == s[i + 1]) score--;

            // Using modulus two-pointers can save time from accessing string builder. Save also space.
            if (s[(i + len) % s.Length] == s[(i + len + 1) % s.Length]) score++;

            if (score == k) result++;
        }

        return result;
    }

    public static TheoryData<string, int, int> TestData => new()
    {
        { "aab", 1, 2 },
        { "abca", 0, 1 },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int n, int expected)
    {
        var actual = CountRotations(input, n);
        Assert.Equal(expected, actual);
    }
}
