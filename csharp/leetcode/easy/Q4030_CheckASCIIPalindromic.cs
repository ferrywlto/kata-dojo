public class Q4030_CheckASCIIPalindromic
{
    // TC: O(n)
    // SC: O(1)
    public bool IsPalindromic(string s)
    {
        for (var i = 0; i < s.Length; i++)
        {
            var endIdx = s.Length - i - 1;
            if (s[i] == 'f' && s[endIdx] == 'f') continue;
            if (s[i] == 'v' && s[endIdx] == 'n') continue;
            if (s[i] == 'n' && s[endIdx] == 'v') continue;
            return false;
        }

        return true;
        // 97 = a - 122 = z
        // only 2 pairs are possible: f and f, v and n or n and v

        // a 0110 0001 = 97  = 1000 0110 x
        // b 0110 0010 = 98  = 0100 0110 x
        // c 0110 0011 = 99  = 1100 0110 x
        // d 0110 0100 = 100 = 0010 0110 x
        // e 0110 0101 = 101 = 1010 0110 x
        // f 0110 0110 = 102 *
        // g 0110 0111 = 103 = 1110 0110 x
        // h 0110 1000 = 104 = 0001 0110 x
        // i 0110 1001 = 105 = 1001 0110 x
        // j 0110 1010 = 106 = 0101 0110 x
        // k 0110 1011 = 107 = 1101 0110 x
        // l 0110 1100 = 108 = 0011 0110 x
        // m 0110 1101 = 109 = 1011 0110 x
        // n 0110 1110 = 110 = 0111 0110 *
        // o 0110 1111 = 111 = 1111 0110 x
        // p 0111 0000 = 112 = 0000 1110 x
        // q 0111 0001 = 113 = 1000 1110 x
        // r 0111 0010 = 114 = 0100 1110 x
        // s 0111 0011 = 115 = 1100 1110 x
        // t 0111 0100 = 116 = 0010 1110 x
        // u 0111 0101 = 117 = 1010 1110 x
        // v 0111 0110 = 118 = 0110 1110 = n
        // w 0111 0111 = 119 = 1110 1110 x
        // x 0111 1000 = 120 = 0001 1110 x
        // y 0111 1001 = 121 = 1001 1110 x
        // z 0111 1010 = 122 = 0101 1110 x
    }

    public static TheoryData<string, bool> TestData => new()
    {
        { "ff", true },
        { "leet", false },
        { "vn", true },
        { "uu", false },
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, bool expected)
    {
        var actual = IsPalindromic(input);
        Assert.Equal(expected, actual);
    }
}
