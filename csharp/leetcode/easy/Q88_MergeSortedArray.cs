using System;

public class Q88_MergeSortedArrayTests {
    [Theory]
    [InlineData(new int[]{1,2,3,0,0,0}, 3, new int[]{2,5,6}, 3, new int[]{1,2,2,3,5,6})]
    [InlineData(new int[]{1}, 1, new int[]{}, 0, new int[]{1})]
    [InlineData(new int[]{0}, 0, new int[]{1}, 1, new int[]{1})]
    public void OfficialTestCases(int[] num1, int m, int[] num2, int n, int[] expected) {
        var sut = new Q88_MergeSortedArray();
        sut.Merge(num1, m, num2, n);
        Assert.True(num1.SequenceEqual(expected));
    }
}

public class Q88_MergeSortedArray {
    public void Merge(int[] num1, int m, int[] num2, int n) {

    }
}