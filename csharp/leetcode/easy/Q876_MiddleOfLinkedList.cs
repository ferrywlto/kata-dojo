// TC: O(n), n is 1.5 * list length
// SC: O(1), no extra space used
public class Q876_MiddleOfLinkedList
{
    public ListNode MiddleNode(ListNode head) 
    {
        var count = 0;
        var current = head;
        while(current != null)
        {
            count++;
            current = current.next;
        }

        var middle = Math.Ceiling((float)count / 2);
        current = head;
        // starting from head therefore it is 1 based instead of 0
        while(middle > 1 && current != null)
        {
            current = current.next;
            middle--;
        }
        if (current != null && count % 2 == 0) 
            current = current.next;

        return current!;
    }

    // Add faster 2 pointer approach for reference
    public ListNode MiddleNode_Faster(ListNode head) 
    {
        var slow = head;
        var fast = head;
        while (fast != null && fast.next != null)
        {
            slow = slow?.next;
            fast = fast.next.next;
        }
        return slow!;
    }
}

public class Q876_MiddleOfLinkedListTestData : TestData
{
    protected override List<object[]> Data => 
    [
        [new int[] {1,2,3,4,5}, new int[] {3,4,5}],
        [new int[] {1,2,3,4,5,6}, new int[] {4,5,6}],
        [new int[] {1}, new int[] {1}],
        [new int[] {1,2}, new int[] {2}],
        [new int[] {1,2,3}, new int[] {2,3}],
    ];
}

public class Q876_MiddleOfLinkedListTests : ListNodeTest
{
    public Q876_MiddleOfLinkedListTests(ITestOutputHelper output) : base(output) {}

    [Theory]
    [ClassData(typeof(Q876_MiddleOfLinkedListTestData))]
    public void OfficialTestCases(int[] input, int[] expected)
    {
        var sut = new Q876_MiddleOfLinkedList();
        var list = ListNode.FromArray(input);
        var node = sut.MiddleNode(list!);
        var actual = ListNode.ToArray(node);
        Assert.Equal(expected, actual);
    }
}
