
class Q1502_CanMakeArithmeticProgressionFromSequence
{
    public bool CanMakeArithmeticProgression(int[] arr) 
    {
        return false;    
    }    
}
class Q1502_CanMakeArithmeticProgressionFromSequenceTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {3,5,1}, true],
        [new int[] {1,2,4}, false],
    ];
}
public class Q1502_CanMakeArithmeticProgressionFromSequenceTests
{
    [Theory]
    [ClassData(typeof(Q1502_CanMakeArithmeticProgressionFromSequenceTestData))]
    public void OfficialTestCases(int[] input, bool expected)
    {
        var sut = new Q1502_CanMakeArithmeticProgressionFromSequence();
        var actual = sut.CanMakeArithmeticProgression(input);
        Assert.Equal(expected, actual);
    }
}