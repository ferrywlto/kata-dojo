public class Q69_SqrtTests {
    [Theory]
    [InlineData(4, 2)]
    [InlineData(8, 2)]
    public void OfficialTestCases(int input, int expected) {
        var sut = new Q69_Sqrt();
        Assert.Equal(expected, sut.MySqrt(input));
    }
}

public class Q69_Sqrt {
    public int MySqrt(int x) {
        return 0;
    }
}