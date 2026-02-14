public class Q2807_InsertGreatestCommonDivisorsInLinkedList
{
    // TC: O(n), n scale with length of head
    // SC: O(1), space used does not scale with input
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        var curr = head;
        while (curr != null && curr.Next != null)
        {
            var gcd = GCD(curr.Val, curr.Next.Val);
            var newNode = new ListNode(gcd)
            {
                Next = curr.Next
            };
            curr.Next = newNode;
            curr = newNode.Next;
        }
        return head;
    }
    private int GCD(int a, int b)
    {
        if (b == 0) return a;
        return GCD(b, a % b);
    }
    public static TheoryData<ListNode, ListNode> TestData => new()
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
