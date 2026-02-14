public class Q2303_CalculateAmountPaidInTaxes
{
    // TC: O(n), n scale with number of brackets
    // SC: O(1), space used does not scale with input
    public double CalculateTax(int[][] brackets, int income)
    {
        double result = 0;
        for (var i = 0; i < brackets.Length; i++)
        {
            var upper = i == 0
                ? brackets[i][0]
                : brackets[i][0] - brackets[i - 1][0];

            double percentage = brackets[i][1];
            var payable = Math.Min(income, upper);
            var tax = payable * percentage / 100;
            result += tax;
            income -= payable;

            if (income == 0) break;
        }
        return Math.Round(result, 5);
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
