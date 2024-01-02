public class Q125_ValidPalindromeTestData {}
public class Q125_ValidPalindromeTests {
    [Theory]
    [InlineData(true, "A man, a plan, a canal: Panama")]
    [InlineData(false, "race a car")]
    [InlineData(true, " ")]
    public void OfficialTestCases(bool expected, string input) {
        var sut = new Q125_ValidPalindrome();
        var actual = sut.IsPalindrome(input);
        Assert.Equal(expected, actual);
    }
}

/*
Constraints:

1 <= s.length <= 2 * 105
s consists only of printable ASCII characters.
*/
public class Q125_ValidPalindrome {
    public bool IsPalindrome(string s) {
        return false;
    }
}