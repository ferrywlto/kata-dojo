public class Q3932_CountKthRootsInRange
{
    // TC: O(r-l * power)
    // SC: O(1)
    public int CountKthRoots(int l, int r, int k)
    {
        var result = 0;
        for (var i = 0; i <= r; i++)
        {
            var pow = PowK(i, k);
            if (pow >= l && pow <= r) result++;
            else if (pow > r) return result;
        }
        return result;
    }

    private long PowK(int input, int power)
    {
        var i = 1;
        var n = input;
        while (i < power)
        {
            n *= input;
            i++;
        }
        return n;
    }

    public static TheoryData<int, int, int, int> TestData => new()
    {
        { 1, 9, 3, 2 },
        { 8, 30, 2, 3 },
        { 19, 22, 1, 4},
        { 0, 26, 2, 6},
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int l, int r, int k, int expected)
    {
        var actual = CountKthRoots(l, r, k);
        Assert.Equal(expected, actual);
    }
}
