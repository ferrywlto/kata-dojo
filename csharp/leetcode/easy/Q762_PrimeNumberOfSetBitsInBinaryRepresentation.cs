public class Q762_PrimeNumberOfSetBitsInBinaryRepresentation
{
    // TC: O((right-left*)*num_bits_1)
    // SC: O(distinct_bits_count)
    public int CountPrimeSetBits(int left, int right)
    {
        var dict = new Dictionary<int, int>();
        for (var i = left; i <= right; i++)
        {
            var numBitsSet = NumBitsSet(i);
            if (dict.TryGetValue(numBitsSet, out int value))
            {
                dict[numBitsSet] = ++value;
            }
            else
            {
                dict.Add(numBitsSet, 1);
            }
        }

        var primes = 0;
        foreach (var bits in dict)
        {
            if (IsPrime(bits.Key)) primes += bits.Value;
        }

        return primes;
    }

    public int NumBitsSet(int input)
    {
        var result = 0;
        while (input != 0)
        {
            result += input & 1;
            input >>= 1;
        }
        return result;
    }

    public bool IsPrime(int input)
    {
        if (input <= 1) return false;
        if (input == 2) return true;
        if (input % 2 == 0) return false;
        for (int i = 3; i * i <= input; i += 2)
        {
            if (input % i == 0) return false;
        }
        return true;
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

    [Theory]
    [InlineData(1, false)]
    [InlineData(2, true)]
    [InlineData(3, true)]
    [InlineData(4, false)]
    [InlineData(5, true)]
    [InlineData(6, false)]
    [InlineData(7, true)]
    [InlineData(8, false)]
    [InlineData(9, false)]
    [InlineData(10, false)]
    public void IsPrime_ReturnTrueOnPrimes(int input, bool expected)
    {
        var sut = new Q762_PrimeNumberOfSetBitsInBinaryRepresentation();
        var actual = sut.IsPrime(input);
        Assert.Equal(expected, actual);
    }
}