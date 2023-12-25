public class Q58_LengthOfLastWordTests {
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("luffy is still joyboy", 6)]
    public void OfficalTestCases(string s, int expected) {
        Assert.Equal(expected, new Q58_LengthOfLastWord().LengthOfLastWord(s));
    }
}

/*
Constraints:

1 <= s.length <= 104
s consists of only English letters and spaces ' '.
There will be at least one word in s.
*/
public class Q58_LengthOfLastWord {
    public int LengthOfLastWord(string s) {
        return 0;
    }
}