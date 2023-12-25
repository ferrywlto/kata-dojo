public class Q58_LengthOfLastWordTests {
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    public void OfficalTestCases(string s, int expected) {
        Assert.Equal(expected, new Q58_LengthOfLastWord().LengthOfLastWord(s));
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
}