public class Q2807_InsertGreatestCommonDivisorsInLinkedList
{
    public ListNode InsertGreatestCommonDivisors(ListNode head) 
    {
        return new ListNode();
    }
    public static TheoryData<ListNode, ListNode> TestData => new ()
    {
        {ListNode.FromArray([18,6,10,3])!, ListNode.FromArray([18,6,6,2,10,1,3])!},
        {ListNode.FromArray([7])!, ListNode.FromArray([7])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode input, ListNode expected)
    {
        var actual = InsertGreatestCommonDivisors(input);
        ListNodeTest.AssertListNodeEquals(expected, actual);
    }

}