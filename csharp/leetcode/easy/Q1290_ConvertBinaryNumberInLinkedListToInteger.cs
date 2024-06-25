
class Q1290_ConvertBinaryNumberInLinkedListToInteger
{
    public int GetDecimalValue(ListNode head) 
    {
        return 0;   
    }    
}
class Q1290_ConvertBinaryNumberInLinkedListToIntegerTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1, 0 ,1}, 5],
        [new int[]{0}, 0],
    ];
}
public class Q1290_ConvertBinaryNumberInLinkedListToIntegerTests
{
    [Theory]
    [ClassData(typeof(Q1290_ConvertBinaryNumberInLinkedListToIntegerTestData))]
    public void OfficialTestCases(int[] input, int expected)
    {
        var sut = new Q1290_ConvertBinaryNumberInLinkedListToInteger();
        var list = ListNode.FromArray(input);
        var actual = sut.GetDecimalValue(list!);
        Assert.Equal(expected, actual);
    }
}