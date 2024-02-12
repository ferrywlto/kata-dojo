namespace dojo.leetcode;

public class Q461_HammingDistance
{
    public int HammingDistance(int x, int y)
    {
        return 0;
    }
}

public class Q461_HammingDistanceTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [1, 4, 2],
        [3, 1, 1],
    ];
}

public class Q461_HammingDistanceTest
{
    [Theory]
    [ClassData(typeof(Q461_HammingDistanceTestData))]
    public void OfficerTestCase(int x, int y, int expected)
    {
        var sut = new Q461_HammingDistance();
        var actual = sut.HammingDistance(x, y);
        Assert.Equal(expected, actual);
    }
}