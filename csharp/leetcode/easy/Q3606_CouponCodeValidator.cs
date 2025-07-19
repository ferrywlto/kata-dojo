public class Q3606_CouponCodeValidator
{
    public IList<string> ValidateCoupons(string[] code, string[] businessLine, bool[] isActive)
    {
        return [];
    }
    public static TheoryData<string[], string[], bool[], string[]> TestData => new()
    {
        {
            ["SAVE20", "", "PHARMA5", "SAVE@20"],
            ["restaurant","grocery","pharmacy","restaurant"],
            [true,true,true,true],
            ["PHARMA5","SAVE20"]
        },
        {
            ["GROCERY15","ELECTRONICS_50","DISCOUNT10"],
            ["grocery","electronics","invalid"],
            [false,true,true],
            ["ELECTRONICS_50"]
        },
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] code, string[] line, bool[] isActive, string[] expected)
    {
        var actual = ValidateCoupons(code, line, isActive);
        Assert.Equal(expected, actual);
    }
}