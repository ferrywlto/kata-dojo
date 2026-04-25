class Q21_MergeTwoListsTestData : TestData
{
    protected override List<object[]> Data =>
    [
        [new int[] { 1, 2, 4 }, new int[] { 1, 3, 4 }, new int[] { 1, 1, 2, 3, 4, 4 }], // 1->2->4, 1->3->4
        [Array.Empty<int>(), Array.Empty<int>(), Array.Empty<int>()], // [], []
        [Array.Empty<int>(), new int[] { 0 }, new int[] { 0 }], // [], [0]
    ];
}

public class Q21_MergeTwoListsTests(ITestOutputHelper output) : ListNodeTest(output)
{
    [Theory]
    [ClassData(typeof(Q21_MergeTwoListsTestData))]
    public void OfficialTestCases(int[] l1, int[] l2, int[] expected)
    {
        var list1 = ListNode.FromArray(l1);
        var list2 = ListNode.FromArray(l2);
        var expectedList = ListNode.FromArray(expected);
        var actual = Q21_MergeTwoLists.MergeTwoLists(list1, list2);
        AssertListNodeEquals(expectedList, actual);
    }
}

class Q21_MergeTwoLists
{

    // Speed: 45ms (100%), Memory: 41.4MB (8.83%)
    // Don't think there is room to use less memory as there is only references to the nodes, no data/node created.
    // From AI analysis, this is already O(1) in memory and O(n+m) in speed.
    public static ListNode? MergeTwoLists(ListNode? l1, ListNode? l2)
    {
        if (l1 == null && l2 == null)
            return null;
        else if (l1 == null)
            return l2;
        else if (l2 == null)
            return l1;

        ListNode current;
        if (l1.Val >= l2.Val)
        {
            current = l2;
            l2 = l2.Next;
        }
        else
        {
            current = l1;
            l1 = l1.Next;
        }
        var head = current;

        while (l1 != null && l2 != null)
        {
            if (l1.Val >= l2.Val)
            {
                current.Next = l2;
                l2 = l2.Next;
            }
            else
            {
                current.Next = l1;
                l1 = l1.Next;
            }
            current = current.Next;
        }

        if (l1 != null)
            current.Next = l1;
        else if (l2 != null)
            current.Next = l2;

        return head;
    }
}
