public class Q58_LengthOfLastWordTests {
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    [InlineData("day", 3)]
    [InlineData("day    ", 3)]
    public void OfficalTestCases(string s, int expected) {
        Assert.Equal(expected, new Q58_LengthOfLastWord().LengthOfLastWord_CharByChar(s));
    }

    [Fact]
    public void Nothing() {
        var str = "   fly me   to   the moon  ";
        var arr = str.Split(' ');
        Console.WriteLine(arr.Length);
        foreach (var item in arr) {
            Console.WriteLine(item);
        }
        var last = arr.Where(x => !x.Equals(string.Empty)).ToArray()[^1];
        Console.WriteLine(last.Length);
    }
}

/*
Constraints:

1 <= s.length <= 104
s consists of only English letters and spaces ' '.
There will be at least one word in s.
*/
public class Q58_LengthOfLastWord {
    // Straight forward appraoch with built-in functions
    // Speed: 46ms (96.51%), Memory: 37.96MB (5.04%)
    public int LengthOfLastWord(string s) {
        return s.Split(' ')
        .Where(x => !x.Equals(string.Empty))
        .ToArray()[^1].Length;
    }

    // Instead of using built-in functions, search from the end char by char
    // First get the last index of non-space char, then get the last index of space char
    // What in betwwen is a word
    // Speed: 40ms (99.31%), Memory: 37.67MB (5.67%)
    public int LengthOfLastWord_CharByChar(string s) {
        int end = s.Length - 1;
        for (int i = end; i >= 0; i--) {
            if (s[i] != ' ') {
                end = i;
                break;
            }
        }
        int start = 0;
        for (int i = end; i >= 0; i--) {
            if (s[i] == ' ') {
                start = i + 1;
                break;
            }
        }
        return end - start + 1;
    }
}