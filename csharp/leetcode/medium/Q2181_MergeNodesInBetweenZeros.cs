public class Q2181_MergeNodesInBetweenZeros
{
    // TC: O(n), n scale with length of input list
    // SC: O(m), m scale with length of result;
    public ListNode MergeNodes(ListNode head)
    {
        var list = new List<int>();
        var sum = 0;
        var curr = head;
        while (curr != null)
        {
            if (curr.Val == 0 && sum > 0)
            {
                list.Add(sum);
                sum = 0;
            }
            else
            {
                sum += curr.Val;
            }
            curr = curr.Next;
        }

        var ans = new ListNode(list[0]);
        var node = ans;
        for (var i = 1; i < list.Count; i++)
        {
            var next = new ListNode(list[i]);
            node.Next = next;
            node = node.Next;
        }
        return ans;
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