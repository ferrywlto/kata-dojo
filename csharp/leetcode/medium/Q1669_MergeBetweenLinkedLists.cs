
public class Q1669_MergeBetweenLinkedLists(ITestOutputHelper output) : ListNodeTest(output)
{
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        return new ListNode();
    }
    public static TheoryData<ListNode, int, int, ListNode, ListNode> TestData => new()
    {

        {ListNode.FromArray([10,1,13,6,9,5])!, 3, 5, ListNode.FromArray([1000000,1000001,1000002])!, ListNode.FromArray([10,1,13,1000000,1000001,1000002,5])!},
        {ListNode.FromArray([0,1,2,3,4,5,6])!, 2, 5, ListNode.FromArray([1000000,1000001,1000002,1000003,1000004])!, ListNode.FromArray([0,1,1000000,1000001,1000002,1000003,1000004,6])!},
    };
    [Theory]
    [MemberData(nameof(TestData))]
    public void Test(ListNode input1, int a, int b, ListNode input2, ListNode expected)
    {
        var actual = MergeInBetween(input1, a, b, input2);
        Assert.Equal(expected, actual);
    }
}