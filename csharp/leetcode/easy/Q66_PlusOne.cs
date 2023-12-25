public class Q66_PlusOneTests {
    [Theory]
    [InlineData(new int[] { 1, 2, 3 }, new int[] { 1, 2, 4 })]
    [InlineData(new int[] { 4, 3, 2, 1 }, new int[] { 4, 3, 2, 2 })]
    [InlineData(new int[] { 9 }, new int[] { 1, 0 })]
    public void OfficalTestCases(int[] input, int[] expected) {
        var solution = new Q66_PlusOne();
        var result = solution.PlusOne(input);
        Assert.Equal(expected, result);
    }
}

public class Q66_PlusOne {
    public int[] PlusOne(int[] input) {
        return [];
    }
}