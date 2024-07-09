class Q1399_CountLargestGroup
{
    // TC: O(n+m), it have to run from 1 to n once, then m for counting the dictionary with max group length
    // SC: O(n+m), n digitSums + m count of each digit sum 
    public int CountLargestGroup(int n)
    {
        var digitSum = new Dictionary<int, int>();
        var sumCount = new Dictionary<int, int>();
        var maxGroupCount = 1;
        for (var i = 1; i <= n; i++)
        {
            var num = i;
            var digitSumResult = 0;
            while (num > 0)
            {
                if (digitSum.TryGetValue(num, out var value))
                {
                    digitSumResult += value;
                    break;
                }
                else
                {
                    digitSumResult += num % 10;
                    num /= 10;
                }
            }
            digitSum.TryAdd(i, digitSumResult);
            if (sumCount.TryGetValue(digitSumResult, out var count))
                sumCount[digitSumResult] = ++count;
            else
                sumCount.TryAdd(digitSumResult, 1);

            if (count > maxGroupCount)
                maxGroupCount = count;
        }
        return sumCount.Count(x => x.Value == maxGroupCount);
    }
}
class Q1399_CountLargestGroupTestData : TestData
{
    protected override List<object[]> Data =>
    [
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