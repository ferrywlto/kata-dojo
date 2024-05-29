
class Q1018_BinaryPrefixDivisibleBy5
{
        public IList<bool> PrefixesDivBy5(int[] nums) {
        return Enumerable.Repeat(false, nums.Length).ToList();
    }
}
class Q1018_BinaryPrefixDivisibleBy5TestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {0,1,1}, new bool[] {true,false,false}],
        [new int[] {1,1,1}, new bool[] {false,false,false}],
    ];
}
public class Q1018_BinaryPrefixDivisibleBy5Tests
{
    [Theory]
    [ClassData(typeof(Q1018_BinaryPrefixDivisibleBy5TestData))]
    public void Test_Solution(int[] input, bool[] expected)
    {
        var sut = new Q1018_BinaryPrefixDivisibleBy5();
        var actual = sut.PrefixesDivBy5(input);
        Assert.Equal(expected, actual);
    }
}