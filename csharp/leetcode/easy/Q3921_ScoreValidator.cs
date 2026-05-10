public class Q3921_ScoreValidator
{
    // TC: O(n), n scale with length of events
    // SC: O(1)
    public int[] ScoreValidator(string[] events)
    {
        var result = 0;
        var counter = 0;
        for (var i = 0; i < events.Length; i++)
        {
            var evt= events[i];
            switch (evt)
            {
                case "W":
                {
                    if(++counter == 10)
                        return [result, counter];
                    break;
                }
                case "WD":
                case "NB":
                    result += 1;
                    break;
                default:
                    result += int.Parse(evt);
                    break;
            }
        }
        return [result, counter];
    }

    public static TheoryData<string[], int[]> TestData => new()
    {
        { ["1", "4", "W", "6", "WD"], [12, 1] },
        { ["WD", "NB", "0", "4", "4"], [10, 0] },
        { ["W", "W", "W", "W", "W", "W", "W", "W", "W", "W", "W"], [0, 10] }
    };

    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(string[] input, int[] expected)
    {
        var actual = ScoreValidator(input);
        Assert.Equal(expected, actual);
    }
}
