public class Q3014_MinNumberOfPushesToTypeWordI
{
    public int MinimumPushes(string word)
    {
        // 26 chars / 8 keys
        // 24 chars / each key has 3
        // 6 keys contains 3, 2 keys contains 4
        // < 8 = x
        // < 16 = 8 + 2 * x % 8
        // < 24 = 8 + 2 * 8 + 3 * x
        // > 24 = 8 + 2 * 8 + 3 * 8 + 4 * n
        var len = word.Length;
        var result = 0;
        if (len < 8) return len;

        if(len > 24) {
            result += (len - 24) * 4;
            len -= 8;
        }
        if(len > 16) {
            result += (len - 16) * 3;
            len -= 8;
        }
        if(len > 8) {
            result += (len - 8) * 2;
            len -= 8;
        }
        Console.WriteLine("{0}, {1}", word.Length, len);

        return result + len;
    }
    public static TheoryData<string, int> TestData => new()
    {
        {"abcde", 5},
        {"xycdefghij", 12},
        {"abhrlngxyjkezwcm", 24},
        {"abhrlngxyjkezwcmd", 27},
        {"abhrlngxyjkezwcmdyjkezwcm", 48},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string input, int expected)
    {
        var actual = MinimumPushes(input);
        Assert.Equal(expected, actual);
    }
}