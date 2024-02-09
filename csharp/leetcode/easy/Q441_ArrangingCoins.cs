namespace dojo.leetcode;

public class Q441_ArrangingCoins
{
    // Constraints
    // 1 <= n <= 2^31 - 1
    // TC: O(n), SC: O(1)
    public int ArrangeCoins(int n)
    {
        // if (n == 0 || n == 1) return n;
        int count = 0;
        long temp = 0;
        while (temp <= n)
        {
            temp += ++count;
        }
        return count-1;
    }
}

public class Q441_ArrangingCoinsTestData: TestData
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

public class Q441_ArrangingCoinsTest
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