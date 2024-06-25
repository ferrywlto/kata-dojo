class Q1290_ConvertBinaryNumberInLinkedListToInteger
{
    // TC: O(n), all elements need to traverse once
    // SC: O(n), stack size equals to list length
    public int GetDecimalValue(ListNode head) 
    {
        var stack = new Stack<int>();
        var current = head;
        do
        {
            stack.Push(current.val);
            current = current.next;
        }
        while(current != null);
        var result = stack.Pop();
        var exp = 1;
        while(stack.Count > 0)
        {   
            exp *= 2;
            result += exp * stack.Pop();
        }
        return result;   
    }   
}
class Q1290_ConvertBinaryNumberInLinkedListToIntegerTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[]{1, 0 ,1}, 5],
        [new int[]{1, 0 ,0, 0}, 8],
        [new int[]{0, 1, 0 ,0, 0}, 8],
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