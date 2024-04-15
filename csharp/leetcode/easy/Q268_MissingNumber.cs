public class Q268_MissingNumber
{
    // TC: O(n), SC:O(1)
    // This version make use of the properties of arithmetic series
    public int MissingNumber(int[] nums)
    {
        int n = nums.Length;
        int totalSum = n * (n + 1) / 2; // sum of 0 to n

        int arraySum = 0;
        for (int i = 0; i < n; i++)
        {
            arraySum += nums[i];
        }

        return totalSum - arraySum; // the missing number
    }
}

public class Q268_MissingNumberTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{3,0,1}, 2],
        [new int[]{0,1}, 2],
        [new int[]{9,6,4,2,3,5,7,0,1}, 8],
    ];
}

public class Q268_MissingNumberTests
{
    [Theory]
    [ClassData(typeof(Q268_MissingNumberTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q268_MissingNumber();
        var actual = sut.MissingNumber(input);
        Assert.Equal(expected, actual);
    }
}