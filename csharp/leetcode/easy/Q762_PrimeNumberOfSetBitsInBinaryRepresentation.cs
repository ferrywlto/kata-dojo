
namespace dojo.leetcode;

public class Q762_PrimeNumberOfSetBitsInBinaryRepresentation
{
    public int CountPrimeSetBits(int left, int right) 
    {
        return 0;
    }
}

public class Q762_PrimeNumberOfSetBitsInBinaryRepresentationTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [6,10,4],
        [10,15,5],
    ];
}

public class Q762_PrimeNumberOfSetBitsInBinaryRepresentationTests
{
    [Theory]
    [ClassData(typeof(Q762_PrimeNumberOfSetBitsInBinaryRepresentationTestData))]
    public void OfficialTestCases(int left, int right, int expected)
    {
        var sut = new Q762_PrimeNumberOfSetBitsInBinaryRepresentation();
        var actual = sut.CountPrimeSetBits(left, right);
        Assert.Equal(expected, actual);
    }
}