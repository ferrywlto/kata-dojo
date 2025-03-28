public class Q2181_MergeNodesInBetweenZeros
{
    public ListNode MergeNodes(ListNode head)
    {
        return new ListNode();
    }
    public static TheoryData<ListNode, ListNode> TestData => new()
    {
        {ListNode.FromArray([0,3,1,0,4,5,2,0])!, ListNode.FromArray([4,11])!},
        {ListNode.FromArray([0,1,0,3,0,2,2,0])!, ListNode.FromArray([1,3,4])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode input, ListNode expected)
    {
        var actual = MergeNodes(input);
        ListNodeTest.AssertListNodeEquals(expected, actual);
    }
}