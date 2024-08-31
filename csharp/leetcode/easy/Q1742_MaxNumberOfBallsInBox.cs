class Q1742_MaxNumberOfBallsInBox
{
    public int CountBalls(int lowLimit, int highLimit) 
    {
        // TC: O(n log n), where n is high-low-1 and log n from Sum()
        // SC: O(m), where m is the number of unique sum 
        var dict = new Dictionary<int, int>();
        var max = int.MinValue;
        for(var i=lowLimit; i<= highLimit; i++)
        {
            var sum = Sum(i);
            if(dict.TryGetValue(sum, out var value))
                dict[sum] = ++value;
            else 
                dict.Add(sum, 1);

            if (dict[sum] > max) max = dict[sum];
        }
        return max;
    }
    public int Sum(int input)
    {
        var result = 0;
        while(input > 0)
        {
            result += input % 10;
            input /= 10;
        }
        return result;
    }
}
class Q1742_MaxNumberOfBallsInBoxTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [1,10,2],
        [5,15,2],
        [19,28,2],
    ];
}
public class Q1742_MaxNumberOfBallsInBoxTests
{
    [Theory]
    [ClassData(typeof(Q1742_MaxNumberOfBallsInBoxTestData))]
    public void OfficialTestCases(int low, int high, int expected)
    {
        var sut = new Q1742_MaxNumberOfBallsInBox();
        var actual = sut.CountBalls(low, high);
        Assert.Equal(expected, actual);
    }
}