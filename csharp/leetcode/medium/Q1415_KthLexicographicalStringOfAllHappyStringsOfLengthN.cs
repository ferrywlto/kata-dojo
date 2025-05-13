using System.Text;

public class Q1415_KthLexicographicalStringOfAllHappyStringsOfLengthN
{
    Dictionary<char, char[]> map = new()
    {
        {'a', ['b', 'c']},
        {'b', ['a', 'c']},
        {'c', ['a', 'b']},
    };
    // TC: O(n)
    // SC: O(n), for string builder
    // It can be even faster to not using Convert.ToString and not using dictionary, but this solution is easier to understand while fast enough
    // encoding
    // a 0 0 => 0
    // a 0 1 => 1
    // a 1 0 => 2
    // a 1 1 => 3
    // b 0 0 => 4
    // b 0 1 => 5 
    // b 1 0 => 6
    // b 1 1 => 7
    // c 0 0 => 8
    // c 0 1 => 9
    // c 1 0 => 10
    // c 1 1 => 11
    // the pattern is 3 * 2^(n-1) combinations, knowing the first layer starting character, we can use the binary string to encode the remaining string 
    public string GetHappyString(int n, int k)
    {
        var leafGroupSize = (int)Math.Pow(2, n - 1);
        if (k > leafGroupSize * 3) return string.Empty;

        var idx = k - 1;
        var groupIdx = idx / leafGroupSize;
        if (groupIdx > 2) return string.Empty;

        var currentChar = (char)('a' + groupIdx);
        var sb = new StringBuilder();
        sb.Append(currentChar);

        if (n > 1)
        {
            var idxWithinGrp = idx % leafGroupSize;
            var binaryStr = Convert.ToString(idxWithinGrp, 2).PadLeft(n - 1, '0');
            for (var i = 0; i < binaryStr.Length; i++)
            {
                currentChar = map[currentChar][binaryStr[i] - '0'];
                sb.Append(currentChar.ToString());
            }
        }
        return sb.ToString();
    }

    public static TheoryData<int, int, string> TestData => new()
    {
        {1, 3, "c"},
        {1, 4, ""},
        {3, 9, "cab"},
        {3, 8, "bcb"},
        {10, 100, "abacbabacb"},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input1, int input2, string expected)
    {
        var actual = GetHappyString(input1, input2);
        Assert.Equal(expected, actual);
    }
}