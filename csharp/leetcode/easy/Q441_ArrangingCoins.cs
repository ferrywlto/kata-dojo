class Q441_ArrangingCoins
{
    // Constraints
    // 1 <= n <= 2^31 - 1
    // TC: O(n), SC: O(1)
    // Math: Sum(1 to n) = (n * (n + 1)) / 2
    public long SumFromOneTo(long n) => n * (n + 1) / 2;
    public int ArrangeCoins(int n)
    {
        if (n == 0 || n == 1) return n;
        // actually it is also a binary search problem
        // find SumFromOneTo(middle) >= n
        long start = 0;
        long end = n;

        long middle = (end + start) / 2;
        long temp = 0;
        while (end - start > 1)
        {
            temp = SumFromOneTo(middle);
            if (temp == n)
            {
                return (int)middle;
            }
            else if (temp > n)
            {
                end = middle;
            }
            else
            {
                start = middle;
            }
            middle = (end + start) / 2;
        }
        return (int)middle;
    }
}

class Q441_ArrangingCoinsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [5, 2],
        [8, 3],
        [1, 1],
        [3, 2],
        [0, 0],
        [1804289383, 60070],
        [2147483647, 65535],
    ];
}

public class Q441_ArrangingCoinsTests
{
    [Theory]
    [ClassData(typeof(Q441_ArrangingCoinsTestData))]
    public void OfficerTestCase(int input, int expected)
    {
        var sut = new Q441_ArrangingCoins();
        var actual = sut.ArrangeCoins(input);
        Assert.Equal(expected, actual);
    }
}
