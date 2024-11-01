public class Q2303_CalculateAmountPaidInTaxes
{
    public double CalculateTax(int[][] brackets, int income)
    {
        return 0;
    }
    public static List<object[]> TestData =>
    [
        [
            new int[][] {
                [3,50],[7,10],[12,25]
            }, 10, 2.65000
        ],
        [
            new int[][] {
                [1,0],[4,25],[5,50]
            }, 2, 0.25000
        ],
        [
            new int[][] {
                [2,50]
            }, 0, 0.00000
        ]
    ];
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[][] input, int income, double expected)
    {
        var actual = CalculateTax(input, income);
        Assert.Equal(expected, actual);
    }
}