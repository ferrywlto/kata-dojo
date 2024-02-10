namespace dojo.leetcode;

public class Q414_ThirdMaximum
{
    // TC: O(n), SC: O(1)
    public int ThirdMax(int[] nums)
    {
        return 0;
    }
}

public class Q414_ThirdMaximumTestData: TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {3, 2, 1}, 1],
        [new int[] {1, 2}, 2],
        [new int[] {2, 2, 3, 1}, 1],
    ];
}

public class Q414_ThirdMaximumTest
{
    [Theory]
    [ClassData(typeof(Q414_ThirdMaximumTestData))]
    public void OfficerTestCase(int[] input, int expected)
    {
        var sut = new Q414_ThirdMaximum();
        var actual = sut.ThirdMax(input);
        Assert.Equal(expected, actual);
    }
}