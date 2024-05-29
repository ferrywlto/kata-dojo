class Q1018_BinaryPrefixDivisibleBy5
{
    // TC: O(n), n is length of nums
    // SC: O(1), no data structure used
    public IList<bool> PrefixesDivBy5(int[] nums)
    {
        long currentSum = 0;
        var result = new List<bool>();

        for(var i=0; i<nums.Length; i++)
        {
            // distributive property of modular arithmetic
            // (a + b) % n = ((a % n) + (b % n)) % n
            // thus can reuse the remainder from the last calculation to prevent integer overflow
            currentSum = (currentSum * 2 + nums[i]) % 5;
            result.Add(currentSum == 0);
        }
        return result;
    }
}
class Q1018_BinaryPrefixDivisibleBy5TestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] {0,1,1}, new bool[] {true,false,false}],
        [new int[] {1,1,1}, new bool[] {false,false,false}],
        [
            new int[] {1,0,0,1,0,1,0,0,1,0,1,1,1,1,1,1,1,1,1,1,0,0,0,0,1,0,1,0,0,0,0,1,1,0,1,0,0,0,1}, 
            new bool[] {false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,false,false,true,true,true,true,false}
        ],
        [
            new int[] {1,0,1,1,1,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,1,1,1,1,0,0,0,0,1,1,1,0,0,0,0,0,1,0,0,0,1,0,0,1,1,1,1,1,1,0,1,1,0,1,0,0,0,0,0,0,1,0,1,1,1,0,0,1,0},
            new bool[] {false,false,true,false,false,false,false,false,false,false,true,true,true,true,true,true,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,true,false,false,false,true,false,false,true,false,false,true,true,true,true,true,true,true,false,false,true,false,false,false,false,true,true}
        ],
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