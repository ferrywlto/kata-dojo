namespace dojo.leetcode;

public class Q762_PrimeNumberOfSetBitsInBinaryRepresentation
{
    public int CountPrimeSetBits(int left, int right) 
    {
        return 0;
    }

    public int NumBitsSet(int input)
    {
        var result = 0;
        while(input != 0)
        {
            if((input & 1) == 1)
            {
                result++;
            }
            input >>= 1;
        }
        return result;
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

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 1)]
    [InlineData(5, 2)]
    [InlineData(6, 2)]
    [InlineData(7, 3)]
    [InlineData(8, 1)]
    public void NumBitsSet_CountCorrectOnesFromInput(int input, int expected)
    {
        var sut = new Q762_PrimeNumberOfSetBitsInBinaryRepresentation();
        var actual = sut.NumBitsSet(input);
        Assert.Equal(expected, actual);
    }
}