public class Q3591_CheckIfAnyElementHasPrimeFrequency
{
    public bool CheckPrimeFrequency(int[] nums)
    {

    }
    public static TheoryData<int[], bool> TestData => new()
    {
        {[1,2,3,4,5,4], true},
        {[1,2,3,4,5], false},
        {[2,2,2,4,4], true},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(int[] input, bool expected)
    {
        var actual = CheckPrimeFrequency(input);
        Assert.Equal(expected, actual);
    }
}