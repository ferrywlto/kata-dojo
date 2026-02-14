
public class Q1669_MergeBetweenLinkedLists : ListNodeTest
{
    public Q1669_MergeBetweenLinkedLists(ITestOutputHelper output) : base(output)
    {

    }
    // TC: O(n + m), n scale with length of list1, m scale with length of list2
    // SC: O(1), space used does not scale with input
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        var node = list1;
        var currentIdx = 1;

        while (currentIdx < a)
        {
            node = node!.Next;
            currentIdx++;
        }
        var start = node!;

        while (currentIdx <= b + 1)
        {
            node = node!.Next;
            currentIdx++;
        }
        var end = node;

        start!.Next = list2;

        var lastNodeInList2 = list2;

        while (lastNodeInList2!.Next != null)
        {
            lastNodeInList2 = lastNodeInList2.Next;
        }
        lastNodeInList2.Next = end;

        return list1;
    }
    public static TheoryData<ListNode, int, int, ListNode, ListNode> TestData => new()
    {

        {ListNode.FromArray([10,1,13,6,9,5])!, 3, 4, ListNode.FromArray([1000000,1000001,1000002])!, ListNode.FromArray([10,1,13,1000000,1000001,1000002,5])!},
        {ListNode.FromArray([0,1,2,3,4,5,6])!, 2, 5, ListNode.FromArray([1000000,1000001,1000002,1000003,1000004])!, ListNode.FromArray([0,1,1000000,1000001,1000002,1000003,1000004,6])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode input1, int a, int b, ListNode input2, ListNode expected)
    {
        var actual = MergeInBetween(input1, a, b, input2);
        // Assert.Equal(expected, actual);
        AssertListNodeEquals(expected, actual);

    }
}
