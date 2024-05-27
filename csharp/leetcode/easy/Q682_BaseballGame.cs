class Q682_BaseballGame
{
    // TC: O(n)
    // SC: O(n)
    public int CalPoints(string[] operations) 
    {
        var records = new Stack<int>();

        for(var i=0; i<operations.Length; i++)
        {
            switch(operations[i]) 
            {
                case "C":
                    if (records.Count > 0) records.Pop();
                    break;

                case "D":
                    if (records.Count > 0) records.Push(records.Peek() * 2);
                    break;

                case "+":
                    records.Push(records.Take(2).Sum());
                    break;

                default:
                    var point = int.Parse(operations[i]);
                    records.Push(point);
                    break;
            }
        }
        return records.Sum();  
    }
}

class Q682_BaseballGameTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new string[]{"5","2","C","D","+"}, 30],
        [new string[]{"5","-2","4","C","D","9","+","+"}, 27],
        [new string[]{"1","C"}, 0],
    ];
}

public class Q682_BaseballGameTests
{
    [Theory]
    [ClassData(typeof(Q682_BaseballGameTestData))]
    public void OfficialTestCases(string[] input, int expected)
    {
        var sut = new Q682_BaseballGame();
        var actual = sut.CalPoints(input);
        Assert.Equal(expected, actual);
    }
}