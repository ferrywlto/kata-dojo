class Q1399_CountLargestGroup
{
    // TC: O(n), n scale with size of n
    // SC: O(1), space used does not scale with input. Constraint 9999 max -> sum = 36
    public int CountLargestGroup(int n)
    {
        var groups = new int[37];
        var maxGroupSize = 0;
        for (var i = 1; i <= n; i++)
        {
            var num = i;
            var digitSum = 0;
            while (num > 0)
            {
                digitSum += num % 10;
                num /= 10;
            }
            groups[digitSum]++;
            if (groups[digitSum] > maxGroupSize)
            {
                maxGroupSize = groups[digitSum];
            }
        }

        var result = 0;
        for (var j = 0; j < groups.Length; j++)
        {
            if (groups[j] == maxGroupSize) result++;
        }
        Console.WriteLine(string.Join(',', groups));
        return result;
    }
}
class Q1399_CountLargestGroupTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [9999, 1],
        [20, 1],
        [13, 4],
        [2, 2],
    ];
}
public class Q1399_CountLargestGroupTests
{
    [Theory]
    [ClassData(typeof(Q1399_CountLargestGroupTestData))]
    public void OfficialTestCases(int input, int expected)
    {
        var sut = new Q1399_CountLargestGroup();
        var actual = sut.CountLargestGroup(input);
        Assert.Equal(expected, actual);
    }
}
