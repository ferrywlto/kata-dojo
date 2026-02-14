
public class Q237_DeleteNodeInLinkedList(ITestOutputHelper output) : ListNodeTest(output)
{
    // TC: O(n), n scale with length of list
    // SC: O(1), space used does not scale with input
    private void DeleteNode(ListNode node)
    {
        // keep reference of last node
        var prev = node;
        // keep moving value upward
        while (node.Next != null)
        {
            node.Val = node.Next.Val;
            prev = node;
            node = node.Next;
        }
        // prune the tail
        prev.Next = null;
    }
    public static TheoryData<ListNode, int, ListNode> TestData => new()
    {
        {ListNode.FromArray([4,5,1,9])!, 5, ListNode.FromArray([4,1,9])!},
        {ListNode.FromArray([4,5,1,9])!, 1, ListNode.FromArray([4,5,9])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode input, int node, ListNode expected)
    {
        var targetNode = input;
        while (targetNode != null)
        {
            if (targetNode.Val == node) break;
            targetNode = targetNode.Next;
        }
        DeleteNode(targetNode!);
        AssertListNodeEquals(input, expected);
    }
}
