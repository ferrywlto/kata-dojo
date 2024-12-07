public class Q2591_DistributeMoneyToMaxChildren(ITestOutputHelper output)
{
    // TC: O(n), n scale with size of children
    // SC: O(1), space used does not scale with input
    public int DistMoney(int money, int children)
    {
        if (money < children) return -1;
        if (money < (7 + children)) return 0;
        if (money / 8 == children && money % 8 == 0) return children;

        output.WriteLine("min pass");
        var initalMoney = money - children; // minimal everyone get 1
        // give 7 more to a child until 1 child left
        var childGet8 = 0;
        var initChild = children;
        while (initalMoney >= 7 && initChild > 1)
        {
            initalMoney -= 7;
            childGet8++;
            initChild--;
        }
        // check remaining money, if remaining is 3, last child will get 4, then childGet8 need minus 1 to have the last child not getting 4 by move 1 to last child
        if (initalMoney == 3 && childGet8 == children - 1)
        {
            return childGet8 - 1;
        }
        return childGet8;
    }
    public static List<object[]> TestData =>
    [
        [20, 3, 1],
        [16, 2, 2],
        [2, 2, 0],
        [3, 2, 0],
        [10, 3, 1],
        [21, 3, 2],
        [3, 3, 0],
        [8, 2, 0],
        [9, 3, 0],
        [12, 3, 1],
        [13, 3, 1],
        [17, 2, 1],
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int input, int child, int expected)
    {
        var actual = DistMoney(input, child);
        Assert.Equal(expected, actual);
    }
}