public class Q2181_MergeNodesInBetweenZeros(ITestOutputHelper output)
{
    // TC: O(n), n scale with length of input list
    // SC: O(1), space used does not scale with input
    public ListNode MergeNodes(ListNode head)
    {
        var sum = 0;
        var curr = head;
        var temp = head;
        while (curr != null)
        {
            if (curr.Val == 0 && sum > 0)
            {
                temp.Val = sum;
                sum = 0;
                if (curr.Next != null)
                {
                    temp.Next = curr;
                    temp = curr;
                }
                else temp.Next = null;
            }
            else sum += curr.Val;
            curr = curr.Next;
        }

        return head;
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
        ListNodeTest.PrintList(actual, output);
        ListNodeTest.AssertListNodeEquals(expected, actual);
    }
}
