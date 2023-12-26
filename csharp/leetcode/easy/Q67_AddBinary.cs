public class Q67_AddBinaryTests {
    [Theory]
    [InlineData("11", "1", "100")]
    [InlineData("1010", "1011", "10101")]
    public void OfficialTestCases(string a, string b, string expected) {
        var sut = new Q67_AddBinary();
        Assert.Equal(expected, sut.AddBinary(a, b));
    }
}

/*
Constraints:

1 <= a.length, b.length <= 104
a and b consist only of '0' or '1' characters.
Each string does not contain leading zeros except for the zero itself.
*/
public class Q67_AddBinary {
    public string AddBinary(string a, string b) {
        return string.Empty;
    }
}